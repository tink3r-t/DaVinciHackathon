using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickableItem : MonoBehaviour
{
    public string name = "Rose";
    public Sprite image; 

    bool clicked = false;

    private void OnMouseDown()
    {
        if (!clicked)
        {
            Vector3 endVal = InventorySystem.Instance.AddItem(new InventoryItem(name, image));
            this.transform.SetParent(InventorySystem.Instance.inventoryUI.transform, true);
            this.transform.DOLocalMove(endVal, InventorySystem.flyAnimDuration);
            Destroy(this, InventorySystem.flyAnimDuration);
        }
        clicked = true;
    }

    private void OnMouseEnter()
    {
        Pointer.Instance.ChangeState(CursorState.Grab);
    }

    private void OnMouseExit()
    {
        Pointer.Instance.ChangeState(CursorState.Idle);
    }

}
