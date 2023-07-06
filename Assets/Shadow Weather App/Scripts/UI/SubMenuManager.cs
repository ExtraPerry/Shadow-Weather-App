using System;
using UnityEngine;

namespace ExtraPerry.Shadow.WeatherApp.UI
{
    public class SubMenuManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject mainMenu;
        [SerializeField]
        private GameObject settingsMenu;

        public void TriggerMenuChange(int value)
        {
            MenuType choice = (MenuType)value;
            if (choice == MenuType.Main)
            {
                mainMenu.SetActive(true);
                settingsMenu.SetActive(false);
            }
            else
            {
                mainMenu.SetActive(false);
                settingsMenu.SetActive(true);
            }
        }
    }

    [Serializable]
    public enum MenuType
    {
        Main,
        Settings
    }
}