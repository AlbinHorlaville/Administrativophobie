using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateScreenMessage : MonoBehaviour
{
    public TMP_Text textObject;
    public GameObject DocumentPrefab;

    public List<GameObject> documents = new List<GameObject>();

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

        if (DocumentPrefab != null)
        {
            GameObject doc = Instantiate(DocumentPrefab);
            doc.name = "Déclaration d'impôt";
            ValidDocument validDoc = doc.GetComponent<ValidDocument>();
            validDoc.titre.text = doc.name;
            documents.Add(doc);

            doc = Instantiate(DocumentPrefab);
            doc.name = "Dossier d'inscription a la piscine";
            validDoc = doc.GetComponent<ValidDocument>();
            validDoc.textMeshMap[0].text = doc.name;
            documents.Add(doc);

            doc = Instantiate(DocumentPrefab);
            doc.name = "Résiliation d'abonnement";
            validDoc = doc.GetComponent<ValidDocument>();
            validDoc.textMeshMap[0].text = doc.name;
            documents.Add(doc);
        }
        else
        {
            Debug.LogError("Prefab not assigned!");
        }

        textObject.text = "Documents en attente :";
        foreach (GameObject document in documents)
        {
            textObject.text += "\n - " + document.name;
            document.SetActive(false);
        }
        documents[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DocumentSubmitted()
    {
        if (documents.Count > 0)
        {
            documents.RemoveAt(0);
            textObject.text = "Documents en attente :";
            foreach (GameObject document in documents)
            {
                textObject.text += "\n - " + document.name;
                document.SetActive(false);
            }
            documents[0].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
