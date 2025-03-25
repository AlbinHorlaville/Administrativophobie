using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Logic : MonoBehaviour
{

    public int score = 0;
    public TextMeshPro scoreMesh;
    public InputActionReference makeABallAction;
    public XRBaseInteractor interactor;
    public GameObject BouleDePapier;

    void Awake()
    {
        makeABallAction.action.Enable();
        makeABallAction.action.performed += MakeABall;
    }

    private void MakeABall(InputAction.CallbackContext context)
    {
        if (!interactor.hasSelection){
            return;
        }

        GameObject heldObject = interactor.GetOldestInteractableSelected().transform.gameObject;
        if (heldObject.name.Contains("Copy")){
            // Détruire la copie
            interactor.interactionManager.SelectExit(interactor, interactor.GetOldestInteractableSelected());
            Destroy(heldObject);
            
            // Créer la boule de papier
            GameObject boule = Instantiate(BouleDePapier);
            XRGrabInteractable grabInteractable = boule.GetComponent<XRGrabInteractable>();
            interactor.interactionManager.SelectEnter((IXRSelectInteractor)interactor, grabInteractable);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreMesh.text = "" + score;
    }
}
