using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CState {
    Idle,
    Talking
};

public class Character : MonoBehaviour
{

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        animator.SetBool("talking", true);
        CommunicationSystem.Instance.Notify("Mystic  :","Inside this door lies what you seek!");
    }

    private void OnMouseEnter()
    {
        Pointer.Instance.ChangeState(CursorState.Talk);
    }

    private void OnMouseExit()
    {
        //animator.SetBool("talking", false);
        //CommunicationSystem.Instance.Hide();
        Pointer.Instance.ChangeState(CursorState.Idle);
    }

}
