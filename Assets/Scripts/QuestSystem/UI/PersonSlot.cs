using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace QuestSystem
{
    public class PersonSlot : MonoBehaviour, IDropHandler
    {
        public int? index;
        public Person pastPerson;
        public event Action<GameObject, int> OnPastPerson;

        public void OnDrop(PointerEventData eventData)
        {
            if (transform.childCount == 0 && eventData.pointerDrag.GetComponent<CardMoving>() != null)
            {
                GameObject dropped = eventData.pointerDrag;
                CardMoving cardMoving = dropped.GetComponent<CardMoving>();
                cardMoving.parentAfterDrag = transform;

                if (index != null)
                    OnPastPerson.Invoke(dropped, (int)index);

            }
        }

    }
}
