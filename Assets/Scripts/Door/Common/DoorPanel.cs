using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorPanel : MonoBehaviour
{
    public Action<Collider> OnTriggerEnterCallback;
    public Action<Collider> OnTriggerExitCallback;
    public Action OnClickCallback;


    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterCallback?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerExitCallback?.Invoke(other);
    }

    public void OnClick()
    {
        OnClickCallback?.Invoke();
    }
}
