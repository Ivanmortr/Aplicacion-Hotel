using UnityEngine;

public class InstaladorHoteles : MonoBehaviour
{
    [SerializeField] private HotelesSO _hotelesSo;


    private void Awake()
    {
        var hotelesSo= Instantiate(_hotelesSo);
        
        Debug.Log(hotelesSo);
        var hotel = hotelesSo.ObtenerDatosHotelPorNombre("Moon Palace");
        Debug.Log(hotel.nombreHotel);

        // var hotel = _hotelesSo.ObtenerDatosHotelPorNombre("moon palace");
        // Debug.Log(hotel.nombreHotel);
    }
}