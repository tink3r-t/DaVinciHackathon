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

    public void Notify(string headingS, string text) {
        Clear();
        Show();
        heading.text = headingS;
        descritption.DOText(text, text.Length * Preferences.TextSpeed, false, ScrambleMode.None);
    }

    public void Notify(string text)
    {
        Clear();
        Show();
        simpleDescription.gameObject.SetActive(true);
        simpleDescription.DOText(text, text.Length * Preferences.TextSpeed , false, ScrambleMode.None); 
    }

    public void Clear() {
        heading.text = "";
        descritption.text = "";
        simpleDescription.text = "";
    }

}
