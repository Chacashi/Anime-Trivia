using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PanelQuestion[] arrayPanelQuestions;
    [SerializeField] private Button trueBt;
    [SerializeField] private Button falseBt;
    [SerializeField] private Image imageQuestion;
    [SerializeField] private TMP_Text textQuestion;
    [SerializeField] private int currentQuestionIndex = 0;
    [SerializeField] private Image blockImage;

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
        AudioManager.Instance.playAudio(arrayPanelQuestions[index].audioClip);
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
            StartCoroutine(WaitAndNext());
        else
            StartCoroutine(WaitAndResults());

    }


    IEnumerator WaitAndNext()
    {
        blockImage.raycastTarget= true;
        if(trueBt.GetComponent<Alternative>().ID ==1)
            falseBt.interactable= false;
        else
            trueBt.interactable= false;

        yield return new WaitForSeconds(2f);
        SetQuestion(currentQuestionIndex);
        blockImage.raycastTarget= false;
        trueBt.interactable= true;
        falseBt.interactable= true;
    }

    IEnumerator WaitAndResults()
    {
        if (trueBt.GetComponent<Alternative>().ID == 1)
            falseBt.interactable = false;
        else
            trueBt.interactable = false;
        blockImage.raycastTarget = true;
        yield return new WaitForSeconds(2f);
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

    public void ChangueEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
