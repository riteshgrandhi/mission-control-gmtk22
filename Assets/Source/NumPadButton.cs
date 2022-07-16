using Assets.Source.Core.EventData;
using UnityEngine;

namespace Assets.Source
{
    [RequireComponent(typeof(Collider2D))]
    public class NumPadButton : MonoBehaviour
    {
        [SerializeField]
        public byte value = 1;

        // OnMouseUpAsButton is only called when the mouse is released over the same GUIElement or Collider as it was pressed
        private void OnMouseUpAsButton()
        {
            EventManager.OnNumPadButtonClickEvent(new NumPadButtonClickData(this.gameObject, Input.mousePosition, this.value));
        }
    }
}