using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GemSlotsController : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject != null && droppedObject.GetComponent<DiceController>() != null)
        {
            // Manipulate the slot with the data from the energy block
            Debug.Log("Energy Block dropped on slot!");
        }
    }
}
