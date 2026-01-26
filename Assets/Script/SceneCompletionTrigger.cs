using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneCompletionTrigger : MonoBehaviour
{
    [Header("Scene Settings")]
    
    public string nextSceneName;
    [SerializeField] private CompletionTriggerMode triggerMode = CompletionTriggerMode.Collider;

    [Header("UI Button (if using Button mode)")]
    [SerializeField] private Button completionButton;

    [Header("Auto Complete (if using Auto mode)")]
    [SerializeField] private float autoCompleteDelay = 2f; // Seconds after scene load

    private bool hasTriggered = false;
    [SerializeField] public string currentScene;
    private bool active = true;
    public enum CompletionTriggerMode
    {
        Collider,  // Player touches trigger
        Button,    // UI button press
        Auto       // Complete on scene load
    }

    private void Start()
    {
        if (currentScene == null)
            currentScene = SceneManager.GetActiveScene().name;

        // Setup button if using Button mode
        if (triggerMode == CompletionTriggerMode.Button && completionButton != null)
        {
            completionButton.onClick.AddListener(CompleteScene);
        }

        // Auto-complete if using Auto mode
        if (triggerMode == CompletionTriggerMode.Auto)
        {
            Invoke(nameof(CompleteScene), autoCompleteDelay);
        }
    }

    public void changeactive(bool _active)
    {
        active = _active;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (triggerMode == CompletionTriggerMode.Collider &&
            other.CompareTag("Player") &&
            !hasTriggered)
        {
            CompleteScene();
        }
    }

    // Public method - call from ANYWHERE (buttons, scripts, etc.)
    public void CompleteScene()
    {
        if (hasTriggered) return;
        hasTriggered = true;

        var saveData = SaveManager.Instance.GetSaveData();
        var progress = saveData.GetSceneProgress(currentScene);

        if (!progress.isCompleted && active)
        {
            progress.isCompleted = true;
            SaveManager.Instance.SaveGame();

            Debug.Log($" Scene '{currentScene}' COMPLETED! Progress: {saveData.GetOverallProgress():F0}%");
        }

        // Load next scene

            saveData.lastScene = nextSceneName;
        SceneManager.LoadScene(nextSceneName);
    }

    private void OnDestroy()
    {
        // Cleanup button listener
        if (completionButton != null)
            completionButton.onClick.RemoveListener(CompleteScene);
    }
}