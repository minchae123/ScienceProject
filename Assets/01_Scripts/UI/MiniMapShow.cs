using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MiniMapShow : MonoBehaviour
{
    public RawImage miniMap;

    //private int pushCount;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!miniMap.gameObject.activeSelf)
            {
                ShowMap();
            }
            else
            {
                UnShowMap();
            }
        }
    }

    public void ShowMap()
    {
        miniMap.gameObject.SetActive(true);
    }

    public void UnShowMap()
    {
        miniMap.gameObject.SetActive(false);
    }
}
