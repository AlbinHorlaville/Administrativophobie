using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Printer : MonoBehaviour
{

    public XRSocketInteractor socket;
    public Transform paperSpawnTransform;
    public List<GameObject> cardCopies = new List<GameObject>();
    public AudioSource bruitImpression;

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
        StartCoroutine(DelayedObjectPlacement(args, 7f)); // Lance un timer de 5 secondes
    }
}

private IEnumerator DelayedObjectPlacement(SelectEnterEventArgs args, float delay)
{
    bruitImpression.Play();
    yield return new WaitForSeconds(delay);

    if (args.interactableObject != null)
    {
        idCard component = args.interactableObject.transform.GetComponent<idCard>();
        if (component != null)
        {
            GameObject o = Instantiate(cardCopies[component.id], paperSpawnTransform.position, Quaternion.Euler(-90, 0, 90));
            Debug.Log(o.name);
        }
    }
}

    private void OnObjectRemoved(SelectExitEventArgs args) {}
}
