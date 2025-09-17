using UnityEngine;

public class UISpriteManager : MonoBehaviour
{
   
    public GameObject Prefab;
    public Transform SpriteParent;
   

    public void drag()
    {
      
        GameObject sprite = Instantiate(Prefab, SpriteParent.transform);

        sprite.GetComponent<SpriteScript>().IsDragging = true;
    }


}