using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendData : MonoBehaviour {
    
    ////Store Information on whatever GameObject this script is attached to
    //public string Info;

    ////Booleans to track what options are available
    //#region QuestionBooleans

    //public bool AgeQs = true;
    //public bool GenderQs = false;
    //public bool NationalityQs = false;
    //public bool LanguageQs = false;
    //public bool IniKnowledgeQs = false;
    //public bool PostKnowledgeQs = false;

    //#endregion

    //private void Start()
    //{
    //    //Make sure that Default PlayerPrefs are grabbed
    //    PlayerPrefs.GetString("Age", "0");
    //    PlayerPrefs.GetString("Gender", "Rather Not Say");
    //    PlayerPrefs.GetString("Nationality", "English");
    //    PlayerPrefs.GetString("Language", "English");
    //    PlayerPrefs.GetString("IniKnowledge", "Nothing");
    //    PlayerPrefs.GetString("PostKnowledge", "Nothing");
        
    //}

    ////Storing values to be sent off upon completion of the APP
    //#region DataValues

    //public void Age()
    //{
    //    PlayerPrefs.SetString("Age", Info);
    //}

    //public void Gender()
    //{
    //    PlayerPrefs.SetString("Gender", Info);
    //}

    //public void Nationality()
    //{
    //    PlayerPrefs.SetString("Nationality", Info);
    //}

    //public void Language()
    //{
    //    PlayerPrefs.SetString("Language", Info);
    //}

    //public void IniKnowledge()
    //{
    //    PlayerPrefs.SetString("IniKnowledge", Info);
    //}

    //public void PostKnowledge()
    //{
    //    PlayerPrefs.SetString("PostKnowledge", Info);
    //}

    //#endregion

    ////Start Sending the Data
    //#region SendingData

    //public void Send()
    //{
    //    StartCoroutine(Post());
    //}

    ////Post the relevant Data to the correct fields, then inform user if data was successfully posted
    //IEnumerator Post()
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("entry.416226614", PlayerPrefs.GetString("Age", "0"));
    //    form.AddField("entry.200936802", PlayerPrefs.GetString("Gender", "Rather Not Say"));
    //    form.AddField("entry.679332033", PlayerPrefs.GetString("Nationality", "English"));
    //    form.AddField("entry.199891947", PlayerPrefs.GetString("Language", "English"));
    //    form.AddField("entry.738434021", PlayerPrefs.GetString("IniKnowledge", "Nothing"));
    //    form.AddField("entry.711406450", PlayerPrefs.GetString("PostKnowledge", "Nothing"));
    //    byte[] rawData = form.data;
    //    WWW www = new WWW("https://docs.google.com/forms/d/e/1FAIpQLSeldUHslfO4JDGkjwX0Pjzwqu9Va5unoqYF0BTfSVnZwBRTzw/formResponse", rawData);

    //    yield return www;
    //    Debug.Log("SUCCESS");
    //}

    //#endregion

}
