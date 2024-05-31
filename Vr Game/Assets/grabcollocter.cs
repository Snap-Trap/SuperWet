using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class grabcollocter : MonoBehaviour
{
    public delegate void ObjectGrabbedHandler();
    public static event ObjectGrabbedHandler OnObjectGrabbed;

    private bool isGrabbed = false;

    private void OnEnable()
    {
        // Subscribe to grab event from XRGrabInteractable or your custom grab logic
        var grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
        }
    }

    private void OnDisable()
    {
        // Unsubscribe from grab event
        var grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (!isGrabbed)
        {
            isGrabbed = true;
            OnObjectGrabbed?.Invoke();
        }
    }
}
