
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour
{
    public Vector3 mousePos;
    public Vector3 mousePosWorld;
    public Camera mainCam;
    //public ItemInstance itemInstance;
    public Inventory inventory;
    public RaycastHit2D hit;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ItemInteraction.setLastUsed(null);
            mousePos = Input.mousePosition;
            mousePosWorld = mainCam.ScreenToWorldPoint(mousePos);

            hit = Physics2D.Raycast(new Vector2(mousePosWorld.x, mousePosWorld.y), new Vector2(0,0));

            if (hit.collider != null)
            {
                print(hit.collider.name);
                CollectableItem item = hit.collider.GetComponent<CollectableItem>();
                inventory.addItem(item.item);
                Destroy(hit.collider.gameObject);

            }
        }
    }
}
