using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events ;
using UnityEngine.EventSystems;
public class MouseOverlapComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public event System.Action<PointerEventData> PointerEnterEvent;
    public event System.Action<PointerEventData> PointerExitEvent;

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnterEvent?.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExitEvent?.Invoke(eventData);
    }
}
