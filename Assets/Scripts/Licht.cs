using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Licht : MonoBehaviour
{
    public Sprite standard;
    public Sprite aktiv;
    public int nummer;

    private SpriteRenderer spriteRenderer;

    public void aktivieren()
    {
        //if (!LichterAnschalten.lampen[nummer])
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = aktiv;
            //LichterAnschalten.lampen[nummer] = true;
        }
           
    }

    void Start()
    {
        if(LichtAnschalten.aktiviert)
        {
            GameObject asd = gameObject.transform.GetChild(0).gameObject;

              asd.SetActive(true);

              spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = aktiv; 
        }
        //if (LichterAnschalten.lampen[nummer])
        {
            
        }
    }
}
