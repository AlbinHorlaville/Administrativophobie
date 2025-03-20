using TMPro;
using UnityEngine;

public class Chronometre : MonoBehaviour
{
    public TextMeshPro timerText; // Référence au texte UI
    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime; // Augmente le temps écoulé
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Format 00:00
    }
}
