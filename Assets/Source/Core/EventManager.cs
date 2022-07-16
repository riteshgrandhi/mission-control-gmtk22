using Assets.Source.Core.EventData;
using UnityEngine;

public static class EventManager
{
    public delegate void OnMissionButtonClickDelegate(MissionButtonClickData missionButtonClickData);
    public static event OnMissionButtonClickDelegate OnMissionButtonClick;
    public static void OnMissionButtonClickEvent(MissionButtonClickData missionButtonClickData)
    {
        if (OnMissionButtonClick == null)
        {
            Debug.LogWarning("Event has no subscribers");
            return;
        }

        OnMissionButtonClick(missionButtonClickData);
    }
}
