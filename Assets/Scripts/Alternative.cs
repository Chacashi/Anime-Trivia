using System;
using UnityEngine;
using UnityEngine.UI;

public class Alternative : MonoBehaviour
{   private Button button;
    private int id;
    private string text;
    public AlternativeData alternativeData { get;set; }
    public static event Action OnCorrectAnswerChoose;
    public static event Action OnChooseAnswer;
   


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
        AudioManager.Instance.PlaySFX(0);
        if (id == 1)
            OnCorrectAnswerChoose?.Invoke();
        OnChooseAnswer?.Invoke();  

    }

    private void SetData()
    {
        id = alternativeData.id;
        text = alternativeData.text;
      
    }

}
