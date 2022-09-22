using UnityEngine;

namespace Door.Automatic
{
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                animator.Play(Animator.StringToHash("door_open"));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                animator.Play(Animator.StringToHash("door_close"));
            }
        }
    }
}
