﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager = null;

    public Language_SO languageSO;

    [HideInInspector] public bool bathroom, bedroom, kitchen, frontroom, kitchen_2;
    

    public GameManager()
    {
        DemographicsSet = false;
    }

    private void Awake()
    {
        if (manager == null)
            manager = this;
        else if (manager != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    public void SetScreenOrientation(ScreenOrientation orientation)
    {
        Screen.orientation = orientation;
    }

    public bool CheckStatus()
    {
        if (bathroom && bedroom && kitchen && frontroom && kitchen_2)
            return true;

        return false;
    }

    public bool DemographicsSet { get; set; }

    public bool SetBathroom
    {
        set { bathroom = value; }
    }

    public bool SetBedroom
    {
        set { bedroom = value; }
    }

    public bool SetKitchen
    {
        set { kitchen = value; }
    }

    public bool SetKitchen_2
    {
        set { kitchen_2 = value; }
    }

    public bool SetFrontroom
    {
        set { frontroom = value; }
    }
}
