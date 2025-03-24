using UnityEngine;
using TMPro;

public class Logic : MonoBehaviour
{

    public int score = 0;
    public TextMeshPro scoreMesh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreMesh.text = "" + score;
    }
}
