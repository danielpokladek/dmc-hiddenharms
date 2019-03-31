﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{
    [SerializeField] private Canvas textCanvas;
    
    
    [SerializeField]
    private int roomScene;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(roomScene);
    }

    public void BTN_GoToRoom()
    {
        SceneManager.LoadScene(roomScene);
    }
}