using TMPro;
using UnityEngine;

public class UpdateScreenMessage : MonoBehaviour
{
    public TMP_Text textObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (textObject != null)
        {
            textObject.text = "\nMessage Updated...";
        }
        else
        {
            Debug.LogError("TextObject is not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
