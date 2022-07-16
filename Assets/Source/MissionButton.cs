using Assets.Source.Core.EventData;
using UnityEngine;

namespace Assets.Source
{
    [RequireComponent(typeof(Collider2D))]
    public class MissionButton : MonoBehaviour
    {
        [SerializeField]
        public string value = "1";
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        // OnMouseUpAsButton is only called when the mouse is released over the same GUIElement or Collider as it was pressed
        private void OnMouseUpAsButton()
        {
            EventManager.OnMissionButtonClickEvent(new MissionButtonClickData(this.gameObject, Input.mousePosition, this.value));
        }
    }
}