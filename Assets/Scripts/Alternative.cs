using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Alternative : MonoBehaviour
{   private Button button;
    private int id;
    private string text;
    public AlternativeData alternativeData { get;set; }
    public static event Action OnCorrectAnswerChoose;
    public static event Action OnChooseAnswer;

    public int ID => id;
   


    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        GameManager.OnSetDataOfQuestion += SetData;
    }
    
    private void OnDisable()
    {
        GameManager.OnSetDataOfQuestion -= SetData;
    }
    private void Start()
    {
        button.onClick.AddListener(CheckID);
    }

    void CheckID()
    {
        if (id == 1)
        {
            OnCorrectAnswerChoose?.Invoke();
            AudioManager.Instance.PlaySFX(1);
        }
        else
            AudioManager.Instance.PlaySFX(2);

        OnChooseAnswer?.Invoke();

    }

    private void SetData()
    {
        id = alternativeData.id;
        text = alternativeData.text;
      
    }



}
