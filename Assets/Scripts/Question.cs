using UnityEngine;
[CreateAssetMenu (fileName = "New Question", menuName = "ScriptableObjects/Question")]
public class Question : ScriptableObject
{
    public string questionText;
    public AlternativeData[] anwers;
}
