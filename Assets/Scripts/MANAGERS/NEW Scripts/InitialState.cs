using System.Collections.Generic;
using UnityEngine;

public class InitialState : MonoBehaviour {
    public List<GameObject> show;
    public List<GameObject> hide;

    public void Init() {
        show.ForEach(go => go.SetActive(true));
        hide.ForEach(go => go.SetActive(false));
    }
}
