
using UnityEngine;

public class GeneradorLinea : MonoBehaviour
{
    [SerializeField] private GameObject _lineaPrefab;

    private Linea _activeLine;
   
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var nuevaLinea = Instantiate(_lineaPrefab);
            _activeLine = nuevaLinea.GetComponent<Linea>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _activeLine = null;
        }

        if (_activeLine != null)
        {
            Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            
            _activeLine.ActualizarLinea(mousePos);
        }
    }
}