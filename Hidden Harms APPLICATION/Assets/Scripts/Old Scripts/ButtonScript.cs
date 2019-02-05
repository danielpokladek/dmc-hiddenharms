using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public GameObject DataManager;

    public Button button;

	// Use this for initialization
	void Start () {
        DataManager.gameObject.GetComponent<SendData>();
	}
	
	// Update is called once per frame
	void Update () {

        if (DataManager.gameObject.GetComponent<SendData>().AgeQs == true)
        {
            if (button.CompareTag("AGE"))
            {
                button.gameObject.SetActive(true);
                

            } else {
                button.gameObject.SetActive(false);
                
            }
        }

	}
}
