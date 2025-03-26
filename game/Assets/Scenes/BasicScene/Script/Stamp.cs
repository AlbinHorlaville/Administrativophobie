using TMPro;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    public TextMeshPro validateText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Official Document" && transform.position.y < collision.transform.position.y)
        {
            TextMeshPro tag = Instantiate(validateText, transform.position, Quaternion.identity);
            tag.gameObject.SetActive(true);
        }
    }
}
