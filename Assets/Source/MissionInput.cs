using Assets.Source.Core.EventData;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

namespace Assets.Source
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class MissionInput : MonoBehaviour
    {
        private static readonly string MISSION_NAME_EXTRACT_PATTERN = @"MISSION: ([A-Z ]*)";
        private static readonly string OBJECTIVE_EXTRACT_PATTERN = @"OBJECTIVE: ([A-Z ]*)";

        private static readonly string CODEWORD_EXTRACT_PATTERN = @"->\t([A-Z]*):\t_\t<-";
        private static readonly string UNDERSCORE = "_";
        private static readonly Regex PLACEHOLDER_REGEX = new(Regex.Escape(UNDERSCORE));

        private string missionName;
        [NonSerialized]
        public MissionObjective missionObjective;
        private readonly Dictionary<string, byte> codewordToCipherMap = new();
        private readonly Dictionary<byte, string> cipherToCodewordMap = new();
        private TextMeshProUGUI _textMeshComponent;
        private TextMeshProUGUI TextMeshComponent
        {
            get
            {
                if (_textMeshComponent == null) _textMeshComponent = GetComponent<TextMeshProUGUI>();
                return _textMeshComponent;
            }
        }

        private void Awake()
        {
            missionName = Regex.Match(TextMeshComponent.text, MISSION_NAME_EXTRACT_PATTERN).Groups[1].Value;
            Enum.TryParse(Regex.Match(TextMeshComponent.text, OBJECTIVE_EXTRACT_PATTERN).Groups[1].Value, out missionObjective);
        }

        // This function is called when the object becomes enabled and active
        private void OnEnable()
        {
            EventManager.OnRollDiceDone += OnRollDiceDone;
        }

        private void OnDisable()
        {
            EventManager.OnRollDiceDone -= OnRollDiceDone;
        }

        private void OnRollDiceDone(RolledDiceData rolledDiceData)
        {
            if (TextMeshComponent.text.Contains(UNDERSCORE))
            {
                if (!cipherToCodewordMap.ContainsKey(rolledDiceData.Value))
                {
                    Match m = Regex.Match(this.TextMeshComponent.text, CODEWORD_EXTRACT_PATTERN);
                    string codeword = m.Groups[1].Value;
                    cipherToCodewordMap.Add(rolledDiceData.Value, codeword);
                    codewordToCipherMap.Add(codeword, rolledDiceData.Value);
                    TextMeshComponent.text = PLACEHOLDER_REGEX.Replace(TextMeshComponent.text, rolledDiceData.Value.ToString(), 1);

                    if (!TextMeshComponent.text.Contains(UNDERSCORE))
                    {
                        Debug.Log("Input is Done");
                        EventManager.OnCipherInputDoneEvent(new MissionInputData(missionName, missionObjective, cipherToCodewordMap, codewordToCipherMap));
                    }
                }
                else
                {
                    Debug.Log("Try Again!");
                }
            }
        }
    }
}