using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mapprogres : MonoBehaviour
{
    [SerializeField] Text MapDikunjungi;
    public int totalmap = 19;
    public int mapdikunjungi;
    public string visited;
    void Start()
    {
        string mapName = SceneManager.GetActiveScene().name;

        // Ambil daftar map yang sudah dikunjungi
        visited = PlayerPrefs.GetString("VisitedMaps", "");
        Debug.Log(visited);

        // Jika map belum ada di daftar, tambahkan
        //if (!visited.Contains(mapName))
        //{
        //    // Tambah ke daftar
        //    if (visited == "")
        //        visited = mapName;
        //    else
        //        visited += "," + mapName;

            
        //}
        //else
        //{
        //    Debug.Log($"Map {mapName} sudah pernah dikunjungi.");
        //}
        //PlayerPrefs.SetString("VisitedMaps", visited);
        //PlayerPrefs.Save();

        // Hitung jumlah map dikunjungi
        mapdikunjungi = visited.Split(',').Length;

        Debug.Log($"Kunjungi map baru: {mapName}. Total map dikunjungi: {mapdikunjungi}");
        MapDikunjungi.text = $"{mapdikunjungi} / {totalmap}";
    }

    public void updateprogress()
    {
        Debug.Log("testing");
        string mapName = SceneManager.GetActiveScene().name;
        mapdikunjungi++;
        visited += "," + mapName;
    }
}
