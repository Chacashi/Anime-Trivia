using UnityEngine;
[CreateAssetMenu (fileName = "New Question", menuName = "Question")]
public class Question : ScriptableObject
{
    public string questionText;
    public int[] answers;
}
