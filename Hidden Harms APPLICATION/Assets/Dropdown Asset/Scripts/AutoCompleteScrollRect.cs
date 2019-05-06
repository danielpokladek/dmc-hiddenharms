using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AutoCompleteScrollRect : MonoBehaviour
{
    // References
    [SerializeField] InputField m_InputField;
    [SerializeField] ScrollRect m_ScrollRect;
    private RectTransform m_ScrollRectTransform;

    // Prefab for available options
    [SerializeField] OptionButton m_OptionPrefab;

    // The transform (parent) to spawn options into
    [SerializeField] Transform m_OptionsParent;

    [SerializeField] List<string> m_Options;

    private Dictionary<string, GameObject> m_OptionObjectSpawnedDict;       // Store a list of options in a dictionary, essentially object pooling the buttons

    private float m_OriginalOffsetMinY;

    [SerializeField] int m_ComponentsHeight = 50;                           // The size of the option buttons
    [SerializeField] int m_OptionsOnDisplay = 3;                            // How many options the scrollview can display at one time

    private void Start()
    {
        m_OriginalOffsetMinY = m_ScrollRect.gameObject.GetComponent<RectTransform>().offsetMin.y;

        m_ScrollRectTransform = m_ScrollRect.gameObject.GetComponent<RectTransform>();

        m_ScrollRect.gameObject.SetActive(false);   // By default, we don't need to show the scroll view.

        SpawnClickableOptions(m_Options);
    }

    public void SetAndCloseScrollView(string optionLabel)
    {
        m_InputField.text = optionLabel;
        m_ScrollRect.gameObject.SetActive(false);
    }

    /// <summary>
    /// Spawns a list of all the available options into the scene, deactivates them, and adds them to the pool
    /// </summary>
    /// <param name="options"></param>
    private void SpawnClickableOptions(List<string> options)
    {
        ResetDictionaryAndCleanupSceneObjects();

        if(m_Options == null || m_Options.Count == 0)
        {
            Debug.LogError("Options lists is null or the list is == 0, please ensure it has something in it!");
            return;
        }

        for (int i = 0; i < m_Options.Count; i++)
        {
            // Expanded from the original script - this will detect any duplicates and skip adding them again to the dictionary.
            //  If this was not done, Unity would throw an error saying that the key already exists in the dictionary and options would be missing.
            if (m_OptionObjectSpawnedDict.ContainsKey(m_Options[i]))
            {
                continue;
            }

            GameObject obj = Instantiate(m_OptionPrefab.gameObject, m_OptionsParent);
            obj.transform.localScale = Vector3.one;

            m_OptionObjectSpawnedDict.Add(m_Options[i], obj);

            string opt = m_Options[i];

            obj.GetComponent<OptionButton>().Setup(m_Options[i], m_ComponentsHeight, () =>
            {
                Debug.Log("Clicked option " + opt);
                SetAndCloseScrollView(opt);
            });
        }
    }

    /// <summary>
    /// Cleans up the scrollview
    /// </summary>
    private void ResetDictionaryAndCleanupSceneObjects()
    {
        if (m_OptionObjectSpawnedDict == null)
        {
            m_OptionObjectSpawnedDict = new Dictionary<string, GameObject>();
            return;
        }

        if (m_OptionObjectSpawnedDict.Count == 0)
            return;

        foreach (KeyValuePair<string, GameObject> options in m_OptionObjectSpawnedDict)
            Destroy(options.Value);

        m_OptionObjectSpawnedDict.Clear();
    }

    /// <summary>
    /// Hooked up to the OnValueChanged() event of the inputfield specified, we listen out for changes within the input field.
    /// When the input.text has changed, we search the options dictionary and attempt to find matches, and display them if any.
    /// </summary>
    public void OnValueChanged()
    {
        if (m_InputField.text == "")
        {
            m_ScrollRect.gameObject.SetActive(false);       // Disable the scrollview if the inputfield is empty
            return;
        }


        List<string> optionsThatMatched = m_OptionObjectSpawnedDict.Keys.
           Where(optionKey => optionKey.ToLower().Contains(m_InputField.text.ToLower())).ToList();

        foreach (KeyValuePair<string, GameObject> keyValuePair in m_OptionObjectSpawnedDict)
        {
            if (optionsThatMatched.Contains(keyValuePair.Key))
                keyValuePair.Value.SetActive(true);
            else
                keyValuePair.Value.SetActive(false);
        }

        if( optionsThatMatched.Count == 0)
        {
            m_ScrollRect.gameObject.SetActive(false);        // Disable the scrollview if no options
            return;
        }
        

        // If options is > than the amount of options we can display
        if (optionsThatMatched.Count > m_OptionsOnDisplay)
        {
            // Then scale the height of the rect transform to only show the max amount of items we can show at one time
            m_ScrollRectTransform.offsetMin = new Vector2(
                       m_ScrollRect.GetComponent<RectTransform>().offsetMin.x,
                         m_OriginalOffsetMinY - (m_ComponentsHeight * m_OptionsOnDisplay));

        }
        else
        {
            // Else... just increase the height of the rect transform to display all of options that matched
            m_ScrollRectTransform.offsetMin = new Vector2(
                      m_ScrollRect.GetComponent<RectTransform>().offsetMin.x,
                        m_OriginalOffsetMinY - (m_ComponentsHeight * optionsThatMatched.Count));
        }

        m_ScrollRect.gameObject.SetActive(true);            // If we get here, we can assume that we want to display the options.
    }
}
