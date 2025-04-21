using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class PaperballDialog : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public AudioSource audioSource;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        audioSource = GetComponent<AudioSource>();

        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (!SharedGrabState.HasBeenGrabbed && audioSource != null)
        {
            SharedGrabState.HasBeenGrabbed = true;
            audioSource.Play();
        }
    }
}
