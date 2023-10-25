using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Logger : MonoBehaviour
{
    [SerializeField]
    private Toggle[] organsToggle;
    private String dateTimeAtStart;
    public float logInterval = .1f;
    private float _deltaTime = 0f;
    private float _currentFPS = 0f;
    static int tris;
    // Start is called before the first frame update
    void Start()
    {
        dateTimeAtStart = SetDateTime();
        SetCSV();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(StartLogging());
    }
    private string SetDateTime()
    {
        dateTimeAtStart = System.DateTime.Now.ToString();
        // Debug.Log($"Value before parsing:{dateTimeAtStart}");
        dateTimeAtStart = dateTimeAtStart.Replace(':', '_');
        dateTimeAtStart = dateTimeAtStart.Replace('/', '.');
        dateTimeAtStart = dateTimeAtStart.Replace(' ', '_');
        return dateTimeAtStart;
    }
    private void SetCSV()
    {
        using (StreamWriter file = new StreamWriter(GetPath(), true))
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Num_of_organs").Append(",Num_of_triangles").Append(",Current_FPS").Append(",ElapsedTime");
            file.WriteLine(sb.ToString());
        }

    }
    private string BuildRecord()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(GetOrganCounts()).Append(",").Append("," + GenerateFPS()).Append(",");
        // Debug.Log(sb.ToString());
        return sb.ToString();

    }
    private string GetOrganCounts()
    {
        int num = 0;
        string[] twoOrgans = { "blood", "brain", "bronchus", "eyes", "fallopian", "heart", "l_intestine", "larynx", "liver", "lungs", "lymph", "mammary", "ovaries", "pancreas", "pelvis", "eyes", "kdineys", "knees", "skin", "s_intestine", "spine", "spleen", "trachea", "tonsils", "urinarybladder" };
        foreach (var toggle in organsToggle)
        {
            if (toggle.isOn)
            {
                if (twoOrgans.Any(toggle.name.ToString().ToLower().Contains)) num += 2;
                else num += 1;
            }
            else
            {
                if (twoOrgans.Any(toggle.name.ToString().ToLower().Contains)) num -= 2;
                else num -= 1;
            }
        }
        // Debug.Log(num);
        return num.ToString();
    }
    private string GetPath()
    {
        return Application.dataPath + "/Data/Logger/Test_" + dateTimeAtStart + ".csv";
    }
    private string GenerateFPS()
    {
        _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * .1f;
        _currentFPS = 1.0f / _deltaTime;
        return _currentFPS.ToString();
    }
    private IEnumerator StartLogging()
    {
        // Debug.Log("Loggin Started");
        AddRecord(GetPath());
        yield return new WaitForSeconds(logInterval);
    }
    private string GetTrisStats() {
        int combinedVerts = 0;
        GameObject[] ob = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject obj in ob) {
            combinedVerts += GetObjectStats(obj);
        }
        return combinedVerts.ToString();
    }
 
    private int GetObjectStats(GameObject obj) {
        Component[] filters;
        filters = obj.GetComponentsInChildren<MeshFilter>();
        foreach( MeshFilter f in filters )
        {
            tris += f.sharedMesh.triangles.Length/3;
        }
        return tris;
    }
    private void AddRecord(string filePath)
    {
        // Debug.Log("Inside Add Record");
        using (StreamWriter file = new StreamWriter(filePath, true))
        {
            file.WriteLine(
           BuildRecord()
            );
        }
    }
}
