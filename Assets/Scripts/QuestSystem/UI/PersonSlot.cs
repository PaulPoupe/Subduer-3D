using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PersonSlot : MonoBehaviour, IDropHandler
{
    public int index;
    public Person pastPerson;
    public event Action<Person, int> OnPastPerson;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0 && eventData.pointerDrag.GetComponent<CardMoving>() != null)
        {
            GameObject dropped = eventData.pointerDrag;
            CardMoving cardMoving = dropped.GetComponent<CardMoving>();
            cardMoving.parentAfterDrag = transform;
            try { OnPastPerson.Invoke(dropped.GetComponent<PersonCardUI>().person, index); }
            catch { }
        }
    }

}
