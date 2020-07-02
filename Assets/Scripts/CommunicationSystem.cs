using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CommunicationSystem : MonoBehaviour
{

    public static CommunicationSystem Instance;

    [SerializeField]
    private TextMeshPro heading;
    [SerializeField]
    private TextMeshPro descritption;
    [SerializeField]
    private TextMeshPro simpleDescription;
    [SerializeField]
    private SpriteRenderer frameImage;

    [SerializeField]
    private SelectionSystem selectionSystem;
    [SerializeField]
    private List<TextMeshPro> opts;


    private void Start()
    {
        Instance = this;
        Clear();
        Hide();
    }

    public void Show() {
        this.transform.DOLocalMoveY(-3.54f, Preferences.NotificationShowSpeed);
    }

    public void Hide()
    {
        Clear();
        this.transform.DOLocalMoveY(-6.32f, Preferences.NotificationShowSpeed);
    }

    public void Talk(string headingS, string text, Animator character, Sprite characterFrameImage, Action callback = null) {
        Clear();
        heading.text = headingS;
        frameImage.sprite = characterFrameImage;
        this.transform.DOLocalMoveY(-3.54f, Preferences.NotificationShowSpeed).OnComplete(() => {
            character.SetBool("talking", true);
            descritption.DOText(text, text.Length * Preferences.TextSpeed, false, ScrambleMode.None).SetEase(Ease.Linear).OnComplete( ()=> { character.SetBool("talking", false); callback?.Invoke(); });
           
        });
    }

    public void InternalMonolouge(string headingS, string text, Action callback = null)
    {
        Clear();
        heading.text = headingS;
        this.transform.DOLocalMoveY(-3.54f, Preferences.NotificationShowSpeed).OnComplete(() => {
            descritption.DOText(text, text.Length * Preferences.TextSpeed, false, ScrambleMode.None).SetEase(Ease.Linear).OnComplete(() => { callback?.Invoke(); });
        });
    }


    public void Notify(string text, Action callback = null)
    {
        Clear();
        Show();
        simpleDescription.gameObject.SetActive(true);
        simpleDescription.DOText(text, text.Length * Preferences.TextSpeed, false, ScrambleMode.None).SetEase(Ease.Linear).OnComplete(()=> { callback?.Invoke(); } );
    }

    public void Clear() {
        frameImage.sprite = null;
        heading.text = "";
        descritption.text = "";
        simpleDescription.text = "";
        for (int i = 0; i < 3; i++)
            opts[i].text = "";
    }

    public void AskUser(string opt1, string opt2, string opt3, Action<int> c)
    {
        Clear();
        Show();
        selectionSystem.showOptions(opt1,opt2,opt3,c);
    }

}
