
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Linea : MonoBehaviour
{
    [SerializeField] 
    private LineRenderer _linea;
    private List<Vector2> _puntos;
    

    [SerializeField]
    private float distanciaMinima = 0.1f;
    public void ActualizarLinea(Vector2 position)
    {
        if (_puntos == null)
        {
            _puntos = new List<Vector2>();
            SetPoint(position);
            
        }

        if (Vector2.Distance(_puntos.Last(), position) > distanciaMinima)
        {
            SetPoint(position);
        }
    }




    private void SetPoint(Vector2 punto)
    {
        _puntos.Add(punto);
        _linea.positionCount = _puntos.Count;
        _linea.SetPosition(_puntos.Count -1, punto);
        
    }

   
}