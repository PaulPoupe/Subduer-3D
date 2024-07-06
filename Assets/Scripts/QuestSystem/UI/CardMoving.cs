using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace QuestSystem
{
    public class CardMoving : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler
    {
        [SerializeField]
        private Image card;
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
                Person person = gameObject.GetComponentInChildren<PersonCardUI>().person;
                if (person.position != null) { OnDeletePerson.Invoke(person); }

                parentAfterDrag = transform.parent;
                transform.SetParent(transform.root);
                mouseDragStartPos = Input.mousePosition - transform.localPosition;
                transform.SetAsLastSibling();
                card.raycastTarget = false;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(parentAfterDrag);
            card.raycastTarget = true;
        }
    }
}
