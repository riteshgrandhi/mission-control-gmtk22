using UnityEngine;

namespace Assets.Source.Core.EventData
{
    public class NumPadButtonClickData
    {
        public GameObject ClickedGameObject { get; }
        public Vector2 MousePosition { get; }
        public byte Value { get; }

        public NumPadButtonClickData(GameObject clickedGameObject, Vector2 mousePosition, byte value)
        {
            ClickedGameObject = clickedGameObject;
            MousePosition = mousePosition;
            Value = value;
        }
    }
}
