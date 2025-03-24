using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Printer : MonoBehaviour
{

    public XRSocketInteractor socket;
    public Transform paperSpawnTransform;
    public List<GameObject> cards = new List<GameObject>();
    public List<GameObject> cardCopies = new List<GameObject>();

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
            GameObject cardCopy;
            for (int i = 0; i < cards.Count; i++){
                if (args.interactableObject.GetType() == cards[i].GetType()){
                    cardCopy = Instantiate(cardCopies[i], paperSpawnTransform.position, Quaternion.Euler(-90, 0, 90));
                    cardCopy.name = "copie - " + args.interactableObject.transform.name;
                    return;
                }
            }
        }
    }

    private void OnObjectRemoved(SelectExitEventArgs args) {}
}
