using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class facebook : MonoBehaviour {
    public Text usuario;
    public Image foto;
    // Include Facebook namespace


    // Awake function from Unity's MonoBehavior
    void Awake()
{
    if (!FB.IsInitialized)
    {
        // Initialize the Facebook SDK
        FB.Init(InitCallback, OnHideUnity);
    }
    else
    {
        // Already initialized, signal an app activation App Event
        FB.ActivateApp();
    }
}

private void InitCallback()
{
    if (FB.IsInitialized)
    {
        // Signal an app activation App Event
        FB.ActivateApp();
        // Continue with Facebook SDK
        // ...
    }
    else
    {
        Debug.Log("Failed to Initialize the Facebook SDK");
    }
}

private void OnHideUnity(bool isGameShown)
{
    if (!isGameShown)
    {
        // Pause the game - we will need to hide
        Time.timeScale = 0;
    }
    else
    {
        // Resume the game - we're getting focus again
        Time.timeScale = 1;
    }
}
    public void Login()
    {
        var perms = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(perms, AuthCallback);
    }

private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
            FB.API("/me?fields=first_name", HttpMethod.GET, MostrarNombre);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, MostrarFoto);
            SceneManager.LoadScene("EscenaJuego");
            
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }

    public void MostrarNombre(IResult result)
    {
        if (result.Error == null)
        {
            usuario.text = (string)result.ResultDictionary["first_name"];
        }
    }

    public void MostrarFoto(IGraphResult result)
    {
        if(result.Texture != null)
        {
            foto.sprite = Sprite.Create(result.Texture, new Rect(0,0,128,128), new Vector2());
        }else
        {
            Debug.Log("no pic");
        }
    }
}
