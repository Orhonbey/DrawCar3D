using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// Yapımcı - Sunal Orhon
/// Raks Touch UI üzerinden daha rahat dokunma olaylarını alamk için yazılmıştır .
/// </summary>
public class RaksTouch : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IEndDragHandler
{
    #region //----> Variable
    [HideInInspector]
    public Vector2 startPosition;
    [HideInInspector]
    public Vector2 endPosition;
    [HideInInspector]
    public Vector2 currentPosition;
    [HideInInspector]
    public Vector2 deltaPosition;
    [HideInInspector]
    public int pointerId = -5;
    [HideInInspector]
    public bool isEvent;
    public PointerEventData eventData;
    #endregion
    public void OnDrag(PointerEventData eventData)
    {
        deltaPosition = eventData.delta;
        currentPosition = eventData.position;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (pointerId != eventData.pointerId || !isEvent)
        {
            this.eventData = eventData;
            pointerId = eventData.pointerId;
            startPosition = eventData.position;
            currentPosition = eventData.position;
            isEvent = true;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isEvent = false;
        endPosition = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("Test");
    }
}
