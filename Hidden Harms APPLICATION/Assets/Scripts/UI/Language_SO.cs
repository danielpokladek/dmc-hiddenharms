using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName ="NewLanguageFile", menuName ="Language File")]
public class Language_SO : ScriptableObject
{
    /*  Scriptable Objects, act like data holders. They can contain data, which can be easily read by a script.
     *  While the script itself is not attached to any gameobject, in order to use this you need to create a new asset.
     *  To create a new language asset: right click in asset menu -> create -> Language File.
     *  
     *  Next fill out all of the required fields, and attach the file to the language selection menu.
     *  
     *  To-Do:
     *      - (Done) Implement the basic data access
     *      - (Done) Load facts for one of the rooms
     *      - (Done) Load facts for rest of the rooms
     *      - Load quiz questions
     *      - Load quiz answers
     *      - Make sure quiz questions & answers are loaded in correct order
     *      - Load demographics items, at the start of the game in selected language
     *      - Load knowledge test, in the selected language
     *      - Fix any other bugs if occur.
     *   
     */

    [Header("Language Settings")]
    [SerializeField] private string         languageName;                               // Name of the langauge.
    [SerializeField] private TMP_FontAsset  languageFont;                        // Font used with this language.
    [SerializeField] private bool           useRTL;

    [Header("Room Facts")]
    [SerializeField] [TextArea] private string[] FGM_Facts  = new string[8];    // Facts about FGM.
    [SerializeField] [TextArea] private string[] DA_Facts   = new string[8];    // Facts about Domestic Abuse.
    [SerializeField] [TextArea] private string[] MS_Facts   = new string[8];    // Facts about Modern Slavery.
    [SerializeField] [TextArea] private string[] ONS_Facts  = new string[8];    // Facts about Online Safety.

    [Header("FGM Questions & Answers")]
    public string[] FGM_questions       = new string[5];
    public string[] FGM_qOneAnswers = new string[4];
    public string[] FGM_qTwoAnswers = new string[4];
    public string[] FGM_qThreeAnswers = new string[4];
    public string[] FGM_qFourAnswers = new string[4];
    public string[] FGM_qFiveAnswers = new string[4];

    [Header("DA Questions & Answers")]
    public string[] DA_Questions = new string[5];

    [Header("MS Questions & Answers")]
    public string[] MS_Questions = new string[5];

    [Header("ONS Questions & Answers")]
    public string[] ONS_Questions = new string[5];

    #region Getters
    public string GetLangName { get { return languageName; } }
    public TMP_FontAsset GetFont { get { return languageFont; } }
    public bool UsesRTL { get { return useRTL; } }
    public string[] GetFGMFacts { get { return FGM_Facts; } }
    public string[] GetDAFacts { get { return DA_Facts; } }
    public string[] GetMSFacts { get { return MS_Facts; } }
    public string[] GetONSFacts { get { return ONS_Facts; } }
    #endregion
}
