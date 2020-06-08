using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    private void OnMouseEnter()
    {
        CommunicationSystem.Instance.Notify("A Simple Flower . ");
        Pointer.Instance.ChangeState(CursorState.Grab);
    }

    private void OnMouseExit()
    {
        Pointer.Instance.ChangeState(CursorState.Idle);
    }


}
