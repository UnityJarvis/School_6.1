using UnityEngine;

public class ScrollButtonContentMover : MonoBehaviour
{
    public RectTransform buttonHolder;
    Vector3 originalTransform;
    [Range (-100,100)]
    public float xValue = 0;
    void Start(){originalTransform = buttonHolder.anchoredPosition;}
    void Update(){float xClamped = Mathf.Clamp(xValue,-100,100); buttonHolder.anchoredPosition = new Vector3(xClamped,originalTransform.y,originalTransform.z);}
    public void LeftClick(float stepsToDecrease){float xClamped = Mathf.Clamp(xValue,-100,100); xClamped -= stepsToDecrease; xValue = xClamped;}
    public void RightClick(float stepsToIncrease){float xClamped = Mathf.Clamp(xValue,-100,100);xClamped += stepsToIncrease; xValue = xClamped;}
}
