using Assets.Source.Core.EventData;
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
}
