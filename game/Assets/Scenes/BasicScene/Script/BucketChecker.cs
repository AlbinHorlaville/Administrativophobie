using UnityEngine;

public class BucketChecker : MonoBehaviour
{
    public Transform player;
    public Logic logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(player.position, transform.position);
        print (distance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Paper Ball" && !other.GetComponent<XRGrabTracker>().IsCurrentlyGrabbed())
        {
            float distance = Vector3.Distance(player.position, transform.position);
            logic.score += (int)distance * 100;
        }
    }
}
