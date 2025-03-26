using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Logic : MonoBehaviour
{

    public int score = 0;
    public TextMeshPro scoreMesh;
    public InputActionReference makeABallActionLeft;
    public InputActionReference makeABallActionRight;
    public XRBaseInteractor LeftInteractor;
    public XRBaseInteractor RightInteractor;
    public GameObject BouleDePapier;

    void Awake()
    {
        makeABallActionLeft.action.Enable();
        makeABallActionLeft.action.performed += MakeABallLeft;
        makeABallActionRight.action.Enable();
        makeABallActionRight.action.performed += MakeABallRight;
    }

    private void MakeABallLeft(InputAction.CallbackContext context)
    {
        if (!LeftInteractor.hasSelection){
            return;
        }

        GameObject heldObject = LeftInteractor.GetOldestInteractableSelected().transform.gameObject;
        if (heldObject.name.Contains("Copy")){
            // Détruire la copie
            LeftInteractor.interactionManager.SelectExit(LeftInteractor, LeftInteractor.GetOldestInteractableSelected());
            Destroy(heldObject);
            
            // Créer la boule de papier
            GameObject boule = Instantiate(BouleDePapier);
            XRGrabInteractable grabInteractable = boule.GetComponent<XRGrabInteractable>();
            LeftInteractor.interactionManager.SelectEnter((IXRSelectInteractor)LeftInteractor, grabInteractable);
        }
    }

    private void MakeABallRight(InputAction.CallbackContext context)
    {
        if (!RightInteractor.hasSelection)
        {
            return;
        }

        GameObject heldObject = RightInteractor.GetOldestInteractableSelected().transform.gameObject;
        if (heldObject.name.Contains("Copy"))
        {
            // Détruire la copie
            RightInteractor.interactionManager.SelectExit(RightInteractor, RightInteractor.GetOldestInteractableSelected());
            Destroy(heldObject);

            // Créer la boule de papier
            GameObject boule = Instantiate(BouleDePapier);
            XRGrabInteractable grabInteractable = boule.GetComponent<XRGrabInteractable>();
            RightInteractor.interactionManager.SelectEnter((IXRSelectInteractor)RightInteractor, grabInteractable);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreMesh.text = "" + score;
    }
}
