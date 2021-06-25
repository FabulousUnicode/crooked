
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
    Text kommentartext;

    public GameObject hText;



    // Start is called before the first frame update
    void Start()
    {
        kommentartext = kommentar.transform.GetChild(0).GetComponent<Text>();
        kommentartext.text = "Hallo";
    }

    // Update is called once per frame
    void Update()
    {
        //Pr�ft ob Canvas dr�ber liegt
        if (EventSystem.current.IsPointerOverGameObject()) return;

        ItemInteraction.setLastUsed(null);
        mousePos = Input.mousePosition;
        mousePosWorld = mainCam.ScreenToWorldPoint(mousePos);

        hit = Physics2D.Raycast(new Vector2(mousePosWorld.x, mousePosWorld.y), new Vector2(0,0));

        


        if (hit)
        {
            GameObject gObject = hit.collider.gameObject;
            //print(hit.collider.name);
            
            if(gObject.name != "bg_randysHut")
            {
                hText.SetActive(true);
                hText.transform.GetChild(0).GetComponent<Text>().text = gObject.name;
                hText.transform.position = mousePosWorld + new Vector3(0, 30, 1);
            }
            else
            {
                hText.SetActive(false);
            }
            




            //linke Taste
            if (Input.GetMouseButtonUp(0))
            {
                if (gObject.HasComponent<CollectableItem>())
                {
                    CollectableItem item = hit.collider.GetComponent<CollectableItem>();
                    inventory.addItem(item.item);

                    kommentartext.text = item.item.description;
                    kanima.SetBool("IsOpen", true);
                    StartCoroutine("kommanima");
                    


                    Destroy(hit.collider.gameObject);
                }
                else if(gObject.HasComponent<DialogueTrigger>())
                {
                    hit.collider.GetComponent<DialogueTrigger>().TriggerDia();
                }
                else if(gObject.HasComponent<ScenenChange>())
                {
                    hit.collider.GetComponent<ScenenChange>().wechsel();
                }
                else
                {
                	Player.agent.SetDestination(hit.point);
                }
            }
            //rechte Taste
            else if(Input.GetMouseButtonUp(1))
            {
                if(gObject.HasComponent<Anschauen>())
                {
                    gObject.GetComponent<Anschauen>().AnschauenStart();
                }
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

    IEnumerator kommanima()
    {
        yield return new WaitForSeconds(3.0f);
        kanima.SetBool("IsOpen", false);
    }
    
}




public static class hasComponent
{
    public static bool HasComponent<T>(this GameObject gameObject)where T : Component
    {
        return gameObject.GetComponent<T>() != null;
    }
}
