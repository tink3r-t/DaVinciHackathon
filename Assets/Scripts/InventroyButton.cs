using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventroyButton : MonoBehaviour
{
    

    private void OnMouseDown()
    {
        InventorySystem.Instance.UpdateState(!InventorySystem.Instance.openUI);
    }

    private void OnMouseEnter()
    {
        Pointer.Instance.ChangeState(CursorState.LookAt);
    }

    private void OnMouseExit()
    {
        Pointer.Instance.ChangeState(CursorState.Idle);
    }
}
