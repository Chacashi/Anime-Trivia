using UnityEngine;
using System.Collections; 

public class WebCommunication : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    public void DestroyGame()
    {
        Debug.Log("Mensaje recibido desde React: Solicitando cierre.");


        StartCoroutine(QuitGameCoroutine());
    }

    private IEnumerator QuitGameCoroutine()
    {

        yield return null;

#if UNITY_WEBGL

        Application.Quit();
#elif UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}