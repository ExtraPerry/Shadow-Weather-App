using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using ExtraPerry.Shadow.WeatherApp.Synced;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using ExtraPerry.Shadow.WeatherApp.Event;

namespace ExtraPerry.Shadow.WeatherApp.UI
{
    public class ApiKeyInputManager : UpdatableMono
    {
        [SerializeField]
        private SyncedString defaultApiKey;
        [SerializeField]
        private SyncedString currentApiKey;
        [SerializeField]
        private CustomEvent triggerApiTimer;
        [SerializeField]
        TMP_InputField inputField;
        [SerializeField]
        TMP_Text keyInfo;
        [SerializeField]
        TMP_Text keyStatus;

        [HideInInspector]
        public bool isContext;

        private bool isKeyValid;

        private void Start()
        {
            StartCoroutine(TestApiKeyInput());
        }

        public override void TriggerUpdate(Component sender, object data)
        {
            if (sender is KeyboardKeyFunc) TriggerUpdate();
        }

        public override void TriggerUpdate()
        {
            if (!isContext) return;

            SetKeyToCustom(inputField.text);
            isContext = false;
        }

        public void OnIsContext()
        {
            isContext = true;
        }

        private void SetKeyToCustom(string input)
        {
            if (currentApiKey.value.Equals(input) || !isContext) return;

            currentApiKey.value = input;
            keyInfo.text = "Current API Key : " + input;

            StartCoroutine(TestApiKeyInput());
        }

        public void SetKeyToDefault()
        {
            if (currentApiKey.value.Equals(defaultApiKey.value)) return;

            currentApiKey.value = defaultApiKey.value;
            keyInfo.text = "Current API Key : Default";

            StartCoroutine(TestApiKeyInput());
        }

        private void UpdateKeyStatus()
        {
            if (isKeyValid)
            {
                keyStatus.text = "Key is Valid";
                keyStatus.color = new Color(0, 1, 0, 1);
                inputField.text = "";
                triggerApiTimer.Raise(this);
            }
            else
            {
                keyStatus.text = "Key is Invalid";
                keyStatus.color = new Color(1, 0, 0, 1);
            }
        }

        private IEnumerator TestApiKeyInput()
        {
            keyStatus.color = new Color(1, 1, 1, 1);
            keyStatus.text = "Checking key status ... ";

            var response = new UnityWebRequest("http://api.weatherapi.com/v1/timezone.json?key=" + currentApiKey + "&q=Paris")
            {
                downloadHandler = new DownloadHandlerBuffer()
            };
            yield return response.SendWebRequest();

            isKeyValid = false;
            if (response.result == UnityWebRequest.Result.Success)
            {
                isKeyValid = true;
            }

            UpdateKeyStatus();
        }
    }
}
