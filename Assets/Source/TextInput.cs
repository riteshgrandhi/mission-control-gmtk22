using Assets.Source.Core.EventData;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextInput : MonoBehaviour
{
    private TextMeshProUGUI m_textMeshComponent;
    private TMPro.TextMeshProUGUI TextMeshComponent
    {
        get
        {
            if (m_textMeshComponent == null) m_textMeshComponent = GetComponent<TextMeshProUGUI>();

            return m_textMeshComponent;
        }
    }

    // This function is called when the object becomes enabled and active
    private void OnEnable()
    {
        EventManager.OnMissionButtonClick += OnMissionButtonClick;
    }

    private void OnDisable()
    {
        EventManager.OnMissionButtonClick -= OnMissionButtonClick;
    }



    private void OnMissionButtonClick(MissionButtonClickData missionButtonClickData)
    {
        TextMeshComponent.text += missionButtonClickData.Value;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
