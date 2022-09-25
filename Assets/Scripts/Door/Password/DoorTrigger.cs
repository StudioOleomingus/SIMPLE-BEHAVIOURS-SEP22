using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;

namespace Door.Password
{
    public class DoorTrigger : Door
    {
        [SerializeField] private GameObject doorMessage;
        [SerializeField] private TMP_InputField passwordInputfield;
        [SerializeField] private string doorPassword;
        [SerializeField] private bool hasKey;
        [SerializeField] private Button confirmButton;
        [SerializeField] private Button closeButton;

        public enum State { Close, Open }
        private State state;
        public State DoorState { get { return state; } }

        [SerializeField] private DoorController doorController;

        private void OnEnable()
        {
            //if (doorController) doorController.OnPickKey += OnPickKey;
            doorPanel.OnTriggerEnterCallback += OnTriggerEnterCallback;
            doorPanel.OnTriggerExitCallback += OnTriggerExitCallback;
            confirmButton.onClick.AddListener(OnClick_ConfirmPassword);
            closeButton.onClick.AddListener(OnClick_CloseButton);
        }

        private void OnDisable()
        {
            //if (doorController) doorController.OnPickKey -= OnPickKey;
            doorPanel.OnTriggerEnterCallback -= OnTriggerEnterCallback;
            doorPanel.OnTriggerExitCallback -= OnTriggerExitCallback;
        }

        private void OnTriggerEnterCallback(Collider other)
        {
            if (doorMessage)
            {
                //if (hasKey)
                //{
                //    if (other.CompareTag("Player"))
                //    {
                //        animator.Play(Animator.StringToHash("door_open"));
                //        state = State.Open;
                //    }
                //}
                //else
                //{

                //}
                doorMessage.SetActive(true);
                other.GetComponent<FirstPersonController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
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
            if (other.CompareTag("Player") && state == State.Open)
            {
                animator.Play(Animator.StringToHash("door_close"));
                state = State.Close;
            }
        }

        //void OnPickKey()
        //{
        //    hasKey = true;
        //}

        public void OnClick_ConfirmPassword()
        {
            if (passwordInputfield.text.Equals(doorPassword))
            {
                animator.Play(Animator.StringToHash("door_open"));
                state = State.Open;
                doorMessage.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        public void OnClick_CloseButton()
        {
            doorMessage.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}