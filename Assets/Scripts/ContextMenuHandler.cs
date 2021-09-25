using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContextMenuHandler : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler//, IPointerUpHandler
{
    [SerializeField] private GameObject contextMenu;
    [SerializeField] private WorldInteraction worldInt;
    private RaycastHit2D hit;
    private static GameObject gObject;
    private static InteractableItem selectedItem;
    private static bool active;

    private Image inspect;
    private Image use;
    private Image pickUp;

    public bool isActive()
    {
        return active;
    }

    public void setStatus(bool state)
    {
        active = state;
    }

    public void handleMenu(Vector3 pos, InteractableItem interactableItem, GameObject gObj, RaycastHit2D hitArg)
    {
        contextMenu.transform.position = new Vector3(pos.x + 150, pos.y - 80, 0);
        //setSelectedItem(interactableItem);
        gObject = gObj;
        hit = hitArg;
        contextMenu.SetActive(true);
        active = true;
    }

    public static void setSelectedItem(InteractableItem item)
    {
        selectedItem = item;
        Debug.Log(selectedItem.item.itemName);
    }


    //wenn Sprites eingesetzt werden ändern zu Image und nicht Text
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "Inspect")
        {
            Debug.Log(selectedItem.item.description);
        }
        if(eventData.pointerCurrentRaycast.gameObject.name == "Use")
        {
            if(gObject.name == "flavia")
            {
                gObject.GetComponent<Flavia>().flavia_combine(ItemInteraction.getLastUsed());
            }
            else if (gObject.name == "mary")
            {
                gObject.GetComponent<Mary>().itemsAnbieten(ItemInteraction.getLastUsed());
            }
        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "PickUp")
        {
            worldInt.setDestination(gObject, hit);
        }


    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        active = false;
    }

    /*
    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }*/

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        use = GameObject.Find("Use").GetComponentInChildren<Image>();
        pickUp = GameObject.Find("Pick Up").GetComponentInChildren<Image>();
        inspect = GameObject.Find("Inspect").GetComponentInChildren<Image>();
        Debug.Log(inspect.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(active == false)
        {
            contextMenu.SetActive(false);
        }
    }
}
