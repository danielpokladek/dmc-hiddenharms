using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebForm : MonoBehaviour
{
    WWWForm webForm;
    Dictionary<string, string> formFields = new Dictionary<string, string>();

    public static WebForm WebManager = null;

    private void Awake()
    {
        if (WebManager == null)
            WebManager = this;
        else if (WebManager != this)
            Destroy(WebManager);

        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start()
    {
        webForm = new WWWForm();
        //SendTestData();
    }

    /// <summary>
    /// Add a field to the web form. All fields are stored in a dictionary.
    /// </summary>
    /// <param name="fieldName">Field name, as seen on the web form. (Different for each field, check docs).</param>
    /// <param name="value">Value of the field, given as a string.</param>
    public void AddField(string fieldName, string value)
    {
        formFields.Add(fieldName, value);
    }

    /// <summary>
    /// Remove all fields from the form.
    /// </summary>
    public void ClearForm()
    {
        formFields.Clear();
    }

    public void _SendForm()
    {
        StartCoroutine(SendForm("https://docs.google.com/forms/d/e/1FAIpQLSeldUHslfO4JDGkjwX0Pjzwqu9Va5unoqYF0BTfSVnZwBRTzw/formResponse"));
    }

    /// <summary>
    /// Send form to the server. Returns a boolean.
    /// </summary>
    /// <param name="wwwAddress">WWW address for the form.</param>
    IEnumerator SendForm(string wwwAddress)
    {
        if (formFields.Count == 0)
        {
            Debug.LogError("SEND ERR: No fields in the form.");
            yield break;
        }

        foreach (KeyValuePair<string, string> entry in formFields)
        {
            if (entry.Key == "" || entry.Value == "")
            {
                Debug.LogError("SEND ERR: Empty key/value in form at: " + entry.Key.ToString());
                yield break;
            }
            webForm.AddField(entry.Key, entry.Value);
        }

        using (UnityWebRequest www = UnityWebRequest.Post(wwwAddress, webForm))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                Debug.Log(www.error);
            else
                Debug.Log("Form uploaded complete!");
        }
    }

    /// <summary>
    /// Display form fields in console.
    /// </summary>
    public void DisplayFormFields()
    {
        foreach (KeyValuePair<string, string> entry in formFields)
        {
            Debug.Log(entry.Key + " : " + entry.Value);
        }
    }

    void SendTestData()
    {
        AddField("entry.416226614", "0");
        AddField("entry.200936802", "Rather Not Say");
        AddField("entry.679332033", "English");
        AddField("entry.199891947", "English");
        AddField("entry.738434021", "Nothing");
        AddField("entry.711406450", "Nothing");

        DisplayFormFields();

        SendForm("https://docs.google.com/forms/d/e/1FAIpQLSeldUHslfO4JDGkjwX0Pjzwqu9Va5unoqYF0BTfSVnZwBRTzw/formResponse");
    }
}
