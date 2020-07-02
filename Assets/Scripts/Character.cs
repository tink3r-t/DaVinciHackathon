using System;
using System.Collections.Generic;
using UnityEngine;

enum CState {
    Idle,
    Talking
};

[System.Serializable]
public class Character : MonoBehaviour
{

    public string text = "Hi!";

    public Sprite frameImage;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        CommunicationSystem.Instance.Talk(this.name ,text , animator,frameImage);
    }

    public void Talk(string ctext) {
        CommunicationSystem.Instance.Talk(this.name, ctext, animator, frameImage);
    }

    public void Talk(string ctext, Action callback )
    {
        CommunicationSystem.Instance.Talk(this.name, ctext, animator, frameImage , callback);
    }


    private void OnMouseEnter()
    {
        Pointer.Instance.ChangeState(CursorState.Talk);
    }

    private void OnMouseExit()
    {
        Pointer.Instance.ChangeState(CursorState.Idle);
    }

}
