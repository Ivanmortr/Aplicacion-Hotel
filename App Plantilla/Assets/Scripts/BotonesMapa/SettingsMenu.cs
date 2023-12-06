using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Espacio entre elementos del menú")] [SerializeField]
    private Vector2 spacing;

    [Space] [Header("Boton principal Rotación")] [SerializeField]
    private float rotationDuration;

    [SerializeField] private Ease rotationEase;

    [Space] [Header("Animación")] [SerializeField]
    private float expandDuration;

    [SerializeField] private float collapseDuration;
    [SerializeField] private Ease expandEase;
    [SerializeField] private Ease collapseEase;

    [Space] [Header("Fading")] [SerializeField]
    private float expandFadeDuration;

    [SerializeField] private float collapseFadeDuration;


    private Button mainButton;
    private SettingsMenuItem[] _menuItems;
    private bool isExpanded = false;

    private Vector2 mainButtonPosition;
    private int _itemsCount;

    private void Start()
    {
        _itemsCount = transform.childCount - 1;
        _menuItems = new SettingsMenuItem[_itemsCount];
        for (int i = 0; i < _itemsCount; i++)
        {
            _menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingsMenuItem>();
        }

        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();
        mainButtonPosition = mainButton.transform.position;

        ResetPositions();
    }

    private void ResetPositions()
    {
        for (int i = 0; i < _itemsCount; i++)
        {
            _menuItems[i].trans.position = mainButtonPosition;
            _menuItems[i].img.DOFade(0f, 0f);
        }
    }

    private void ToggleMenu()
    {
        isExpanded = !isExpanded;
        if (isExpanded)
        {
            for (int i = 0; i < _itemsCount; i++)
            {
                // _menuItems[i].trans.position = mainButtonPosition + spacing * (i + 1);
                _menuItems[i].trans.DOMove(mainButtonPosition + spacing * (i + 1), expandDuration).SetEase(expandEase);
                _menuItems[i].img.DOFade(1f, expandFadeDuration).From(0f);
            }
        }
        else
        {
            for (int i = 0; i < _itemsCount; i++)
            {
                // _menuItems[i].trans.position = mainButtonPosition;
                _menuItems[i].trans.DOMove(mainButtonPosition, collapseDuration).SetEase(collapseEase);
                _menuItems[i].img.DOFade(0f, collapseFadeDuration);
            }
        }

        Debug.Log("Entrando");
        mainButton.transform.DORotate(Vector3.forward * 90f, rotationDuration).From(Vector3.zero)
            .SetEase(rotationEase);
    }

    public void OnItemClick(int index)
    {
        switch (index)
        {
            case 0:
                Debug.Log("Soy el 1 boton");
                break;
            case 1:
                Debug.Log("Soy el 2 boton");

                break;
            case 2:
                Debug.Log("Soy el 3 boton");

                break;
        }
    }

    private void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }
}