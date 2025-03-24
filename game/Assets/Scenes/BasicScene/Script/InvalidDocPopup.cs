using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InvalidDocPopup : MonoBehaviour
{

    public TextMeshProUGUI reasonText;
    public CanvasGroup canvasGroup;

    private Dictionary<string, string> reasonTexts = new Dictionary<string, string>() {
        { "tampon", "Le tampon est nécessaire avant l'envoi du document." },
        { "document", "Le dossier est incomplet." }
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LifeCycle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LifeCycle() {
        // Fade in
        float fadeInDuration = 1f;
        float timeElapsed = 0f;
        
        while (timeElapsed < fadeInDuration)
        {
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeInDuration);
            yield return null;
        }

        // Wait for 2 seconds
        yield return new WaitForSeconds(3f);

        // Fade out
        float fadeOutDuration = 1f;
        timeElapsed = 0f;
        
        while (timeElapsed < fadeOutDuration)
        {
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeOutDuration);
            yield return null;
        }

        // Destroy the object after fading out
        Destroy(gameObject);
    }

    public void UpdateText(string reason)
    {
        reasonText.text = reasonTexts[reason];
    }
}
