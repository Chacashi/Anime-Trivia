using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "PanelQuestion", menuName = "ScriptableObjects/PanelQuestion", order = 1)]
public class PanelQuestion : ScriptableObject
{
    public Sprite image;
    public AudioClip audioClip;
    public Question question;
}
