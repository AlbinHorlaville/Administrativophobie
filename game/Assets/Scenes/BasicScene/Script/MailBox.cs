using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MailBox : MonoBehaviour
{

    public XRSocketInteractor socket;
    public GameObject invalidDocPopupPrefab;
    public UpdateScreenMessage screenMessageUpdater;
    public Logic logic;

    private void OnEnable()
    {
        if (socket == null)
        {
            Debug.LogError("Socket is not assigned in " + gameObject.name);
            return;
        }

        // Subscribe to events
        socket.selectEntered.AddListener(OnObjectPlaced);
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        ValidDocument officialDoc = args.interactableObject.transform.gameObject.GetComponent<ValidDocument>();
        if (officialDoc != null)
        {
            if (officialDoc.tampon.enabled == true)
            {
                args.interactableObject.transform.gameObject.SetActive(false);
                logic.UpdateScore(1000);
                screenMessageUpdater.DocumentSubmitted();
            } else
            {
                GameObject invalidDocPopup = Instantiate(invalidDocPopupPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                invalidDocPopup.GetComponent<InvalidDocPopup>().UpdateText(officialDoc.GetInvalidReason());
            }
        }
    }
}
