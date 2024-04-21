using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardMoving : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    [SerializeField]
    private Image cardImage;
    private Vector3 mouseDragStartPos;
    public PointerEventData.InputButton dragMousButton;
    [HideInInspector]
    public Transform parentAfterDrag;
    public event Action<Person> OnDeletePerson;


    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == dragMousButton)
            transform.localPosition = Input.mousePosition - mouseDragStartPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == dragMousButton)
        {
            try { OnDeletePerson.Invoke(gameObject.GetComponentInChildren<PersonCardUI>().person); } catch { }
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            mouseDragStartPos = Input.mousePosition - transform.localPosition;
            transform.SetAsLastSibling();
            cardImage.raycastTarget = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        cardImage.raycastTarget = true;
    }
}
