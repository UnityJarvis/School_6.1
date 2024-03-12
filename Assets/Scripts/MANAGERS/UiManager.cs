using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Video;
using InuCom.SchoolVR.UI.Videos;
using Inucom.SchoolVR.UI;

/// <summary>
/// Manages the user interface for a virtual reality educational application.
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// List of all panels in the UI.
    /// </summary>
    [Header("Board Panels")]
    public List<GameObject> allPanels;

    /// <summary>
    /// List of buttons in the start panel.
    /// </summary>
    public List<Button> startPanelButtons;

    /// <summary>
    /// List of buttons in the experiment panel.
    /// </summary>
    public List<Button> experimentPanelButtons;

    [Space(10)]
    [Header("VideoPanel")]
    public RectTransform videoPanelViewport;
    public List<ContentSizeFitter> videoPlayerContextPanel;
    public VideoPlayer videoPlayerComponent;
    public VideoLessons[] videoLessonsArray;

    public List<RectTransform> contextRectTransform;
    public ScrollRect leftButtonsScrollView;

    [Space(5)]
    [Header("Board Position Toggle")]
    public Button toggleButton;
    public Image toggleImageComponent;
    public Sprite smallToBigSprite, bigToSmallSprite;
    Text toggleButtonText;
    [Space(20)]
    public Vector3 boardInitialPosition;
    public Vector3 bigBoardScale;
    public Vector3 smallBoardScale;
    public Transform leftHandPosition, worldCanvasHolderPosition, canvasUIParent;
    bool isCanvasOnWall;

    public Transform worldCanvasHolder;

    //----------------------------------------------------------------------------

    /// <summary>
    /// Initializes the UI elements and sets up the start configuration.
    /// </summary>
    private void Start()
    {
        TogglingUiBoard();

        InstantiateStartPanelButton();

        InstantiateExperimentPanelButtons();

        InstantiateVideoPanel();

        BoardPanelInitialize();
    }

    /// <summary>
    /// Instantiates the buttons for the start panel.
    /// </summary>
    private void InstantiateStartPanelButton()
    {
        allPanels[0].GetComponentsInChildren(startPanelButtons);
        foreach (Button button in startPanelButtons) { button.onClick.AddListener(() => StartPanelButtonFunction(button.name)); }
    }

    /// <summary>
    /// Instantiates the buttons for the experiment panel.
    /// </summary>
    private void InstantiateExperimentPanelButtons()
    {
        allPanels[1].GetComponentsInChildren(experimentPanelButtons);
        experimentPanelButtons.RemoveAt(0);
        experimentPanelButtons.RemoveAt(experimentPanelButtons.Count - 1); //FOR Removal of QNA Button name(7)
        foreach (Button button in experimentPanelButtons) { button.onClick.AddListener(() => ExperimentPanelButtonFunction(int.Parse(button.name))); }
    }

    /// <summary>
    /// Instantiates the buttons and components for the video panel.
    /// </summary>
    private void InstantiateVideoPanel()
    {
        videoPanelViewport.GetComponentsInChildren(contextRectTransform);

        videoPanelViewport.GetComponentsInChildren(videoPlayerContextPanel);
        VideoPlayerSeekBar videoPlayerSeekBar = videoPlayerComponent.GetComponent<VideoPlayerSeekBar>();

        for (int i = 0; i < videoPlayerContextPanel.Count; i++)
        {
            VideoPanelButtonsInstantiator.InstantiateButton(videoLessonsArray[i], videoPlayerContextPanel[i].transform, videoPlayerComponent, videoPlayerSeekBar);
        }
    }

    /// <summary>
    /// Initializes the UI board and toggle button.
    /// </summary>
    private void TogglingUiBoard()
    {
        toggleButtonText = toggleButton.GetComponentInChildren<Text>();
        boardInitialPosition = worldCanvasHolder.position;

        CanvasSwitcher.IsCanvasOnWall = true; // Set Position of board to wall
        toggleButton.onClick.AddListener(CanvasSwitcher.ToggleCanvasPosition);
    }

    /// <summary>
    /// Initializes the board panels.
    /// </summary>
    private void BoardPanelInitialize()
    {
        foreach (GameObject panel in allPanels) { panel.SetActive(false); }
        allPanels[0].SetActive(true);
    }

    /// <summary>
    /// Updates the canvas position based on the current state.
    /// </summary>
    private void Update()
    {
        UpdateCanvasPosition();
    }

    /// <summary>
    /// Updates the canvas position based on the current state.
    /// </summary>
    private void UpdateCanvasPosition()
    {
        isCanvasOnWall = CanvasSwitcher.IsCanvasOnWall;
        CanvasSwitcher.TransitionCanvasPosition(boardInitialPosition, bigBoardScale, smallBoardScale, leftHandPosition, worldCanvasHolderPosition, canvasUIParent, isCanvasOnWall, toggleButtonText);
        CanvasSwitcher.ToggleImageSprite(toggleImageComponent, smallToBigSprite, bigToSmallSprite, isCanvasOnWall);
    }

    /// <summary>
    /// Handles the functionality of the start panel buttons.
    /// </summary>
    /// <param name="buttonName">The name of the button clicked.</param>
    private void StartPanelButtonFunction(string buttonName)
    {
        if (buttonName == "Start")
        {
            foreach (GameObject panel in allPanels) { panel.SetActive(false); }
            allPanels[1].SetActive(true);
        }
    }

    /// <summary>
    /// Handles the functionality of the experiment panel buttons.
    /// </summary>
    /// <param name="contextIndex">The index of the selected experiment context.</param>
    private void ExperimentPanelButtonFunction(int contextIndex)
    {
        foreach (GameObject panel in allPanels) { panel.SetActive(false); }
        allPanels[2].SetActive(true);
        foreach (ContentSizeFitter context in videoPlayerContextPanel) { context.gameObject.SetActive(false); }
        
        videoPlayerContextPanel[contextIndex - 1].gameObject.SetActive(true);
        leftButtonsScrollView.content = contextRectTransform[contextIndex];
    }

    /// <summary>
    /// Sets the current experiment based on the provided experiment number.
    /// </summary>
    /// <param name="experimentNumber">The number of the current experiment.</param>
    public void SetCurrentExperiment(int experimentNumber)
    {
        ExperimentSelector.CurrentExperimentIndex = experimentNumber;
    }
}
