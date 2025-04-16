
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVR : MonoBehaviour
{
    public void Jouer()
    {
        Debug.Log("Le bouton Jouer a été cliqué !");
        SceneManager.LoadScene("BasicScene");
    }

    public void Quitter()
    {        
        Debug.Log("Le bouton Quitter a été cliqué !");
        Application.Quit();
    }
}
