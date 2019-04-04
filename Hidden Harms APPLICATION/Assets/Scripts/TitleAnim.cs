using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Rooms;

public class TitleAnim : MonoBehaviour
{
    public Demographics _demoScript;
    public Animation anim;

    public Camera animCamera;

    private void OnMouseDown()
    {

        anim.Play();
        

    }

    public void ShowDemographics()
    {
        _demoScript.DemographicsMenu();
        ToggleCamera();
    }

    private void ToggleCamera()
    {
        animCamera.gameObject.SetActive(false);
        Camera.main.gameObject.SetActive(true);
    }
}
