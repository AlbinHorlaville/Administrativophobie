using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.InputSystem.Utilities;

public class ValidDocument : MonoBehaviour
{
    public List<TextMeshPro> textMeshMap = new List<TextMeshPro>();
    private List<int> papers = new List<int>() { };
    public TextMeshPro tampon;
    public TextMeshPro titre;
    public XRSocketInteractor socket;
    public AudioSource failSound;
    public AudioSource successSound;

    // Create a Dictionary with paper interactable object name as the key, and their index in the textMeshMap as the value
    private Dictionary<string, int> paperMap = new Dictionary<string, int>() {
        { "ID Card Copy", 0 },
        { "Vital Card Copy", 1 },
        { "Driving License Copy", 2 },
        { "Swimming Pool Card Copy", 3 },
        { "Fidelity Card Copy", 4 }
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ajouter (changer en random) des papiers a valider pour ce document
        for (int i = 0; i < textMeshMap.Count; i++)
        {
            int prob = Random.Range(0, 100);
            if (prob > 60 || (i == textMeshMap.Count-1 && papers.Count == 0))
            { // La probabilité qu'un papier soit ajouté a la liste du document
                papers.Add(i);
            }
        }

        int indicePapersIncluded = 1;
        // Placer les TextMeshPro aux bons endroits
        for (int i = 0; i < textMeshMap.Count; i++)
        {
            if (papers.Contains(i))
            {
                Vector3 pos = textMeshMap[i].transform.localPosition;
                Quaternion rot = textMeshMap[i].transform.localRotation;
                Vector3 incr = new Vector3(0, -0.003f * indicePapersIncluded, 0);
                textMeshMap[i].transform.SetLocalPositionAndRotation(pos + incr, rot);
                indicePapersIncluded += 1;
            }
            else
            {
                textMeshMap[i].enabled = false;
            }
        }

        // Désactiver le tampon de validation
        tampon.enabled = false;

        // Subscribe to events
        socket.selectEntered.AddListener(OnObjectPlaced);
    }

    // Update is called once per frame
    void Update() {}

    bool ValidatePaper(int index){
        if (!papers.Contains(index)){
            return false;
        }
        papers.Remove(index);
        textMeshMap[index].color = new Color(0, 0.5f, 0);

        return true;
    }

    void Tamponner(){
        if (papers.Count == 0){
            tampon.enabled = true;
        }
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        if (args.interactableObject != null)
        {
            idCard component = args.interactableObject.transform.GetComponent<idCard>();
            if (component != null){
                bool isValid = ValidatePaper(component.id);
                if (isValid)
                {
                    successSound.Play();
                    Destroy(args.interactableObject.transform.gameObject);
                }
                else
                {
                    failSound.Play();
                    XRGrabInteractable interactable = socket.GetOldestInteractableSelected() as XRGrabInteractable;
                    socket.interactionManager.SelectExit(socket, socket.GetOldestInteractableSelected());
                    Rigidbody rb = interactable.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = false; // Ensure physics affects it

                        Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
                        Vector3 direction = directions[Random.Range(0, directions.Length)];

                        rb.AddForce((Vector3.up + direction) * 2.0f, ForceMode.Impulse);
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stamp" && transform.position.y < collision.transform.position.y)
        {
            Tamponner();
        }
    }

    public string GetInvalidReason()
    {
        string reason = "";
        if (papers.Count > 0)
        {
            reason = "document";
        }
        else if (tampon.enabled == false)
        {
            reason = "tampon";
        }

        return reason;
    }
}
