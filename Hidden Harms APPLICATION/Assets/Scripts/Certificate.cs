using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Certificate : MonoBehaviour
{
    public Scene sceneToLoad;

    public void BTN_Certificate()
    {
        SceneManager.LoadScene(6);
    }
}
