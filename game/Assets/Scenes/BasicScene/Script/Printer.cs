using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Printer : MonoBehaviour
{

    public XRSocketInteractor socket;
    public Transform paperSpawnTransform;
    public List<GameObject> cardCopies = new List<GameObject>();
    public AudioSource bruitImpression;
    public Telemetry telemetry;

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
    StartCoroutine(DelayedObjectPlacement(7f)); // Lance un timer de 7 secondes
}

private IEnumerator DelayedObjectPlacement(float delay)
{
    bruitImpression.Play();
    idCard component = socket.GetOldestInteractableSelected().transform.GetComponent<idCard>();
    yield return new WaitForSeconds(delay);

    if (component != null)
    {
        GameObject o = Instantiate(cardCopies[component.id], paperSpawnTransform.position, Quaternion.Euler(-90, 0, 90));
    }

    telemetry.PrintPaper();
}

    private void OnObjectRemoved(SelectExitEventArgs args) {}
}
