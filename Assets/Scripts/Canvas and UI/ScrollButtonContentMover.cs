using UnityEngine;

/// <summary>
/// Moves the content of a scrollable button holder left or right within specified bounds.
/// </summary>
public class ScrollButtonContentMover : MonoBehaviour
{
    /// <summary>
    /// The RectTransform of the button holder.
    /// </summary>
    public RectTransform buttonHolder;

    private Vector3 originalTransform;

    /// <summary>
    /// The clamped x-value for moving the button content.
    /// </summary>
    [Range(0, 350)]
    public float xValue = 0;

    private void Start()
    {
        originalTransform = buttonHolder.anchoredPosition;
    }

    private void Update()
    {
        float xClamped = Mathf.Clamp(xValue, 0, 350);
        buttonHolder.anchoredPosition = new Vector3(xClamped, originalTransform.y, originalTransform.z);
    }

    /// <summary>
    /// Move the button content to the left by the specified number of steps.
    /// </summary>
    /// <param name="stepsToDecrease">The number of steps to decrease the x-value.</param>
    public void LeftClick(float stepsToDecrease)
    {
        float xClamped = Mathf.Clamp(xValue, -100, 100);
        xClamped -= stepsToDecrease;
        xValue = xClamped;
    }

    /// <summary>
    /// Move the button content to the right by the specified number of steps.
    /// </summary>
    /// <param name="stepsToIncrease">The number of steps to increase the x-value.</param>
    public void RightClick(float stepsToIncrease)
    {
        float xClamped = Mathf.Clamp(xValue, -100, 100);
        xClamped += stepsToIncrease;
        xValue = xClamped;
    }
}
