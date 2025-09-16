using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PanelQuestion[] arrayPanelQuestions;
    [SerializeField] private Button trueBt;
    [SerializeField] private Button falseBt;
    [SerializeField] private Image imageQuestion;
    [SerializeField] private TMP_Text textQuestion;
    [SerializeField] private int currentQuestionIndex = 0;

    public static event Action OnGameEnd;
    public static event Action OnSetDataOfQuestion;
    private void Start()
    {
        SetQuestion(currentQuestionIndex);
    }

    private void OnEnable()
    {
        Alternative.OnChooseAnswer += SetNextQuestion;
    }

    private void OnDisable()
    {
        Alternative.OnChooseAnswer -= SetNextQuestion;
    }
    public void SetQuestion(int index)
    {
        textQuestion.text = arrayPanelQuestions[index].question.questionText;
        imageQuestion.sprite = arrayPanelQuestions[index].image;

        trueBt.GetComponent<Alternative>().alternativeData = arrayPanelQuestions[index].question.anwers[0];
        falseBt.GetComponent<Alternative>().alternativeData = arrayPanelQuestions[index].question.anwers[1];
        OnSetDataOfQuestion?.Invoke();
        trueBt.GetComponentInChildren<TMP_Text>().text = arrayPanelQuestions[index].question.anwers[0].text;
        falseBt.GetComponentInChildren<TMP_Text>().text = arrayPanelQuestions[index].question.anwers[1].text;
    }

    private void SetNextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < arrayPanelQuestions.Length)
            SetQuestion(currentQuestionIndex);
        else
            OnGameEnd?.Invoke();
    }


    public void RestartGame()
    {
        currentQuestionIndex = 0;
        SetQuestion(currentQuestionIndex);
        SceneManager.LoadScene("Game");
    }

    public void PlaySFX(int index)
    {
        AudioManager.Instance.PlaySFX(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
