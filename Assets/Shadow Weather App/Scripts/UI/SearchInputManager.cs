using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ExtraPerry.Shadow.WeatherApp.Synced;
using ExtraPerry.Shadow.WeatherApp.Event;
using ExtraPerry.Shadow.WeatherApp.API;
using ExtraPerry.Shadow.WeatherApp.API.SO;
using ExtraPerry.Shadow.WeatherApp.API.Model;

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
        private bool isReadyToRequest;

        private string[] currentDropDownContext;

        private void Start()
        {
            inputField = GetComponent<TMP_InputField>();
        }

        public override void TriggerUpdate(Component sender, object data)
        {
            if (sender is Timer) isReadyToRequest = true;

            if (sender is SearchAutocompleteRequester) TriggerUpdate();
        }

        public override void TriggerUpdate()
        {
            List<SearchAutocomplete> data = searchAutoInfo.data;
            if (data.Count == 0) return;

            dropdown.ClearOptions();
            List<string> options = new List<string>();
            foreach (SearchAutocomplete searchAuto in data)
            {
                options.Add(searchAuto.name);
            }
            dropdown.AddOptions(options);
            currentDropDownContext = options.ToArray();
            dropdown.Show();
        }

        public void ResetRequestTimeout()
        {
            if (isReadyToRequest) return;
            isReadyToRequest = true;
        }

        public void OnValueChanged(string input)
        {
            if (!isReadyToRequest) return;
            isReadyToRequest = false;
            requestSearch.Raise(this, input);
        }

        public void OnTextSubmit(string input)
        {
            if (inputField.wasCanceled) return;
            dropdown.Hide();
            targetCity.value = input;
        }

        public void OnDropdownSubmit(int index)
        {
            dropdown.Hide();
            string input = currentDropDownContext[index];
            inputField.text = input;
            targetCity.value = input;
            triggerApiTimer.Raise(this);
        }
    }
}