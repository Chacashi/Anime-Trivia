using UnityEngine;
using UnityEngine.UI;

public class ResultsUI : MonoBehaviour
{
    [SerializeField] private GameObject resultsUI;
    [SerializeField] private Image[]  stairs;



    private void OnEnable()
    {
        PointsManager.OnSendPoints += GetResults;
    }

    private void OnDisable()
    {
        PointsManager.OnSendPoints -= GetResults;
    }


    void GetResults(int points)
    {
        resultsUI.SetActive(true);

        if (points == 10)
        {
            for (int i = 0; i < stairs.Length; i++)
            {
                stairs[i].gameObject.SetActive(true);
            }
        }
        else if (points < 10 && points > 5)
        {
            stairs[0].gameObject.SetActive(true);
            stairs[1].gameObject.SetActive(true);
        }
        else if (points > 1 && points <= 5)
        {
            stairs[0].gameObject.SetActive(true);
        }
        else
            Debug.Log("Muy bajo");
            

    }


}
