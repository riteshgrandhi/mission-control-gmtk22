using UnityEngine;

namespace Assets.Source.Core.EventData
{
    public class MissionButtonClickData
    {
        public GameObject ClickedGameObject { get; }
        public Vector2 MousePosition { get; }
        public string Value { get; }

        public MissionButtonClickData(GameObject clickedGameObject, Vector2 mousePosition, string value)
        {
            ClickedGameObject = clickedGameObject;
            MousePosition = mousePosition;
            Value = value;
        }
    }
}
