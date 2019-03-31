using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleAnim : MonoBehaviour
{
    public Demographics _demoScript;
    public Animation anim;

    public Camera animCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        anim.Play();
        

    }

    public void ShowDemographics()
    {
        ToggleCamera();
        _demoScript.DemographicsMenu();
    }

    private void ToggleCamera()
    {
        animCamera.gameObject.SetActive(false);
        Camera.main.gameObject.SetActive(true);
    }

    public void ChangeScene()
    {

        SceneManager.LoadScene(1);

    }
}
