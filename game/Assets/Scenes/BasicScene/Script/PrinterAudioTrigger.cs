using UnityEngine;
using System.Collections.Generic;
using System.Threading;

public class PrinterAudioTrigger : MonoBehaviour
{
    public AudioSource dialog;
    public Chronometre chrono;
    public Telemetry telemetry;

    public float timeThreshold;
    private bool alreadyPlayed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {}

    // Update is called once per frame
    void Update() {}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && dialog != null && !alreadyPlayed && chrono.GetElapsedTime() > timeThreshold && telemetry.NbPapersPrinted == 0)
        {
            alreadyPlayed = true;
            dialog.Play();
        }
    }
}
