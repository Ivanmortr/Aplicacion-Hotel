using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ConfiguracionApliicacionManager : MonoBehaviour
{
    #region InicioAplicación

    [SerializeField] private GameObject panelInicioAplicacion;
    [SerializeField] private Sprite logotipoEmpresa;
    [SerializeField] private Color _colorFondo;



    #endregion

    #region Login/Registrarse

    [Space(30f)]
    

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
        panelInicioAplicacion.GetComponent<Image>().sprite = logotipoEmpresa;
        panelInicioAplicacion.GetComponent<Image>().color = _colorFondo;
        
        
        
    }

    public void BotonAeropuerto()
    {
        Debug.Log("Holi soy el aeropuerto");
    }
    
    
}
