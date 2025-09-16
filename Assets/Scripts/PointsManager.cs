using System;
using UnityEngine;
using UnityEngine.Rendering;

public class PointsManager : MonoBehaviour
{
    private int points = 0;
    public static event Action<int> OnSendPoints;
    private void OnEnable()
    {
        Alternative.OnCorrectAnswerChoose += AddPoints;
        GameManager.OnGameEnd += SendPoints;
    }

    private void OnDisable()
    {
        Alternative.OnCorrectAnswerChoose -= AddPoints;
        GameManager.OnGameEnd -= SendPoints;
    }

   
    void AddPoints()
    {
        points++;
    }

    void SendPoints()
    {
        OnSendPoints?.Invoke(points);
    }
    
}
