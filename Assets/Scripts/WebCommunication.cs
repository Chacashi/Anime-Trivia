using UnityEngine;

public class WebCommunication : MonoBehaviour
{
    public void DestroyGame(string message)
    {
        if(message == "Destroy")
        {
           Application.Quit();  
        }
    }
}
