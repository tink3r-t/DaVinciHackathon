using System.Collections;
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
        this.transform.DOLocalMoveY(-6.32f, Preferences.NotificationShowSpeed);
    }

    public void Talk(string headingS, string text, Animator character, Sprite characterFrameImage) {
        Clear();
        heading.text = headingS;
        frameImage.sprite = characterFrameImage;
        this.transform.DOLocalMoveY(-3.54f, Preferences.NotificationShowSpeed).OnComplete(() => {
            character.SetBool("talking", true);
            descritption.DOText(text, text.Length * Preferences.TextSpeed, false, ScrambleMode.None).SetEase(Ease.Linear).OnComplete( ()=> { character.SetBool("talking", false); });
           
        });
    }

    public void Notify(string text)
    {
        Clear();
        Show();
        simpleDescription.gameObject.SetActive(true);
        simpleDescription.DOText(text, text.Length * Preferences.TextSpeed, false, ScrambleMode.None).SetEase(Ease.Linear);
    }

    public void Clear() {
        frameImage.sprite = null;
        heading.text = "";
        descritption.text = "";
        simpleDescription.text = "";
    }

}
