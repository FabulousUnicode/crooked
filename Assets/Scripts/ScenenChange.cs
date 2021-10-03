using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenenChange : MonoBehaviour
{

    public Sprite cursorOnHover;

    public string scene;
    public static string remove;
    public string destinationName;
    public static string add;

    public string currentScene;

    public static bool triggerHairball = false;

    private void OnMouseOver()
    {
        if (!FindObjectOfType<PanelManager>().getInventoryState())
        {
            Debug.Log("hovering");
            MouseManager.disableUpdate();
            Cursor.SetCursor(cursorOnHover.texture, Vector2.zero, CursorMode.Auto);
        }
    }

    private void OnMouseExit()
    {
        MouseManager.enableUpdate();
    }

    public void Start()
    {
        remove += "";
        string[] subs = remove.Split(',');


        foreach (var sub in subs)
        {
            GameObject obj = GameObject.Find(sub);
            if(obj != null)
            {
               Destroy(obj);
            }
        }

        add += "";
        string[] adds = add.Split(',');

        //print(add);

        foreach(var a in adds)
        {
            GameObject obj = GameObject.Find(a);
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

    }

    public void wechsel()
    {
        if(currentScene != null)
        {
            General.setPreviousScene(currentScene);
        }
        
        GameObject.Find("DialogFeld").transform.GetChild(1).gameObject.SetActive(false);
        MouseManager.enableUpdate();
        SceneManager.LoadScene(scene);

        /*
        if(scene == "Camp")
        {
            if (BowlHandler.getBirdActive())
            {
                BowlHandler.setTrigger();
            }
        }*/
    }


}
