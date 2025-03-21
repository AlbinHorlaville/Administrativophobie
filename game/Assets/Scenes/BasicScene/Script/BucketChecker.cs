using UnityEngine;
using System.Collections.Generic;

public class BucketChecker : MonoBehaviour
{
    public Transform player;
    public Logic logic;
    public GameObject bucketPopupPrefab;

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

            logic.score += scoreMult * 100;
            logic.UpdateScoreMesh();

            GameObject bucketPopup = Instantiate(bucketPopupPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            bucketPopup.GetComponent<BucketPopup>().UpdateText(scoreMult);
        }
    }
}
