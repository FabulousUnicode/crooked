using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float cameraSpeed = 10.0f;
    [SerializeField] private float scrollingZone = 10.0f; //Width of the scrolling zone in percent (relative to screen size)

    // Update is called once per frame
    void Update()
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
