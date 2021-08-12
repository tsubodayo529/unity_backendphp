using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;
    public Button registerButton;
    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(() => {
            StartCoroutine(Main.instance.web.Login(usernameInput.text, passwordInput.text));
        });
        registerButton.onClick.AddListener(() => {
            StartCoroutine(Main.instance.web.Register(usernameInput.text, passwordInput.text));
        });
    }

    
}
