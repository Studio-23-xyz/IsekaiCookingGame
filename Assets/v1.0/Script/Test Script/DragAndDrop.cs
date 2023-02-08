using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    
    private Vector3 startPosition;
    public RectTransform rectTransform;
    

    public CanvasGroup canvasGroup;
    
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
        
        // transform.position = Input.mousePosition;
    }
    
    private void Start()
    {
        startPosition = transform.position;
    }

    

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"End Begain");
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       Debug.Log($"End Drag");
       canvasGroup.blocksRaycasts = true;
       canvasGroup.alpha = 1f;
    }
}