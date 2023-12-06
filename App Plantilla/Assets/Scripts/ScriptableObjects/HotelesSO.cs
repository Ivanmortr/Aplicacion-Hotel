using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "CustomSO/ Configuración hoteles")]
public class HotelesSO : ScriptableObject
{
    [SerializeField] private Hotel[] _hotels;
    private Dictionary<string, Hotel> _hotelsDictionary;


    private void Awake()
    {
        _hotelsDictionary = new Dictionary<string, Hotel>();
        Debug.Log(_hotelsDictionary);

        foreach (var hotel in _hotels)
        {
            _hotelsDictionary.Add(hotel.nombreHotel, hotel);
        }
        Debug.Log(_hotelsDictionary);

    }

    public Hotel ObtenerDatosHotelPorNombre(string id)
    {
        Debug.Log(_hotelsDictionary);
        if (!_hotelsDictionary.TryGetValue(id, out var hotel))
        {
            throw new Exception($"No se encontro el hotel con el siguiente id{id}");
        }

        return hotel;
    }
}

[Serializable]
public struct Hotel
{
    public string nombreHotel;
    public int tiempoTraslado;
    public Image imagenHotel;

};