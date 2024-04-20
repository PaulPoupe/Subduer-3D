using UnityEngine;
using UnityEngine.EventSystems;

public class WindowMoving : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    Vector3 mouseDragStartPos;
    public PointerEventData.InputButton dragMousButton;

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == dragMousButton)
            transform.localPosition = Input.mousePosition - mouseDragStartPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == dragMousButton)
            mouseDragStartPos = Input.mousePosition - transform.localPosition;
        transform.SetAsLastSibling();
    }

}
