
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
    //public ItemInstance itemInstance;
    public Inventory inventory;
    public RaycastHit2D hit;
    public GameObject kommentar;
    public Animator kanima;
    //Text kommentartext;
    public ContextMenuHandler contextMenu;

    public GameObject hText;



    // Start is called before the first frame update
    void Start()
    {
        /*
        kommentartext = kommentar.transform.GetChild(0).GetComponent<Text>();
        kommentartext.text = "Hallo"; */

    }

    // Update is called once per frame
    void Update()
    {
        //Pr�ft ob Canvas dr�ber liegt
        if (EventSystem.current.IsPointerOverGameObject()) return;

        //ItemInteraction.setLastUsed(null);
        mousePos = Input.mousePosition;
        mousePosWorld = mainCam.ScreenToWorldPoint(mousePos);

        hit = Physics2D.Raycast(new Vector2(mousePosWorld.x, mousePosWorld.y), new Vector2(0,0));

        if (hit)
        {
            GameObject gObject = hit.collider.gameObject;
            //print(hit.collider.name);

            
            if(gObject.name != "Background")
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
                if (contextMenu.isActive())
                {
                    contextMenu.setStatus(false);
                }
                Player.agent.ResetPath();
                Player.agent.SetDestination(hit.point);
                StartCoroutine("waitt", gObject);
            }

            //rechte Taste
            else if(Input.GetMouseButtonUp(1))
            {
                //if (gObject.HasComponent<InteractableItem>())
                {
                    contextMenu.handleMenu(mousePos, gObject.GetComponent<InteractableItem>(), gObject, hit);
                }


                /*
                if(gObject.HasComponent<Anschauen>())
                {
                    gObject.GetComponent<Anschauen>().AnschauenStart();
                }*/
            }
            //mittlere Taste
            else if(Input.GetMouseButtonUp(2))
            {
                if (gObject.HasComponent<Anschauen>())
                {
                    gObject.GetComponent<Anschauen>().AnschauenEnde();
                }
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
            InteractableItem item = gObject.GetComponent<InteractableItem>();
            if (item.item.collectable == true)
            {
                if (inventory.searchItem(item.name)) { return; }
                inventory.addItem(item.item);

                // kommentartext.text = item.item.description;
                //kanima.SetBool("IsOpen", true);
                //StartCoroutine("kommanima");
                FindObjectOfType<Dialog>().showText(item.item.description);
                Destroy(gObject.gameObject);
                ScenenChange.remove += (item.item.name + ",");
            }

            if(item.item.collectable == false)
            {
                Debug.Log("item clicked: " +  item.item.name);
                ItemInteraction.useItemWithSelected(item);
                
            }

            
            //print(ScenenChange.remove);

        }
        else if (gObject.HasComponent<CharacterInfo>())
        {
            FindObjectOfType<Dialog>().StartDialogue(gObject.GetComponent<CharacterInfo>().character.inkFile, gObject.GetComponent<CharacterInfo>().character);
        }
        else if (gObject.HasComponent<ScenenChange>())
        {
            gObject.GetComponent<ScenenChange>().wechsel();
        }
        else if (gObject.HasComponent<Licht>())
        {
            gObject.GetComponent<Licht>().aktivieren();  
        }
        else
        {

        }

        ItemInteraction.resetLastUsed();
        InventorySlotController.resetCurrentSelected();
    }

    IEnumerator kommanima()
    {
        yield return new WaitForSeconds(3.0f);
        kanima.SetBool("IsOpen", false);
    }

    IEnumerator waitt(GameObject obj)
    {
        //Debug.Log(Player.agent.remainingDistance);
        yield return new WaitUntil(() => Player.agent.pathPending == false);
        yield return new WaitUntil(() => Player.agent.remainingDistance <= 10);

        if (obj != null && Player.agent.hasPath)
        {
            left(obj);
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
