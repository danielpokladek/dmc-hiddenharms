using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
     *      - Implement the basic data access
     *      - Load facts for one of the rooms
     *      - Load facts for rest of the rooms
     *      - Load quiz questions
     *      - Load quiz answers
     *      - Make sure quiz questions & answers are loaded in correct order
     *      - Fix any other bugs if occur.
     *   
     */

    public string languageName;
    [SerializeField] private string[] FGM_Facts = new string[8];
    [SerializeField] private string[] DA_Facts = new string[8];
    [SerializeField] private string[] MS_Facts = new string[8];
    [SerializeField] private string[] ONS_Facts = new string[8];

    public string[] GetFGMFacts { get { return FGM_Facts; } }
}
