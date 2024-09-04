using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



/***From Dice Controller, add unique functions only for energy dice controller***/
public class EnergyDiceController : DiceController, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


    /***Drag Functions***/
    public void OnBeginDrag(PointerEventData eventData)
    {
            canvasGroup.alpha = 0.6f; // Make the block semi-transparent during drag
            canvasGroup.blocksRaycasts = false; // Allow the block to pass through other UI elements

    }

    public void OnDrag(PointerEventData eventData)
    {

            rectTransform.anchoredPosition += eventData.delta / GetCanvasScaleFactor();

    }

    public void OnEndDrag(PointerEventData eventData)
    {
            canvasGroup.alpha = 1.0f;
            canvasGroup.blocksRaycasts = true;

    }

    private float GetCanvasScaleFactor()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        return canvas.scaleFactor;
    }
}
