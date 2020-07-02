using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    string Desc = "A Simple Flower . ";

    private void OnMouseEnter()
    {
        CommunicationSystem.Instance.Notify(Desc);
        Pointer.Instance.ChangeState(CursorState.Grab);
    }

    private void OnMouseExit()
    {
        Pointer.Instance.ChangeState(CursorState.Idle);
    }


}
