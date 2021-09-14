using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandler : MonoBehaviour
{
    public static bool mouthOpen;
    public static bool eyesOpen;
    public static bool pupilWidened;

    public static bool crossed;

    public GameObject eyes;
    public static SpriteRenderer eyesSprite;

    public GameObject mouth;
    public static SpriteRenderer mouthSprite;    

    public Sprite eyesOpenSprite;
    public Sprite eyesClosedSprite;
    public Sprite pupilWidenedSprite;

    public Sprite eyesOpenWCrossSprite;
    public Sprite eyesClosedWCrossSprite;
    public Sprite pupilWidenedWCrossSprite;

    public Sprite mouthOpenSprite;
    public Sprite mouthClosedSprite;

    


    // Start is called before the first frame update
    void Start()
    {
        mouthOpen = false;
        eyesOpen = true;
        pupilWidened = false;

        crossed = false;

        eyesSprite = eyes.GetComponent<SpriteRenderer>();
        mouthSprite = mouth.GetComponent<SpriteRenderer>();
        
    }


    public static void handleInteraction(Item bodyPart, Item usedItem) 
    {
        if(usedItem == null && bodyPart.itemName == "mouth")
        {
            mouthOpen = true;
            eyesOpen = true;
        }
        else if(usedItem == null && crossed == true)
        {
            crossed = false;
        }
        else
        {
            if (bodyPart.itemName == "eyes" && usedItem.itemName == "scythe")
            {
                eyesOpen = false;
            }

            if(bodyPart.itemName == "eyes" && usedItem.itemName == "cross")
            {
                crossed = true;
            }

            if(bodyPart.itemName == "mouth" && usedItem.itemName == "corn" && mouthOpen == true && eyesOpen == false)
            {
                eyesOpen = true;
                pupilWidened = true;
            }
            if (bodyPart.itemName == "mouth" && usedItem.itemName == "corn" && mouthOpen == true && eyesOpen == true)
            {
                mouthOpen = true;
            }

            if (bodyPart.itemName == "eyes" && usedItem.itemName == "camera" && eyesOpen == true && crossed == true && pupilWidened == true)
            {
                defeated();
            }

        }

        ItemInteraction.resetLastUsed();
        
    }

    private static void defeated()
    {
        Debug.Log("Yeah Baby");
    }

    // Update is called once per frame
    void Update()
    {
        

        if(eyesOpen == true && crossed == false)
        {
            eyesSprite.sprite = eyesOpenSprite;
        }

        if (eyesOpen == true && crossed == true)
        {
            eyesSprite.sprite = eyesOpenWCrossSprite;
        }

        if(eyesOpen == true && pupilWidened == true)
        {
            eyesSprite.sprite = pupilWidenedSprite;
        }

        if (eyesOpen == true && pupilWidened == true && crossed == true)
        {
            eyesSprite.sprite = pupilWidenedWCrossSprite;
        }


        if (eyesOpen == false && crossed == false)
        {
            eyesSprite.sprite = eyesClosedSprite;
        }

        if (eyesOpen == false && crossed == true)
        {
            eyesSprite.sprite = eyesClosedWCrossSprite;
        }



        if (mouthOpen == true)
        {
            mouthSprite.sprite = mouthOpenSprite;
        }
        if(mouthOpen == false)
        {
            mouthSprite.sprite = mouthClosedSprite;
        }

       
    }
}
