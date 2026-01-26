using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MinimapManager : MonoBehaviour
{
    public Vector3 minimapCameraPosition;
    private static MinimapManager instance;
    public GameObject minimapUIPrefab;

    private void Awake()
    {
        // Pastikan hanya satu instance yang aktif
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Buat UI minimap
        if (minimapUIPrefab != null)
            Instantiate(minimapUIPrefab);

        // Load scene map untuk kamera minimap
        LoadMapScene();
    }

    void LoadMapScene()
    {
        SceneManager.LoadSceneAsync("Maps", LoadSceneMode.Additive).completed += (op) =>
        {
            Camera minimapCam = GameObject.Find("MinimapCamera")?.GetComponent<Camera>();
            if (minimapCam != null)
            {
                minimapCam.transform.position = minimapCameraPosition;
            }

            var cameras = GameObject.FindObjectsOfType<Camera>();
            foreach (var cam in cameras)
            {
                if (cam.gameObject.scene.name == "Maps" && cam.name != "MinimapCamera")
                {
                    cam.enabled = false; // Nonaktifkan kamera lain
                }
            }

            // Pastikan MainCamera masih aktif
            Camera mainCam = Camera.main;
            if (mainCam != null && !mainCam.enabled)
                mainCam.enabled = true;
            // Nonaktifkan semua Canvas (UI) di scene Maps
            foreach (Canvas c in GameObject.FindObjectsOfType<Canvas>())
            {
                if (c.gameObject.scene.name == "Maps")
                    c.enabled = false;
            }

            // Nonaktifkan komponen fisika di scene Maps
            foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>())
            {
                if (go.scene.name == "Maps" && go.name != "MinimapCamera")
                {
                    if (go.GetComponent<Maps>() !=null)
                        go.GetComponent<Maps>().enabled = false;
                    // Nonaktifkan Rigidbody
                    var rb = go.GetComponent<Rigidbody>();
                    if (rb != null)
                        rb.isKinematic = true; // Jadikan kinematic agar tidak diproses oleh fisika

                    // Nonaktifkan Collider
                    var collider = go.GetComponent<Collider>();
                    if (collider != null)
                        collider.enabled = false; // Nonaktifkan collider
                }
            }

            // Pastikan kamera minimap hanya render layer "Maps"
            //var minimapCam = GameObject.Find("MinimapCamera")?.GetComponent<Camera>();
            if (minimapCam != null)
                minimapCam.cullingMask = LayerMask.GetMask("Maps");


            EventSystem e = GameObject.FindObjectOfType<EventSystem>();
            e.gameObject.SetActive(false);
            Debug.Log("Scene 'Maps' loaded for minimap only. All UI and physics disabled.");
        };
    }

}
