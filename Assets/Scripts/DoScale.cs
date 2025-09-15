using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
public class DoScale : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private Vector3 doScale;
    [SerializeField] private float timeToScale;
    private Transform myTransform;
    private Vector3 myScale;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ScaleTransform(doScale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       ScaleTransform(myScale);
    }

    private void Awake()
    {
       myTransform = GetComponent<Transform>();
    }


    private void ScaleTransform(Vector3 scaleTo)
    {
        myScale = myTransform.localScale;
        myTransform.DOScale(scaleTo, timeToScale);
    }


}
