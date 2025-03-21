using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BucketPopup : MonoBehaviour
{

    public TextMeshProUGUI bucketPunch;
    public TextMeshProUGUI bucketNumber;
    public CanvasGroup canvasGroup;

    private List<string> punchlines = new List<string>() {
        "Tu te crois drôle ? T'es dans le panier là...",
        "Manque d'ambition, mais au moins c'est dedans.",
        "Tir à mi-distance, le classique !",
        "DEPUIS LE PARKIIIIING !"
    };
    private List<Color> colorList = new List<Color>() {
        new Color(0.92f, 0.21f, 0.21f),
        new Color(1.0f, 0.85f, 0.17f),
        new Color(0.4f, 0.7f, 0.2f),
        new Color(0.33f, 0.42f, 1.0f)
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

    public void UpdateText(int bucketMult)
    {
        bucketPunch.text = punchlines[bucketMult];
        bucketPunch.color = colorList[bucketMult];
        bucketNumber.text = "+ " + bucketMult * 100;
        bucketNumber.color = colorList[bucketMult];
    }
}
