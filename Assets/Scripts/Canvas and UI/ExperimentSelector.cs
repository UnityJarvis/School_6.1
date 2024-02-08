using UnityEngine;

/// <summary>
/// Manages the selection and visibility of experiments in a virtual reality environment.
/// </summary>
public class ExperimentSelector : MonoBehaviour
{
    /// <summary>
    /// Array of experiment GameObjects.
    /// </summary>
    public GameObject[] experiments;

    /// <summary>
    /// Gets or sets the index of the currently selected experiment.
    /// </summary>
    internal static int CurrentExperimentIndex { get; set; }

    private void Start()
    {
        CurrentExperimentIndex = -1;
    }

    private void Update()
    {
        UpdateExperimentVisibility();
    }

    private void UpdateExperimentVisibility()
    {
        // Ensure current experiment index is within valid range
        CurrentExperimentIndex = Mathf.Clamp(CurrentExperimentIndex, 0, experiments.Length - 1);

        // Set visibility based on current experiment index
        for (int i = 0; i < experiments.Length; i++)
        {
            experiments[i].SetActive(i == CurrentExperimentIndex);
        }
    }
}

