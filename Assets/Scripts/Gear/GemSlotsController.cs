using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GemSlotsController : MonoBehaviour,IDropHandler
{
    public TextMeshProUGUI energyText;
    private int energyInput;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject != null && droppedObject.GetComponent<DiceController>() != null)
        {
            energyInput = droppedObject.GetComponent<DiceController>().currentFace;
            energyText.text = energyInput.ToString();
        }
    }
}
