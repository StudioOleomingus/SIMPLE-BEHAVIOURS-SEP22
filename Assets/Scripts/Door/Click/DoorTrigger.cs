using UnityEngine;
using UnityEngine.EventSystems;

namespace Door.Click
{
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public enum State { Close, Open }
        private State state;
        public State DoorState { get { return state; } }

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

        //public void OnPointerClick(PointerEventData eventData)
        //{
        //    if (state == State.Close)
        //    {
        //        OpenDoor();
        //    }
        //    else if (state == State.Open)
        //    {
        //        CloseDoor();
        //    }
        //}
    }
}
