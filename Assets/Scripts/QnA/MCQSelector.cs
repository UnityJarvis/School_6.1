using UnityEngine;
using UnityEngine.UI;

public class MCQSelector : MonoBehaviour
{
    public JSONParser JSONParser;
    public Button[] QnASelectorButtons;
    private void Awake()
    {
        QnASelectorButtons = GetComponentsInChildren<Button>();
        foreach (Button button in QnASelectorButtons)
        {
            button.onClick.AddListener(() => QnAActivator(button.GetComponent<JsonHolder>().jsonQnA));
        }
    }
    void QnAActivator(TextAsset jsonFile)
    {
        JSONParser.jsonFile = jsonFile;
        JSONParser.transform.GetChild(0).gameObject.SetActive(true);
        JSONParser.LoadData();
    }
}
