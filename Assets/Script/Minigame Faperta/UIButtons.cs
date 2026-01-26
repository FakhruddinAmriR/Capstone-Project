using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    // tombol saat WIN  pindah ke scene berikut
    public void GoToNextScene()
    {
        SceneManager.LoadScene("FMIPA");
    }

    // tombol retry saat TIME UP  restart scene ini
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
