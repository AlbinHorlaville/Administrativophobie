using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InvalidDocPopup : MonoBehaviour
{

    public TextMeshPro reasonText;
    public TextMeshPro invalidDocText;

    private Dictionary<string, string> reasonTexts = new Dictionary<string, string>() {
        { "tampon", "Le tampon est nécessaire avant l'envoi du document." },
        { "document", "Le dossier est incomplet." }
    };

    public void DoActivate()
    {
        StartCoroutine(LifeCycle());
    }

    private IEnumerator LifeCycle() {
        // Fade in
        float fadeInDuration = 1f;
        float timeElapsed = 0f;
        
        while (timeElapsed < fadeInDuration)
        {
            timeElapsed += Time.deltaTime;
            invalidDocText.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeInDuration);
            reasonText.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeInDuration);
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
            invalidDocText.alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeOutDuration);
            reasonText.alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeOutDuration);
            yield return null;
        }
    }

    public void UpdateText(string reason)
    {
        reasonText.text = reasonTexts[reason];
    }
}
