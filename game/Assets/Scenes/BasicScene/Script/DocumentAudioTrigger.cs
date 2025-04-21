using UnityEngine;
using System.Collections.Generic;
using System.Threading;

public class DocumentAudioTrigger : MonoBehaviour
{
    public AudioSource dialog;

    private bool alreadyPlayed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {}

    // Update is called once per frame
    void Update() {}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && dialog != null && !alreadyPlayed)
        {
            alreadyPlayed = true;
            dialog.Play();
        }
    }
}
