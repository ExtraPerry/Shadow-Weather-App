using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;

namespace ExtraPerry.Shadow.WeatherApp.UI
{
    public class TextInputKeyboardManager : MonoBehaviour
    {
        private TMP_InputField inputField;

        [SerializeField]
        private float distance = 0.5f;
        [SerializeField]
        private float verticalOffset = -0.25f;

        public Transform positionSource;

        private void Start()
        {
            inputField = GetComponent<TMP_InputField>();
            inputField.onSelect.AddListener(x => OpenKeyboard());
        }

        public void OpenKeyboard()
        {
            NonNativeKeyboard.Instance.InputField = inputField;
            NonNativeKeyboard.Instance.PresentKeyboard(inputField.text);

            Vector3 direction = positionSource.forward;
            direction.y = 0;
            direction.Normalize();

            Vector3 targetPosition = positionSource.position + (direction * distance) + (Vector3.up * verticalOffset);
            NonNativeKeyboard.Instance.RepositionKeyboard(targetPosition);

            SetCaretColorAlpha(1);

            NonNativeKeyboard.Instance.OnClosed += Instance_OnClosed;
        }

        private void Instance_OnClosed(object sender, System.EventArgs e)
        {
            SetCaretColorAlpha(0);
            NonNativeKeyboard.Instance.OnClosed -= Instance_OnClosed;
        }

        public void SetCaretColorAlpha(float value)
        {
            inputField.customCaretColor = true;
            Color caretColor = inputField.caretColor;
            caretColor.a = value;
            inputField.caretColor = caretColor;
        }
    }
}
