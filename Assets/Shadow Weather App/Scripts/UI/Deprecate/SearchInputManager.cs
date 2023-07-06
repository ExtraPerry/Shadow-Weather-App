using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using ExtraPerry.Shadow.WeatherApp.Synced;
using ExtraPerry.Shadow.WeatherApp.Event;
using ExtraPerry.Shadow.WeatherApp.API;
using ExtraPerry.Shadow.WeatherApp.API.SO;
using ExtraPerry.Shadow.WeatherApp.API.Model;
using static Microsoft.MixedReality.Toolkit.Experimental.UI.KeyboardKeyFunc;

namespace ExtraPerry.Shadow.WeatherApp.UI
{
    public class SearchInputManager : UpdatableMono
    {
        private TMP_InputField inputField;
        [SerializeField]
        private TMP_Dropdown dropdown;
        [SerializeField]
        private SyncedString targetCity;
        [SerializeField]
        private SearchAutocompleteInfo searchAutoInfo;
        [SerializeField]
        private CustomEvent requestSearch;
        [SerializeField]
        private CustomEvent triggerApiTimer;

        private string oldTextInput;
        private string[] currentDropDownContext;

        private void Start()
        {
            inputField = GetComponent<TMP_InputField>();
            oldTextInput = inputField.text;
        }

        public override void TriggerUpdate(Component sender, object data)
        {
            if (sender is Timer) TimerTrigger();

            if (sender is KeyboardKeyFunc && data is Function) EnterOrCloseKeyPressed((Function)data);

            if (sender is SearchAutocompleteRequester) TriggerUpdate();
        }

        public override void TriggerUpdate()
        {
            List<SearchAutocomplete> data = searchAutoInfo.data;
            if (data.Count == 0)
            {
                Debug.Log("Search Autocomplete result is empty.");
                return;
            }

            List<string> options = new List<string>();
            foreach (SearchAutocomplete searchAuto in data)
            {
                options.Add(searchAuto.name);
            }
            currentDropDownContext = options.ToArray();
            dropdown.ClearOptions();
            dropdown.AddOptions(options);
            dropdown.Show();
            Debug.Log("Search Autocomplete Dropdown showing options.");
        }

        private void TimerTrigger()
        {
            string input = inputField.text;
            Debug.Log("Current : " + input + "| Old : " + oldTextInput);
            if (!input.Equals(oldTextInput))
            {
                requestSearch.Raise(this, input);
                oldTextInput = input;
                Debug.Log("Sent a request for Autocomplete suggestion => " + input);
                return;
            }
            Debug.Log("No change in search input.");
        }

        private void EnterOrCloseKeyPressed(Function data)
        {
            dropdown.Hide();
            if (data == Function.Close) inputField.text = "";
            if (data == Function.Enter) UpdateCityString(inputField.text);
        }

        public void OnDropdownSubmit()
        {
            int index = dropdown.value;
            dropdown.Hide();
            string input = currentDropDownContext[index];
            inputField.text = input;
            UpdateCityString(input);
        }

        private void UpdateCityString(string input)
        {
            targetCity.value = input;
            triggerApiTimer.Raise(this);
        }
    }
}