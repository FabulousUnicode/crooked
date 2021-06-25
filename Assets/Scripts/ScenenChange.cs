using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenenChange : MonoBehaviour
{
    public string scene;

    public void wechsel()
    {
        SceneManager.LoadScene(scene);
    }
}
