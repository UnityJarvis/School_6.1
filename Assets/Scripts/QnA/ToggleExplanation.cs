using UnityEngine;

public class ToggleExplanation : MonoBehaviour
{
    public void ToggleWindowVisibility(GameObject explanationPanel)
    {
        explanationPanel.SetActive(!explanationPanel.activeSelf);
    }
}
