using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleAnim : MonoBehaviour
{
    public Animation anim;


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

    public void ChangeScene()
    {

        SceneManager.LoadScene(1);

    }
}
