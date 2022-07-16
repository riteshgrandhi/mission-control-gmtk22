using UnityEngine;

namespace Assets.Source
{
    [RequireComponent(typeof(Collider2D))]
    public class NumPadClearButton : MonoBehaviour
    {
        // OnMouseUpAsButton is only called when the mouse is released over the same GUIElement or Collider as it was pressed
        private void OnMouseUpAsButton()
        {
            EventManager.OnNumPadClearEvent();
        }
    }
}