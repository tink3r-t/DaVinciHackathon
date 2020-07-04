using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

enum CState {
    Idle,
    Talking
};
[Serializable]
public class Character : MonoBehaviour
{
    public UnityEvent ccItem;
    public string text = "Hi!";
    public string textDE = "Hi!";


    public Sprite frameImage;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (Preferences.LanguageInt == (int)LANGUAGE.EN)
            CommunicationSystem.Instance.Talk(this.name, text, animator, frameImage, () => { CommunicationSystem.Instance.Hide(); });
        else
            CommunicationSystem.Instance.Talk(this.name, textDE, animator, frameImage, () => { CommunicationSystem.Instance.Hide(); });
    }

    public void Talk(string ctext) {
        CommunicationSystem.Instance.Talk(this.name, ctext, animator, frameImage);
    }

    public void Talk(string ctext, Action callback )
    {
        CommunicationSystem.Instance.Talk(this.name, ctext, animator, frameImage , callback);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Item item = collision.otherCollider.gameObject.GetComponent<Item>();
        //if (item)
        {
            ccItem.Invoke();
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void dosts()
    {

            ccItem.Invoke();
            this.GetComponent<BoxCollider2D>().enabled = false;
        
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
