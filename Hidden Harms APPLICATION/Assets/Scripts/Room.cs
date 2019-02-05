using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour {

    [SerializeField]
    private int roomScene;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(roomScene);
    }
}
