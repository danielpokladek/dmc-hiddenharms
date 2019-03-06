using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager = null;
    
    [SerializeField] private bool bathroom, bedroom, kitchen, frontroom;

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

    public bool SetFrontroom
    {
        set { frontroom = value; }
    }
}
