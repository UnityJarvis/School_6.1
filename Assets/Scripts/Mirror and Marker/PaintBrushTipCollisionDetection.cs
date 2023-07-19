using UnityEngine;

public class PaintBrushTipCollisionDetection : MonoBehaviour
{
    GameObject paintLineRendererRoot;
    public GameObject SilverPaint;
    public BNG.Grabbable silverGrabbable;
    int i = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Silver")
        {
            i++;
            if (i >= 2)
            {
                paintLineRendererRoot = GameObject.FindGameObjectWithTag("PaintBrushLineRendererRoot");
                if (paintLineRendererRoot != null)
                {
                    SilverPaint.SetActive(true);
                    silverGrabbable.enabled = true;
                    paintLineRendererRoot.SetActive(false);
                }
            }
        }
    }
}
