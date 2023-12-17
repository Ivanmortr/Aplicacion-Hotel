using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Networking;

public class web : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI user;
    [SerializeField] private TextMeshProUGUI password;
    [SerializeField] private TextMeshProUGUI confirmationPassword;
    [SerializeField] private ConfiguracionApliicacionManager aplicacionManager;
    private bool nuevoUsuario;
    private string usuario;
    private string pass;
    private int idHotel;
    void Start()
    {
        idHotel = 1;
        nuevoUsuario = false;
        // A correct website page.
        //StartCoroutine(GetRequest("http://localhost/proyectoHoteles/Login.php"));

        // A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }
    public void SetNewUser(bool nuevo)
    {
        nuevoUsuario = nuevo;
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
    public void LoginAndRegistrate()
    {
        if(nuevoUsuario)
        {
            if(password.text == confirmationPassword.text)
            {
                if(user.text.Length >= 4)
                {
                    usuario = user.text;
                    pass = password.text;
                    StartCoroutine(Registro("http://localhost/proyectoHoteles/Registro.php", usuario, pass));
                }
                else
                {
                    aplicacionManager.RegisterFailed(("El usuario debe contener un minimo de 4 caracteres"));
                }
            }
            else
            {
                aplicacionManager.RegisterFailed(("las contraseñas no coinciden"));
            }
        }
        else
        {
            usuario = user.text;
            pass = password.text;
            StartCoroutine(Login("http://localhost/proyectoHoteles/Login.php", usuario, pass));
        }
    }

    IEnumerator Login(string uri, string _usuario, string _pass)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsuario", _usuario);
        form.AddField("loginPass", _pass);
        form.AddField("idHotel", idHotel);

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                aplicacionManager.RegisterFailed("Ha ocurrido un error inesperado");
            }
            else
            {
                string responseText = www.downloadHandler.text;

                try
                {
                    // Parsear el JSON de la respuesta
                    LoginResponse response = JsonUtility.FromJson<LoginResponse>(responseText);

                    if (response.success)
                    {
                        // Inicio de sesión exitoso
                        aplicacionManager.Succes(response.message);
                    }
                    else
                    {
                        // Error en el inicio de sesión
                        aplicacionManager.RegisterFailed(response.message);
                    }
                }
                catch (Exception e)
                {
                    // Error al analizar el JSON
                    aplicacionManager.RegisterFailed("Error al conectarse al servidor");
                }
            }
        }
    }

    [Serializable]
    public class LoginResponse
    {
        public bool success;
        public string message;
    }
    IEnumerator Registro(string uri, string _usuario, string _pass)
    {
        WWWForm form = new WWWForm();
        form.AddField("nuevoUsuario", _usuario);
        form.AddField("nuevaContrasena", _pass);
        form.AddField("idHotel", idHotel);

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Analizar la respuesta JSON
                var response = JsonUtility.FromJson<RegistrationResponse>(www.downloadHandler.text);

                // Acceder a los valores booleanos y mensajes
                bool success = response.success;
                string message = response.message;
                Debug.Log("Registro exitoso: " + success);
                Debug.Log("Mensaje: " + message);

                // Aquí puedes realizar acciones adicionales según la respuesta
                if (success)
                {
                    aplicacionManager.UsuarioCreado(message);
                }
                else
                {
                    aplicacionManager.RegisterFailed(message);
                }
            }
        }
    }

    // Clase para analizar la respuesta JSON
    [System.Serializable]
    public class RegistrationResponse
    {
        public bool success;
        public string message;
    }
}
