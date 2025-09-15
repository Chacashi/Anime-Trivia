using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public void ChangueScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
}
