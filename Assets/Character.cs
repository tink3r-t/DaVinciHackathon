using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CState {
    Idle,
    Talking
};

public class Character : MonoBehaviour
{

    public Sprite frameImage;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        //animator.SetBool("talking", true);
        CommunicationSystem.Instance.Talk(this.name , "Hi! Inventory works fine in full screen mode. And yes I am still working :p !", animator,frameImage);
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
