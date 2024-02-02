#region
/// copyright (c) iNucom. All rights reserved.
#endregion

using UnityEngine;
using System.Collections;
using UnityEngine.Playables;
using BNG;

public class FamilarizationPanel : MonoBehaviour
{
    public CanvasGroup screenFader;

    public PlayableDirector timeline;
    public UIPointer rightHandUiPointer;
    public bool uiPointerEnable = false;


    void Start()
    {
        screenFader = GameObject.Find("ScreenFader").GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        if (Time.time > 1 && Time.time < 4)
        {
            InputBridge.Instance.enabled = false; 
        }
    }
    public void FadeScreen()
    {
        InputBridge.Instance.enabled = false;
        StartCoroutine( ScreenFaderIEnum( 0.0f, 1.0f,2.0f));
    }
    public void UnFadeScreen()
    {
        StartCoroutine(ScreenFaderIEnum( 1.0f, 0.0f, 2.0f));
        InputBridge.Instance.enabled = true;
    }

    IEnumerator ScreenFaderIEnum(float min, float max,float duration)
    {
        screenFader.gameObject.SetActive(true);

        float time = 0;
        float startValue = min;
        while (time < duration)
        {
            screenFader.alpha = Mathf.Lerp(startValue, max, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        screenFader.alpha = max;    
        
        if(uiPointerEnable == true)
        {
            rightHandUiPointer.gameObject.SetActive(true);
        }

        StopAllCoroutines();
    }

    public void EnableUIPointer()
    {
        uiPointerEnable = true;
    }
}