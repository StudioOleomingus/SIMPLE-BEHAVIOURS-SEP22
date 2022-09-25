using UnityEngine;

namespace Door.Automatic
{
    public class DoorTrigger : Door
    {
        [SerializeField] private GameObject doorMessage;
        [SerializeField] private bool hasKey;

        public enum State { Close, Open }
        private State state;
        public State DoorState { get { return state; } }

        [SerializeField] private DoorController doorController;

        private void OnEnable()
        {
            if(doorController) doorController.OnPickKey += OnPickKey;
            doorPanel.OnTriggerEnterCallback += OnTriggerEnterCallback;
            doorPanel.OnTriggerExitCallback += OnTriggerExitCallback;
        }

        private void OnDisable()
        {
            if (doorController) doorController.OnPickKey -= OnPickKey;
            doorPanel.OnTriggerEnterCallback -= OnTriggerEnterCallback;
            doorPanel.OnTriggerExitCallback -= OnTriggerExitCallback;
        }

        private void OnTriggerEnterCallback(Collider other)
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

        private void OnTriggerExitCallback(Collider other)
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
                    animator.Play(Animator.StringToHash("door_close"));
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
