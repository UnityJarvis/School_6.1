using UnityEngine;

public class ControllerFlow : MonoBehaviour
{
    public Material abxyMat;
    public Material thumbstickMat;
    public Material indexMat;
    public Material oculusMenuMat;
    public Material menuMat;
    public Material gripMat;
    public void Awake()
    {
        ResetMat();
    }

    public void ChangeMat(Material mat)
    {
        ResetMat();
        mat.color = Color.blue;
    }
    public void ResetMat()
    {
        abxyMat.color = Color.white;
        thumbstickMat.color = Color.white;
        indexMat.color = Color.white;
        oculusMenuMat.color = Color.white;
        menuMat.color = Color.white;
        gripMat.color = Color.white;
    }
    
    public void OnApplicationQuit()
    {
        ResetMat();
    }
}