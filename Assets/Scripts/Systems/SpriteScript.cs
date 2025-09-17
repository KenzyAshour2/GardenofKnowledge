using UnityEngine;
using UnityEngine.EventSystems;

public class SpriteScript : MonoBehaviour
{
    public bool IsDragging;
    [SerializeField] public GameObject Tree;

    public void Update()
    {
        if (IsDragging == true)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; 
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);

            if (Input.GetMouseButtonUp(0))
            {
                IsDragging = false;

                Instantiate(Tree, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}