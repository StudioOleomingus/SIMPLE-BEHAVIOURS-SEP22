using UnityEngine;

namespace Door.Automatic
{
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject doorMessage;
        [SerializeField] private bool hasKey;

        public enum State { Close, Open }
        private State state;
        public State DoorState { get { return state; } }

        [SerializeField] private DoorController doorController;

        private void OnEnable()
        {
            doorController.OnPickKey += OnPickKey;
        }

        private void OnDisable()
        {
            doorController.OnPickKey -= OnPickKey;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (doorMessage)
            {
                if (hasKey)
                {
                    if (other.CompareTag("Player"))
                    {
                        animator.Play(Animator.StringToHash("door_open"));
                        state = State.Open;
                    }
                }
                else
                {
                    doorMessage.SetActive(true);
                }
            }
            else
            {
                if (other.CompareTag("Player"))
                {
                    animator.Play(Animator.StringToHash("door_open"));
                    state = State.Open;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (doorMessage)
            {
                doorMessage.SetActive(false);
                if (other.CompareTag("Player") && state == State.Open)
                {
                    animator.Play(Animator.StringToHash("door_close"));
                    state = State.Close;
                }
            }
            else
            {
                if (other.CompareTag("Player") && state == State.Open)
                {
                    animator.Play(Animator.StringToHash("door_open"));
                    state = State.Close;
                }
            }
            
        }

        void OnPickKey()
        {
            hasKey = true;
        }
    }
}
