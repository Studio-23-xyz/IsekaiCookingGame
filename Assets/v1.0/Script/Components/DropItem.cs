using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform itemBeingDragged = eventData.pointerDrag.GetComponent<RectTransform>();
        itemBeingDragged.SetParent(transform);
       // itemBeingDragged.localPosition = Vector3.zero;
       itemBeingDragged.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        Debug.Log($" Droped!");
    }
}