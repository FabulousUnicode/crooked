using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHandler : MonoBehaviour
{
    public GameObject boss_base;
    public static bool boss_active = false;

    public GameObject bossEye;
    public GameObject bossPupil;
    public GameObject bossMouth;
    public GameObject bossCross;
    public GameObject Music;


    public static bool eyeActive;
    public static bool pupilActive;
    public static bool mouthActive;
    public static bool crossActive;

    public static bool fedCorn;

    // Update is called once per frame
    void Update()
    {

        if (boss_active == true)
        {
            bossEye.SetActive(eyeActive);
            bossPupil.SetActive(pupilActive);
            bossCross.SetActive(crossActive);
            bossMouth.SetActive(mouthActive);
            Music.SetActive(true);
        }
        else
        {
            boss_base.SetActive(false);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        eyeActive = true;
        mouthActive = false;
    }


    public static void handleInteraction(Item bodyPart, Item usedItem) 
    {
        if (bodyPart.itemName == "Auge")
        {
            if (usedItem == null && crossActive)
            {
                Inventory.instance.addItem(ItemDatabaseInstance.getItemByName("cross"));
                eyeActive = true;
                crossActive = false;
            }
            else
            {
                if (usedItem.itemName == "Sense" && crossActive == false)
                {
                    eyeActive = false;
                    pupilActive = false;
                }
                if (usedItem.itemName == "Kreuz" && eyeActive)
                {
                    Inventory.instance.removeItem(usedItem);
                    crossActive = true;
                }
                if (usedItem.itemName == "Kamera")
                {
                    if(eyeActive && crossActive && pupilActive)
                    {
                        defeated();
                    }
                    if(eyeActive && pupilActive && crossActive == false)
                    {
                        eyeActive = false;
                    }
                    else
                    {
                        //donNothing
                    }
                }
            }
        }

        if(bodyPart.itemName == "Mund")
        {
            if(usedItem == null)
            {
                // trigger dialog
                mouthActive = true;
                eyeActive = true;
                if (fedCorn)
                {
                    pupilActive = true;
                }
            }

            if(usedItem.itemName == "Mutterkorn" && mouthActive && !eyeActive)
            {
                eyeActive = true;
                pupilActive = true;
                fedCorn = true;
                Inventory.instance.removeItem(usedItem);
            }
            else
            {
                mouthActive = false;
            }
        }
        ItemInteraction.resetLastUsed();
    }

    private static void defeated()
    {
        SceneManager.LoadScene("EndScreen");
    }


}
