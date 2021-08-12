using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Web web;

    public static Main instance;
    
    // Start is called before the first frame update
    void Start()
    {
        web = GetComponent<Web>();
        instance = this;
    }

    
}
