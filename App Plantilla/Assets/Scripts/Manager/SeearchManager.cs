
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class SeearchManager : MonoBehaviour
{

    public GameObject ContentHolder;

    public GameObject[] Element;

    public GameObject SearchBar;

    public int totalElements;
    

    private void Start()
    {
        totalElements = ContentHolder.transform.childCount;
        Element = new GameObject[totalElements];

        for (int i = 0; i < totalElements; i++)
        {
            Element[i] = ContentHolder.transform.GetChild(i).gameObject;
        }
    }

    public void Buscar()
    {
        string _searchText = SearchBar.GetComponent<TMP_InputField>().text;
        int _searchTxtlenght = _searchText.Length;


        int searchedElements = 0;

        foreach (var element in Element)
        {
            searchedElements += 1;

            if (element.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Length >= _searchTxtlenght)
            {
                if (_searchText.ToLower() == element.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
                        .Substring(0, _searchTxtlenght).ToLower())
                {
                    element.SetActive(true);
                }
                else
                {
                    element.SetActive(false);
                }
            }
        }
    }
}
