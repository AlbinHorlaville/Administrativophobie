using System.Collections.Generic;
using System.IO;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class Telemetry : MonoBehaviour
{
    private string filePath;
    private float startTime;
    private int NbDocumentsChecked = 0;
    private int NbPapersPrinted = 0;
    private int NbStamped = 0;
    private List<int> documentTimes = new List<int>{ 0, 0, 0 };

    void Start()
    {
        startTime = Time.time;
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        filePath = Path.Combine(desktopPath, "telemetry.csv");

        // Crée l'en-tête si le fichier n'existe pas
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Utilisateur,Temps total (secondes),Documents validés,Feuilles imprimées,Tamponnages,Temps 1er document,Temps 2ème document,Temps 3ème document\n");
        }
    }

    public void SaveTelemetry()
    {
        int userId = GetLastUserId() + 1;
        float elapsedTime = Time.time - startTime;
        string line = $"{userId},{(int)elapsedTime}, {NbDocumentsChecked}, {NbPapersPrinted}, {NbStamped}, {documentTimes[0]}, {documentTimes[1]}, {documentTimes[2]}";
        File.AppendAllText(filePath, line + "\n");

        Debug.Log($"[Telemetry] Saved: User {userId}, Elapsed {elapsedTime:F2} sec");
        Debug.Log("Fichier de télémétrie : " + filePath);
    }

    public int GetLastUserId()
    {
        if (!File.Exists(filePath))
            return 0; // Aucun fichier → premier utilisateur

        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length <= 1)
            return 0; // Seulement l’en-tête → aucun utilisateur encore

        string lastLine = lines[lines.Length - 1];

        // Extrait le userId de la dernière ligne (UserId,ElapsedTime)
        string[] parts = lastLine.Split(',');

        if (int.TryParse(parts[0], out int lastId))
            return lastId;
        else
            return 0;
    }

    public void ValidateDocument()
    {
        for (int i = 0; i < documentTimes.Count; i++){
            if (documentTimes[i] == 0){
                documentTimes[i] = (int)(Time.time - startTime);
                NbDocumentsChecked += 1;
                return;
            }
        }
    }

    public void PrintPaper(){
        NbPapersPrinted += 1;
    }

    public void Stamp(){
        NbStamped += 1;
    }
}
