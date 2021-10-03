using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Slider m_slider;
    public static float lauts = 0.5f;

    public void gamestart()
    {
        SceneManager.LoadScene("Farm");
    }

    public void gameload()
    {

    }

    public void Start()
    {
        m_slider.onValueChanged.AddListener((v) =>
        {
            lauts = v;
        });
    }
}
