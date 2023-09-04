
using UnityEngine;
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
        //DisplayFPS();
    }

    public float FrameRateCalculator()
    {
        return 1/Time.unscaledDeltaTime;
    }
    public void DisplayFPS()
    {
        fpsText.text = fps.ToString("000");
    }

    public void QuittingApplication()
    {
        // if(Application.isEditor)
        //     EditorApplication.isPlaying = false;
        // else
            Application.Quit();
    }

}

