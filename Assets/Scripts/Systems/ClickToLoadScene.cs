using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToLoadScene : MonoBehaviour
{
    [SerializeField] int sceneToLoad;
    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("Scene Loaded: " + sceneToLoad);
    }
}