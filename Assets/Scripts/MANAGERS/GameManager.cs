using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Debugging")]
    public float fps;
    public Text fpsText;
    
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        fps = FrameRateCalculator();
        DisplayFPS();        
        FpsShowingStatus(BNG.InputBridge.Instance.AButton);
    }

    public float FrameRateCalculator()
    {
        return 1/Time.unscaledDeltaTime;
    }
    public void DisplayFPS()
    {
        fpsText.text = fps.ToString("000");
    }
    public void LoadSceneByIndexNumber(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuittingApplication()
    {
        // if(Application.isEditor)
        //     EditorApplication.isPlaying = false;
        // else
            Application.Quit();
    }



    #region DEBUGGING
    void FpsShowingStatus( bool status)
    {
        if(status)
            fpsText.enabled = true;
        else
            fpsText.enabled = false;
    }
    #endregion

}

