using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using System.Collections;

public class Stamp : MonoBehaviour
{
public TextMeshPro validateText;
public AudioSource bruitTampon;
private bool canStamp = false;
public Telemetry telemetry;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StampCooldown(1.0f));
    }

    IEnumerator StampCooldown(float duration)
    {
        float timeLeft = duration;
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            timeLeft -= 1f;
        }
        canStamp = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Official Document" && transform.position.y > collision.transform.position.y && canStamp)
        {
            bruitTampon.Play();
            TextMeshPro tag = Instantiate(validateText, validateText.transform.GetWorldPose().position, validateText.transform.GetWorldPose().rotation);
            tag.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
            tag.gameObject.SetActive(true);

            telemetry.Stamp();
        }
    }
}
