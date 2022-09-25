using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Transform m_camera;

    private RaycastHit hit;
    private Ray ray;

    public System.Action OnPickKey;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnFire(InputValue value)
    {
        OnClick_LeftMouseButton();
    }

    public void OnClick_LeftMouseButton()
    {
        ray = new Ray(m_camera.position, m_camera.forward);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Door"))
            {
                hit.collider.GetComponent<DoorPanel>().OnClick();
            }
            else if (hit.collider.CompareTag("Key"))
            {
                OnPickKey?.Invoke();
                hit.collider.gameObject.SetActive(false);
            }
        }

    }
}
