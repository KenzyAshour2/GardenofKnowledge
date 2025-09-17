using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
public class MobileCameraController : MonoBehaviour
{

    [SerializeField] Camera cam;

    private Vector3 dragOrigin;

    [SerializeField] private float zoomStep, minCamSize, maxCamSize;


    private void Update()

    {

        if (!EventSystem.current.IsPointerOverGameObject())

        {

            PanCamera();

            ZoomWithMouseScroll();

        }

    }

    private void PanCamera()

    {

        if (Input.GetMouseButtonDown(0))

        {

            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        }

        if (Input.GetMouseButton(0))

        {

            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);



            //cam.transform.position = ClampCamera(cam.transform.position);

            cam.transform.position += difference;

        }

    }
    private void ZoomWithMouseScroll()

    {

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");



        if (scrollInput > 0f)

        {



            ZoomIn();

        }

        else if (scrollInput < 0f)

        {



            ZoomOut();

        }

    }

    public void ZoomIn()

    {

        float newSize = cam.orthographicSize - zoomStep;

        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        // cam.transform.position = ClampCamera(cam.transform.position)

    }

    public void ZoomOut()

    {

        float newSize = cam.orthographicSize + zoomStep;

        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        //cam.transform.position = ClampCamera(cam.transform.position);

    }

}
