using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRGrabTracker : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private bool isGrabbed = false;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to grab events
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
    }

    public bool IsCurrentlyGrabbed()
    {
        return isGrabbed;
    }
}
