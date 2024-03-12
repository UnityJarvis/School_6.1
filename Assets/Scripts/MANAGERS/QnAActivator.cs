using UnityEngine;

public class QnAActivator : MonoBehaviour
{
    public ExperimentSelector ExperimentSelector;
    public JSONParser js;
    private void Start()
    {
        
        js = GetComponent<JSONParser>();
    }
    public void ActivateQnAPannel()
    {
        js.jsonFile = ExperimentSelector.experiments[ExperimentSelector.CurrentExperimentIndex].GetComponent<ExperimentsPerformedCheck>().qNAJsonFile;
        this.transform.GetChild(0).gameObject.SetActive(true);

        js.LoadData();
    }
}