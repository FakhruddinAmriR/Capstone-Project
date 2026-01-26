using UnityEngine;

public class MapSceneSetup : MonoBehaviour
{
    void Awake()
    {
        // Nonaktifkan semua kamera kecuali yang bernama "MinimapCamera"
        Camera[] allCameras = FindObjectsOfType<Camera>(true);
        foreach (Camera cam in allCameras)
        {
            if (cam.name != "MinimapCamera")
                cam.enabled = false;
        }

        // Pastikan audio listener tidak aktif di map scene
        AudioListener[] listeners = FindObjectsOfType<AudioListener>(true);
        foreach (AudioListener listener in listeners)
        {
            listener.enabled = false;
        }
    }
}
