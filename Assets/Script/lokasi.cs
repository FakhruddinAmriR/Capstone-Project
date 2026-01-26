using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lokasi:MonoBehaviour
{
    public string nama_lokasi;
    public bool dikunjungi;

    private void Start()
    {
        PlayerPrefs.SetString("namalokasi", nama_lokasi);
    }
}
