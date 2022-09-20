using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Image ex;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Explain()
    {
        ex.gameObject.SetActive(true);
    }

    public void ExplainEs()
    {
        ex.gameObject.SetActive(false);
    }
}
