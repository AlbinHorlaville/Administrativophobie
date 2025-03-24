using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WinningPopup : MonoBehaviour
{

    public TextMeshProUGUI scoreNumber;
    public TextMeshProUGUI timeNumber;
    public Logic logic;
    public Chronometre chronometre;
    public CanvasGroup canvasGroup;

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

        scoreNumber.text = "" + logic.score;
        timeNumber.text = chronometre.GetStringTimer();
        
        while (timeElapsed < fadeInDuration)
        {
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeInDuration);
            yield return null;
        }

        // Wait for 2 seconds
        yield return new WaitForSeconds(10f);

        SceneManager.LoadScene("Menu");
    }
}
