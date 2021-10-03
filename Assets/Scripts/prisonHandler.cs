using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prisonHandler : MonoBehaviour
{
    public Sprite offen;
    public Sprite zu;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void handleInteraction()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = offen;
        GameObject.Find("Gittertuer").transform.position = new Vector3(-266.0f, 20.0f, -0.12f);
    }

    public void closeGitter()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = zu;
        GameObject.Find("Gittertuer").transform.position = new Vector3(-210.0f, 0.0f, -0.12f);
    }
}
