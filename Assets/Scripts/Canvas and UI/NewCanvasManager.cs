using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class NewCanvasManager : MonoBehaviour
{
    public List<GameObject> UiPanels;
    public List<GameObject> experiments;
    public int currentExp = 0;

    //Canvas Position Toggle Components
    public Transform leftHandCanvasHolder;
    public float worldScale, handScale;

    private void Awake()
    {
        foreach (GameObject panel in UiPanels)
        {
            panel.SetActive(false);
        }
        UiPanels[0].SetActive(true);
    }
    private void Update()
    {
        EnableCurrentExperiment();
    }
    public void EnableCurrentExperiment()
    {
        foreach (GameObject exp in experiments)
        {
            exp.SetActive(false);
        }
        experiments[currentExp].SetActive(true);
    }
    public void SetCurrentExperimentValue(int experimentIndex)
    {
        currentExp = experimentIndex;
    }
    public void StartButton()
    {
        foreach(GameObject panel in UiPanels)
        {
            panel.SetActive(false);
        }
        UiPanels[1].SetActive(true);
    }
    public void QuitButton()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
    public void HomeButton()
    {
        foreach( GameObject panel in UiPanels)
        {
            panel.SetActive(false);
        }
        UiPanels[0].SetActive(true);
    }

}
