using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton : MonoBehaviour , IPointerDownHandler,IPointerUpHandler 
{
    public bool printed;


    public void OnPointerDown(PointerEventData eventData)
    {
        printed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        printed = false;
    }
}
