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
            TouchControls();
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

    private void TouchControls()
    {
        if (Input.touchCount == 1) // single finger drag
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                dragOrigin = cam.ScreenToWorldPoint(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(touch.position);
                cam.transform.position += difference;
            }
        }
        else if (Input.touchCount == 2) // pinch zoom
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find positions in previous frame
            Vector2 touchZeroPrev = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrev = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrev - touchOnePrev).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            if (difference > 0)
                ZoomIn();
            else if (difference < 0)
                ZoomOut();
        }
    }

    public void ZoomIn()
    {
        float newSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }

    public void ZoomOut()
    {
        float newSize = cam.orthographicSize + zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }
}
