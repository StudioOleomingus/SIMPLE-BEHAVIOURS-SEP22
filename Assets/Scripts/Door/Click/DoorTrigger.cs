using UnityEngine;
using UnityEngine.EventSystems;

namespace Door.Click
{
    public class DoorTrigger : Door
    {
        public enum State { Close, Open }
        private State state;
        public State DoorState { get { return state; } }

        private void OnEnable()
        {
            doorPanel.OnClickCallback += OnClick;
        }

        private void OnDisable()
        {
            doorPanel.OnClickCallback -= OnClick;
        }

        public void OpenDoor()
        {
            animator.Play(Animator.StringToHash("door_open"));
            state = State.Open;
        }

        public void CloseDoor()
        {
            animator.Play(Animator.StringToHash("door_close"));
            state = State.Close;
        }

        public void OnClick()
        {
            Debug.Log("OnClick");
            if (state == State.Close)
            {
                Debug.Log("Door Close");
                OpenDoor();
            }
            else if (state == State.Open)
            {
                Debug.Log("Door Open");
                CloseDoor();
            }
        }
    }
}
