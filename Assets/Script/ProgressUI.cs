using UnityEngine;
using UnityEngine.UI;

public class ProgressUI : MonoBehaviour
{
    [SerializeField] private Text progressText;

    private void Start()
    {
        UpdateProgressUI();
    }

    private void Update()
    {
        UpdateProgressUI();
    }

    // NEW: Public method for forced refresh (after delete)
    public void ForceUpdate()
    {
        UpdateProgressUI();
    }

    private void UpdateProgressUI()
    {
        if (progressText == null) return;

        var saveData = SaveManager.Instance.GetSaveData();
        int completed = saveData.GetCompletedScenesCount();

        progressText.text = $"{completed}/{saveData.totalScenes}";
    }
}