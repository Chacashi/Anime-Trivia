using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public void ChangueScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }


    public void playSFX(int index)
    {
        AudioManager.Instance.PlaySFX(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
