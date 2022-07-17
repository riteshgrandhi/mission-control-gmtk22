using Assets.Source.Core.EventData;
using System;
using UnityEngine;

public static class EventManager
{
    public delegate void OnNumPadButtonClickDelegate(NumPadButtonClickData missionButtonClickData);
    public static event OnNumPadButtonClickDelegate OnNumPadButtonClick;
    public static void OnNumPadButtonClickEvent(NumPadButtonClickData missionButtonClickData)
    {
        if (OnNumPadButtonClick == null)
        {
            Debug.LogWarning("Event has no subscribers");
            return;
        }

        OnNumPadButtonClick(missionButtonClickData);
    }

    internal static void OnMissionTaskDoneEvent(MissionTaskDoneData missionTaskDoneData)
    {
        throw new NotImplementedException();
    }

    public delegate void OnNumPadClearDelegate();
    public static event OnNumPadClearDelegate OnNumPadClear;
    public static void OnNumPadClearEvent()
    {
        if (OnNumPadClear == null)
        {
            Debug.LogWarning("Event has no subscribers");
            return;
        }

        OnNumPadClear();
    }

    public delegate void OnRollDiceDelegate();
    public static event OnRollDiceDelegate OnRollDice;
    public static void OnRollDiceEvent()
    {
        if (OnRollDice == null)
        {
            Debug.LogWarning("Event has no subscribers");
            return;
        }

        OnRollDice();
    }

    public delegate void OnRollDiceDoneDelegate(RolledDiceData rolledDiceData);
    public static event OnRollDiceDoneDelegate OnRollDiceDone;
    public static void OnRollDiceDoneEvent(RolledDiceData rolledDiceData)
    {
        if (OnRollDiceDone == null)
        {
            Debug.LogWarning("Event has no subscribers");
            return;
        }

        OnRollDiceDone(rolledDiceData);
    }

    public delegate void OnCipherInputDoneDelegate(MissionInputData missionInputData);
    public static event OnCipherInputDoneDelegate OnCipherInputDone;
    public static void OnCipherInputDoneEvent(MissionInputData missionInputData)
    {
        if (OnCipherInputDone == null)
        {
            Debug.LogWarning("Event has no subscribers");
            return;
        }

        OnCipherInputDone(missionInputData);
    }
}
