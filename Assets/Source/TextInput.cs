using Assets.Source.Core.EventData;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

namespace Assets.Source
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextInput : MonoBehaviour
    {
        private static readonly string DEFAULT_TEXT = "__|__";
        private static readonly string UNDERSCORE = "_";
        private static readonly Regex PLACEHOLDER_REGEX = new(Regex.Escape(UNDERSCORE));
        private TextMeshProUGUI _textMeshComponent;
        private TextMeshProUGUI TextMeshComponent
        {
            get
            {
                if (_textMeshComponent == null) _textMeshComponent = GetComponent<TextMeshProUGUI>();
                return _textMeshComponent;
            }
        }

        // This function is called when the object becomes enabled and active
        private void OnEnable()
        {
            EventManager.OnNumPadButtonClick += OnNumPadButtonClick;
            EventManager.OnNumPadClear += OnNumPadClear;
        }

        private void OnDisable()
        {
            EventManager.OnNumPadButtonClick -= OnNumPadButtonClick;
            EventManager.OnNumPadClear -= OnNumPadClear;
        }

        private void OnNumPadButtonClick(NumPadButtonClickData missionButtonClickData)
        {
            if (TextMeshComponent.text.Contains(UNDERSCORE))
            {
                TextMeshComponent.text = PLACEHOLDER_REGEX.Replace(TextMeshComponent.text, missionButtonClickData.Value.ToString(), 1);
            }
        }

        private void OnNumPadClear()
        {
            TextMeshComponent.text = DEFAULT_TEXT;
        }
    }
}