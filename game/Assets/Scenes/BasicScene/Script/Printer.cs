using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Printer : MonoBehaviour
{

    public XRSocketInteractor socket;
    public Transform paperSpawnTransform;
    public GameObject cardCopyPrefab;

    private void OnEnable()
    {
        if (socket == null)
        {
            Debug.LogError("Socket is not assigned in " + gameObject.name);
            return;
        }

        // Subscribe to events
        socket.selectEntered.AddListener(OnObjectPlaced);
        socket.selectExited.AddListener(OnObjectRemoved);
    }

    private void OnDisable()
    {
        // Unsubscribe from events to prevent memory leaks
        socket.selectEntered.RemoveListener(OnObjectPlaced);
        socket.selectExited.RemoveListener(OnObjectRemoved);
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        if (args.interactableObject != null)
        {
            GameObject cardCopy = Instantiate(cardCopyPrefab, paperSpawnTransform.position, Quaternion.Euler(-90, 0, 90));
            switch (args.interactableObject.transform.name) {
                case "ID Card" :
                    cardCopy.name = "ID Card Copy";
                    break;
                default :
                    break;
            }
        }
    }

    private void OnObjectRemoved(SelectExitEventArgs args) {}
}
