using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Button[] mcqOptions;
    public TMPro.TMP_Text scoreText;
    public GameObject scorePanel;

    public int correctAnswer = 0;
    public int wrongAnswer = 0;

    private JSONParser jsonParser;

    private void Start()
    {
        jsonParser = GetComponent<JSONParser>();

        foreach (Button b in mcqOptions)
        {
            //b.onClick.AddListener(() => OnOptionSelected(b.GetComponentInChildren<TMPro.TMP_Text>().text));
            b.onClick.AddListener(() => OnOptionSelected(b.name));
        }

    }

    private void OnOptionSelected(string selectedOption)
    {
        if (jsonParser.currentQuestionIndex < jsonParser.data.Count)
        {
            int x= selectedOption == jsonParser.data[jsonParser.currentQuestionIndex].CorrectAnswer ? correctAnswer++ : wrongAnswer++;

            jsonParser.currentQuestionIndex++;

            TransitionToNextState();
        }
    }

    private void TransitionToNextState()
    {
        jsonParser.FillDataFromJson();

        if (jsonParser.currentQuestionIndex > jsonParser.data.Count - 1)
            ShowScore();
    }

    private void ShowScore()
    {
        scorePanel.SetActive(true);
        mcqOptions[0].transform.parent.gameObject.SetActive(false);
        jsonParser.question.transform.parent.transform.parent.gameObject.SetActive(false);
        scoreText.text = $"Answered Correctly: {correctAnswer}\nAnswered Incorrectly: {wrongAnswer}";
    }
}