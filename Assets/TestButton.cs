using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{

    public List<GameObject> toShow;

    public void OnClick()
    {
        foreach (var item in toShow)
        {
            item.SetActive(true);
        }
    }
}
