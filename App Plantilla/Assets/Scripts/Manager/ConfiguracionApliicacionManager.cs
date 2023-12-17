using Michsky.MUIP;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UltimateClean;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ConfiguracionApliicacionManager : MonoBehaviour
{
    #region InicioAplicación

    //Objetos a llenar
    [SerializeField] private GameObject panelInicioAplicacion;
    [SerializeField] private GameObject panelLogin;
    [SerializeField] private GameObject BotonInicioSeccion;
    [SerializeField] private TextMeshProUGUI user;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField passwordConfirmation;
    [SerializeField] private GameObject logo;
    [SerializeField] private Image icon;
    [SerializeField] private Image icon2;
    [SerializeField] Sprite[] iconImage;

    //Cambios de etilo
    [SerializeField] private Sprite logotipoEmpresa;
    [SerializeField] private Color _colorFondoPanelLogin;
    [SerializeField] private Color _colorBoton1;
    [SerializeField] private Color _colorBoton2;

    //password
    private bool hidePassword;
    #endregion
    //nuevoUsuario
    [SerializeField] private GameObject confirmarContraseña;
    [SerializeField] private GameObject recuperarContraseña;
    [SerializeField] private GameObject crearCuentaNueva;
    [SerializeField] private string[] textButton;
    [SerializeField] private string[] textTitulo;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private web web;
    // [0] succes, [1] failed
    [SerializeField] private GameObject[] popUp;
    [SerializeField] private GameObject[] PopupBackground;

    #region Login/Registrarse

    //[Space(30f)]

    public void ShowPassword()
    {
        if (hidePassword)
        {
            hidePassword = false;
            icon.sprite = iconImage[0];
            icon2.sprite = iconImage[0];
            password.contentType = TMP_InputField.ContentType.Password;
            passwordConfirmation.contentType = TMP_InputField.ContentType.Password;
        }
        else
        {
            hidePassword = true;
            icon.sprite = iconImage[1];
            icon2.sprite = iconImage[1];
            password.contentType = TMP_InputField.ContentType.Standard;
            passwordConfirmation.contentType = TMP_InputField.ContentType.Standard;
        }
        password.ForceLabelUpdate();
    }
    public void RegisterFailed(string text)
    {
        popUp[1].SetActive(true);
        popUp[1].GetComponent<NotificationManager>().OpenNotification();
        popUp[1].GetComponent<NotificationManager>().description = text;
    }
    public void Succes(string text)
    {
        popUp[0].SetActive(true);
        popUp[0].GetComponent<NotificationManager>().OpenNotification();
        popUp[0].GetComponent<NotificationManager>().description = text;
    }
    public void NuevoUsuario()
    {
        web.SetNewUser(true);
        confirmarContraseña.SetActive(true);
        recuperarContraseña.SetActive(false);
        crearCuentaNueva.SetActive(false);
        //logo.SetActive(false);
        BotonInicioSeccion.GetComponentInChildren<TextMeshProUGUI>().text = textButton[1];
        PopupBackground[1].GetComponent<Image>().color = Color.red;
        title.text = textTitulo[1];
    }
    public void UsuarioCreado(string text)
    {
        popUp[0].SetActive(true);
        popUp[0].GetComponent<NotificationManager>().OpenNotification();
        popUp[0].GetComponent<NotificationManager>().description = text;
        PopupBackground[0].GetComponent<Image>().color = Color.green;
        web.SetNewUser(false);
        confirmarContraseña.SetActive(false);
        recuperarContraseña.SetActive(true);
        crearCuentaNueva.SetActive(true);
        //logo.SetActive(false);
        BotonInicioSeccion.GetComponentInChildren<TextMeshProUGUI>().text = textButton[0];
        title.text = textTitulo[0];
        password.text = "";
        passwordConfirmation.text = "";
    }
    #endregion

    #region SeleccionIdiomas
    [Space(30f)]

    

    #endregion

    #region SeleccionMapas
    [Space(30f)]

    [SerializeField] private Sprite mapaCancun;
    [SerializeField] private Sprite mapaRiveraMaya;
    
    #endregion

    public bool checkClaudeishon = true;
    
    private void Awake()
    {
        if (checkClaudeishon) return;
        logo.GetComponent<Image>().sprite = logotipoEmpresa;
        panelLogin.GetComponent<Image>().color = _colorFondoPanelLogin;
        BotonInicioSeccion.GetComponent<UltimateClean.Gradient>().Color1 = _colorBoton1;
        BotonInicioSeccion.GetComponent<UltimateClean.Gradient>().Color2 = _colorBoton1;
        Debug.Log("funcionando");
    }

    public void BotonAeropuerto()
    {
        Debug.Log("Holi soy el aeropuerto");
    }

    public class ForceAcceptAll : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
}
