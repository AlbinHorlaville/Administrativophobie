using UnityEngine;
using System.Collections.Generic;

public class BucketChecker : MonoBehaviour
{
    public Transform player;
    public Logic logic;
    public BucketPopup bucketPopup;
    public AudioSource bruitTrashbinFailure;
    public AudioSource bruitTrashbinSuccess;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {}

    // Update is called once per frame
    void Update() {}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Paper Ball" && !other.GetComponent<XRGrabTracker>().IsCurrentlyGrabbed())
        {

            float distance = Vector3.Distance(player.position, transform.position);
            int scoreMult = Mathf.Min(3, (int) distance);
            if (scoreMult == 0)
            {
                bruitTrashbinFailure.Play();
            }else
            {
                bruitTrashbinSuccess.Play();
            }
            logic.UpdateScore(scoreMult * 100);

            bucketPopup.UpdateText(scoreMult);
            bucketPopup.DoActivate();
        }
    }


}
