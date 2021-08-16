using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Web web;
    public UserInfo userInfo;
    public static Main instance;
    public Login Login;
    public GameObject UserProfile;
    
    // Start is called before the first frame update
    void Start()
    {
        web = GetComponent<Web>();
        instance = this;
        userInfo = GetComponent<UserInfo>();
    }

    
}
