#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.UI;
using BNG;
using TMPro;
using InuCom.SchoolVR.physics.LightAndMatter.lesson_2;
using InuCom.SchoolVR.physics.LightAndMatter.lesson_3;
using InuCom.SchoolVR.physics.LightAndMatter.lesson_4;

public class GameManager : MonoBehaviour
{
    [Header("Exp 3 LightMeter")]
    [Space(10)]
    public LineRenderer lineRenderer;
    public Transform p1, p2;
    public TextMeshPro luxReading, Detector3DText;

    [Header("Exp 4 MirrorConstruction")]
    [Space(10)]
    public GameObject paint;
    public SnapZone snapPoint;
    public Grabbable glassGrabbale;
    public GameObject MirrorCamRenderer;
    public Grabbable silverGrabbable;

    [Space(10)]
    [Header("Debugging")]
    public float fps;
    public Text fpsText;
    
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        TorchLineRenderer.torchRenderer(lineRenderer, p1, p2);
        //InvokeRepeating("DisplayFPS", 0, 1.0f);
    }
    private void Update()
    {
        fps = FrameRateCalculator();
        //DisplayFPS();
        MirrorConstructionValidator.MirrorValidation(snapPoint, glassGrabbale, MirrorCamRenderer);
    }
    private void FixedUpdate()
    {
        Detector3DText.text = LuxMeter.LuxMeterReading(p1, luxReading).text;
    }
    public void TeleportPlayer(int sceneIndex)
    {
        PlayerTeleporter.RoomSceneLoader(sceneIndex);
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
        if(Application.isEditor)
            EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }

}

