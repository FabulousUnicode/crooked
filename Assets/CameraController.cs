using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController camController;

    [SerializeField] private float cameraSpeed = 10.0f;
    [SerializeField] private float scrollingZone = 10.0f; //Width of the scrolling zone in percent (relative to screen size)

    private static bool inventoryOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (!inventoryOpen)
        {
            Vector3 pos = transform.position;

            if (Input.mousePosition.x <= Screen.width * (scrollingZone / 100.0f))
            {
                pos.x -= cameraSpeed * Time.deltaTime * 100;
            }

            if (Input.mousePosition.x >= Screen.width - Screen.width * (scrollingZone / 100.0f))
            {
                pos.x += cameraSpeed * Time.deltaTime * 100;
            }

            transform.position = pos;
        }
    }

    public static void setInventoryOpen(bool invOpen)
    {
        inventoryOpen = invOpen;
    }

    public static bool getInventoryOpen()
    {
        return inventoryOpen;
    }
}


