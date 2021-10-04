using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //wird gebraucht für SceneManager.LoadScene("EndScreen");

public class Matthaeus : MonoBehaviour
{
    public static bool tipp_Matt = false;

    public static void boss_start()
    {
        BossHandler.boss_active = true;
    }
}
