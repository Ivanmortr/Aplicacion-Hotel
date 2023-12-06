using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuItem : MonoBehaviour
{
   [HideInInspector] public Image img;
   [HideInInspector] public Transform trans;

   private SettingsMenu _settingsMenu;
   private int _index;
   private Button _button;
   private void Awake()
   {
      img = GetComponent<Image>();
      trans = transform;

      _settingsMenu = transform.parent.GetComponent<SettingsMenu>();
      _index = trans.GetSiblingIndex() - 1;

      _button = GetComponent<Button>();
      _button.onClick.AddListener(OnItemClick);

   }

   private void OnItemClick()
   {
      _settingsMenu.OnItemClick(_index);
   }

   private void OnDestroy()
   {
      _button.onClick.RemoveListener(OnItemClick);
   }
}
