using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    private static General instance;

    private static string previousScene;

    public static void setPreviousScene(string sceneName)
    {
        previousScene = sceneName;
    }

    public static string getPreviousScene()
    {
        return previousScene;
    }

    public static General Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
