using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ValidDocument : MonoBehaviour
{
    public List<TextMeshPro> textMeshMap = new List<TextMeshPro>();
    public List<int> papers = new List<int>() {};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ajouter (changer en random) des papiers a valider pour ce document
        for (int i = 0; i < textMeshMap.Count; i++){
            int prob = Random.Range(0, 100);
            if (prob > 60){ // La probabilité qu'un papier soit ajouté a la liste du document
                papers.Add(i);
            }
        }

        int indicePapersIncluded = 1;
        // Placer les TextMeshPro aux bons endroits
        for (int i = 1; i < textMeshMap.Count; i++){
            if (papers.Contains(i)){
                Vector3 pos = textMeshMap[i].transform.localPosition;
                Quaternion rot = textMeshMap[i].transform.localRotation;
                Vector3 incr = new Vector3(0, -0.003f * indicePapersIncluded, 0);
                textMeshMap[i].transform.SetLocalPositionAndRotation(pos + incr, rot);
                textMeshMap[i].color = new Color(0, 0.5f, 0);
                indicePapersIncluded += 1;
            }
            else{
                textMeshMap[i].color = new Color(0, 0, 0, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("DEBUG POSITIONS");
        for (int i = 0; i < textMeshMap.Count; i++){
            Debug.Log(textMeshMap[i].transform.localPosition);
        }
        if (papers.Count == 0){
            Debug.Log("Document validé !");
        }
    }
}
