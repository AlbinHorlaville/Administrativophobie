using UnityEngine;

public class VRFootsteps : MonoBehaviour
{
    public AudioClip footstepClip;
    public AudioSource audioSource;

    public float stepInterval = 0.5f;
    public float moveThreshold = 0.1f;

    private float stepTimer = 0f;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);
        float speed = distanceMoved / Time.deltaTime;

        if (speed > moveThreshold)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval + Random.Range(-0.1f, 0.1f);
            }
        }
        else
        {
            stepTimer = 0f;
        }

        lastPosition = transform.position;
    }

    void PlayFootstep()
    {
        if (footstepClip == null) return;

        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.volume = Random.Range(0.8f, 1.0f);
        audioSource.PlayOneShot(footstepClip);
    }
}
