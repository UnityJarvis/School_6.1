using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class LessonData
{
    public string QuestionType;
    public string Question;
    public Dictionary<string, string> Options;
    public string CorrectAnswer;
    public string Explanation;
}


public class JSONParser : MonoBehaviour
{
    public TextAsset jsonFile;

    public List<LessonData> data;

    private void Start()
    {
        
        //ReadJsonData();
        //FillDataFromJson();
    }

    public void LoadData()
    {
        currentQuestionIndex = 0;
        ReadJsonData();
        FillDataFromJson();
    }
    public void ResetQnA()
    {
        currentQuestionIndex = 0;
        Options options = GetComponent<Options>();
        options.scorePanel.gameObject.SetActive(false);

        question.transform.parent.transform.parent.gameObject.SetActive(true);
        options.mcqOptions[0].transform.parent.gameObject.SetActive(true);

        options.correctAnswer = 0;
        options.wrongAnswer = 0;
    }
    void ReadJsonData()
    {
        data = JsonConvert.DeserializeObject<List<LessonData>>(jsonFile.text);
    }

    public TMP_Text question;
    public Options options;
    public TMP_Text explanation;
    public int currentQuestionIndex;
    public void FillDataFromJson()
    {
        if (currentQuestionIndex < data.Count)
        {
            question.text = data[currentQuestionIndex].Question;
            explanation.text = data[currentQuestionIndex].Explanation;
            SetButtonVisibilty();
        }
    }

    public void SetButtonVisibilty()
    {
        foreach (Button btn in options.mcqOptions)
        {
            btn.gameObject.SetActive(false);
        }
        for (int i = 0; i < data[currentQuestionIndex].Options.Count; i++)
        {
            options.mcqOptions[i].gameObject.SetActive(true);
            options.mcqOptions[i].GetComponentInChildren<TMP_Text>().text = data[currentQuestionIndex].Options[$"{i + 1}"];
        }
    }
}