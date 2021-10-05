
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WorldInteraction : MonoBehaviour
{
    public Vector3 mousePos;
    public Vector3 mousePosWorld;
    public Camera mainCam;
    public Inventory inventory;
    public RaycastHit2D hit;
    public GameObject hText;



    // Start is called before the first frame update
    void Start()
    {
    }


    Vector3 KeepFullyOnScreen(GameObject panel, Vector3 newPos)
    {
        RectTransform rect = panel.GetComponent<RectTransform>();
        RectTransform CanvasRect = FindObjectOfType<Canvas>().GetComponent<RectTransform>();

        float minX = (CanvasRect.sizeDelta.x - rect.sizeDelta.x) * -0.5f;
        float maxX = (CanvasRect.sizeDelta.x - rect.sizeDelta.x) * 0.5f;
        float minY = (CanvasRect.sizeDelta.y - rect.sizeDelta.y) * -0.5f;
        float maxY = (CanvasRect.sizeDelta.y - rect.sizeDelta.y) * 0.5f;

        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        return newPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(Dialog.dialog_aktive)
        {
            return;
        }

        //Prueft ob Canvas drueber liegt
        if (EventSystem.current.IsPointerOverGameObject()) return;

        //ItemInteraction.setLastUsed(null);
        mousePos = Input.mousePosition;
        mousePosWorld = mainCam.ScreenToWorldPoint(mousePos);

        hit = Physics2D.Raycast(new Vector2(mousePosWorld.x, mousePosWorld.y), new Vector2(0,0));

        if (hit)
        {
            GameObject gObject = hit.collider.gameObject;

            //Ausgabe HoverText
            if(gObject.name != "Background" && gObject.name != "ZelleCollider" && gObject.name != "ShackCollider")
            {
                string hoverInfo = "";

                if (gObject.HasComponent<InteractableItem>()) 
                {
                    hoverInfo = gObject.GetComponent<InteractableItem>().item.itemName;
                }
                else if(gObject.HasComponent<CharacterInfo>())
                {
                    hoverInfo = gObject.GetComponent<CharacterInfo>().character.cName;
                }
                else if(gObject.HasComponent<ScenenChange>())
                {
                    hoverInfo = gObject.GetComponent<ScenenChange>().destinationName;
                }
                else if (gObject.HasComponent<InteractableHotspot>())
                {
                    hoverInfo = gObject.GetComponent<InteractableHotspot>().hotspot.h_name;
                }
                else
                {
                    hoverInfo = gObject.name;
                }

                hText.SetActive(true);
                hText.transform.GetChild(0).GetComponent<Text>().text = hoverInfo;
                hText.transform.position = new Vector3(mousePos.x, mousePos.y + 75, 0);
                
            }
            else
            {
                hText.SetActive(false);
            }
            

            //linke Taste
            if (Input.GetMouseButtonUp(0))
            {
                if (gObject.HasComponent<InteractableHotspot>())
                {
                    if (gObject.GetComponent<InteractableHotspot>().hotspot.walkTo) 
                    {

                        StopCoroutine("waittl");
                        StopCoroutine("waittr");
                        Player.agent.ResetPath();
                        Player.agent.SetDestination(gObject.GetComponent<InteractableHotspot>().hotspot.interactionSpot);
                        StartCoroutine("waittl", gObject);
                    }
                    else
                    {
                        left(gObject);
                    }
                }
                else if (gObject.HasComponent<InteractableItem>())
                {
                    StopCoroutine("waittl");
                    StopCoroutine("waittr");
                    Player.agent.ResetPath();
                    Player.agent.SetDestination(gObject.GetComponent<InteractableItem>().item.interactionPos);
                    StartCoroutine("waittl", gObject);
                }

                else if(gObject.HasComponent<CharacterInfo>())
                {
                    StopCoroutine("waittl");
                    StopCoroutine("waittr");
                    Player.agent.ResetPath();
                    Player.agent.SetDestination(gObject.GetComponent<CharacterInfo>().character.interactionPos);
                    StartCoroutine("waittl", gObject);
                }

                else
                {
                    StopCoroutine("waittl");
                    StopCoroutine("waittr");
                    Player.agent.ResetPath();
                    Player.agent.SetDestination(hit.point);
                    StartCoroutine("waittl", gObject);
                }
            }

            //rechte Taste
            else if(Input.GetMouseButtonUp(1))
            {
                if (gObject.HasComponent<InteractableHotspot>())
                {
                    if (gObject.GetComponent<InteractableHotspot>().hotspot.walkTo)
                    {
                        StopCoroutine("waittl");
                        StopCoroutine("waittr");
                        Player.agent.ResetPath();
                        Player.agent.SetDestination(gObject.GetComponent<InteractableHotspot>().hotspot.interactionSpot);
                        StartCoroutine("waittr", gObject);
                    }
                    else
                    {
                        right(gObject);
                    }
                }
                else if (gObject.HasComponent<InteractableItem>())
                {
                    StopCoroutine("waittl");
                    StopCoroutine("waittr");
                    Player.agent.ResetPath();
                    Player.agent.SetDestination(gObject.GetComponent<InteractableItem>().item.interactionPos);
                    StartCoroutine("waittr", gObject);
                }

                else if (gObject.HasComponent<CharacterInfo>())
                {
                    StopCoroutine("waittl");
                    StopCoroutine("waittr");
                    Player.agent.ResetPath();
                    Player.agent.SetDestination(gObject.GetComponent<CharacterInfo>().character.interactionPos);
                    StartCoroutine("waittr", gObject);
                }

                else
                {
                    StopCoroutine("waittl");
                    StopCoroutine("waittr");
                    Player.agent.ResetPath();
                    Player.agent.SetDestination(hit.point);
                    StartCoroutine("waittr", gObject);
                }
            }

            //mittlere Taste
            else if(Input.GetMouseButtonUp(2))
            {
            }
            else
            {
            }
        }
        else
        {
            hText.SetActive(false);
        }

    }

    private void right(GameObject gObject)
    {

        if (gObject.HasComponent<InteractableItem>())
        {
            InteractableItem item = gObject.GetComponent<InteractableItem>();
            if (item.item.collectable == true)
            {
                if (inventory.searchItem(item.name)) { return; }
                inventory.addItem(item.item);

                //FindObjectOfType<Dialog>().showText(item.item.description);

                Destroy(gObject.gameObject);
                ScenenChange.remove += (item.name + ",");
            }

            if (item.item.collectable == false)
            {
                Debug.Log("item clicked: " + item.item.name);
                ItemInteraction.useItemWithSelected(item);
            }
        }
        else if (gObject.HasComponent<CharacterInfo>())
        {
            if (gObject.name == "flavia")
            {
                gObject.GetComponent<Flavia>().flavia_combine(ItemInteraction.getLastUsed());
            }
            else if (gObject.name == "mary")
            {
                gObject.GetComponent<Mary>().itemsAnbieten(ItemInteraction.getLastUsed());
            }
            else if (gObject.name == "Robbe")
            {
                gObject.GetComponent<Robbe>().rumAnbieten(ItemInteraction.getLastUsed());
            }
            else if(gObject.name == "randy_shack")
            {
                gObject.GetComponent<Randy>().verhaften(ItemInteraction.getLastUsed());
            }
        }
        else if (gObject.HasComponent<ScenenChange>())
        {
            gObject.GetComponent<ScenenChange>().wechsel();
        }
        else if (gObject.HasComponent<Licht>())
        {
            //gObject.GetComponent<Licht>().aktivieren();
        }
        else if (gObject.HasComponent<InteractableHotspot>())
        {
            if(ItemInteraction.getLastUsed() == null)
            {
                FindObjectOfType<Dialog>().showText(gObject.GetComponent<InteractableHotspot>().hotspot.use);
            }
            else
            {
                for(int i = 0; i < gObject.GetComponent<InteractableHotspot>().hotspot.specialInteraction.Count; i++)
                {
                    if (ItemInteraction.getLastUsed() == gObject.GetComponent<InteractableHotspot>().hotspot.specialInteraction[i])
                    {
                        FindObjectOfType<Dialog>().showText(gObject.GetComponent<InteractableHotspot>().hotspot.specialInteractionStrings[i]);
                    }
                } 
            }
        }
        else
        {

        }
        ItemInteraction.resetLastUsed();
        InventorySlotController.resetCurrentSelected();
    }

    public void setDestination(GameObject gameObject, RaycastHit2D hit)
    {
        Player.agent.ResetPath();
        Player.agent.SetDestination(hit.point);
        StartCoroutine("waitt", gameObject);
    }


    public void left(GameObject gObject)
    {
        if (gObject.HasComponent<InteractableItem>())
        {
            FindObjectOfType<Dialog>().showText(gObject.GetComponent<InteractableItem>().item.description);
        }
        else if (gObject.HasComponent<CharacterInfo>())
        {
            if (gObject.name == "Gittertuer")
            {
                gObject.GetComponent<prisonHandler>().handleInteraction();
            }

            FindObjectOfType<Dialog>().StartDialogue(gObject.GetComponent<CharacterInfo>().character.inkFile, gObject.GetComponent<CharacterInfo>().character);
        }
        else if (gObject.HasComponent<ScenenChange>())
        {
            gObject.GetComponent<ScenenChange>().wechsel();
        }
        else if (gObject.HasComponent<Licht>())
        {
            //gObject.GetComponent<Licht>().aktivieren();  
        }
        else if(gObject.HasComponent<InteractableHotspot>())
        {
            FindObjectOfType<Dialog>().showText(gObject.GetComponent<InteractableHotspot>().hotspot.inspect);
        }
        else
        {

        }

        ItemInteraction.resetLastUsed();
        InventorySlotController.resetCurrentSelected();
    }


    IEnumerator waittl(GameObject obj)
    {
        
        yield return new WaitUntil(() => Player.agent.pathPending == false);
        yield return new WaitUntil(() => Player.agent.remainingDistance <= 10);

        if (obj != null && Player.agent.hasPath)
        {
            left(obj);
        }
        else if (obj != null && Player.agent.remainingDistance <= 10)
        {
            left(obj);
        }
    }

    IEnumerator waittr(GameObject obj)
    {
        yield return new WaitUntil(() => Player.agent.pathPending == false);
        yield return new WaitUntil(() => Player.agent.remainingDistance <= 10);

        if (obj != null && Player.agent.hasPath)
        {
            right(obj);
        }
        else if(obj != null && Player.agent.remainingDistance <= 10)
        {
            right(obj);
        }
    }
}


public static class hasComponent
{
    public static bool HasComponent<T>(this GameObject gameObject)where T : Component
    {
        return gameObject.GetComponent<T>() != null;
    }
}
