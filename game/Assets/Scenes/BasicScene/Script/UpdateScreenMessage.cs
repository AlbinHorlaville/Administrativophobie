using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateScreenMessage : MonoBehaviour
{
    public TMP_Text textObject;
    public GameObject DocumentPrefab;
    public GameObject WinningScreenPrefab;
    public ParticleSystem Confetti;

    public List<GameObject> documents = new List<GameObject>();
    public Telemetry telemetry;

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
            doc.name = "Déclaration d'impôts";
            ValidDocument validDoc = doc.GetComponent<ValidDocument>();
            validDoc.titre.text = doc.name;
            documents.Add(doc);

            doc = Instantiate(DocumentPrefab);
            doc.name = "Renouvellement du passeport";
            validDoc = doc.GetComponent<ValidDocument>();
            validDoc.titre.text = doc.name;
            documents.Add(doc);

            doc = Instantiate(DocumentPrefab);
            doc.name = "Résiliation d'abonnement";
            validDoc = doc.GetComponent<ValidDocument>();
            validDoc.titre.text = doc.name;
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
        if (documents.Count <= 0)
        {
            return;
        }

        documents.RemoveAt(0);
        textObject.text = "Documents en attente :";
        foreach (GameObject document in documents)
        {
            textObject.text += "\n - " + document.name;
            document.SetActive(false);
        }
        if (documents.Count > 0)
        {
            documents[0].SetActive(true);
        }

        telemetry.ValidateDocument();
        if (documents.Count == 0)
        {
            telemetry.SaveTelemetry();
            StartCoroutine(Win());
        }
    }

    private IEnumerator Win()
    {
        Confetti.Play();
        yield return new WaitForSeconds(5f);

        Debug.Log("WIN");
    }
}
