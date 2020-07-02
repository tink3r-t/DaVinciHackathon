using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EventSystem : MonoBehaviour
{
    public EffectsSystem eS;

    public List<Character> persons;
    public List<Character> witches;

    public SpriteRenderer BG;
    public Sprite bg1s;

    public GameObject animatedBGObjects;

    public List<Transform> envChangeObjs;

    public Scene1ObjectsAnimation s1a;

    public Transform normalCurtain;
    public GameObject normalStart;
    public GameObject otherThings;
    public BoxCollider2D romeo;

    public void HandleEvent(Action ac, char eT, string arg1 = "", string arg2= "") {
        switch (eT){
            case 'T':
                StartCoroutine( TransformCharacter(int.Parse(arg1), ac));
                CommunicationSystem.Instance.Notify(arg2);
                break;
            case 'C':
                eS.ShowFogClouds();
                ac();
                break;
            case 'H':
                eS.HideFogClouds();
                ac();
                break;
            case 'W':
                HideWitches(ac);
                break;
            case 'S':
                ShowAnimatedObjects();
                ac();
                break;
            case 'E':
                EnvironmentChange(ac);
                break;
            case 'A':
                ANormalStart(ac);
                break;
            case 'Z':
                CommunicationSystem.Instance.Hide();
                InventorySystem.Instance.interactionEnabled = true;
                romeo.enabled = true;
                break;
            default:
                Debug.Log("Event is not programmed yet.");
                break;
        }

    }

    private void ANormalStart(Action ac) {
        CommunicationSystem.Instance.Hide();
        normalCurtain.DOLocalMoveY(0,2).OnComplete( () => {
            normalStart.SetActive(true);
            otherThings.SetActive(false);
            normalCurtain.DOLocalMoveY(11, 2).OnComplete(()=> { ac(); });
        } );
    }

    public void EnvironmentChange(Action ac) {
        s1a.Animate(ac);
    }

    public void ShowAnimatedObjects() {
        animatedBGObjects.SetActive(true);
        BG.sprite = bg1s;
    }

    public void HideWitches(Action ac)
    {
        witches[0].transform.DOMove(new Vector3(-6,-14,0), 1.0f).OnComplete( () => {
            witches[2].transform.DOMove(new Vector3(+6, -14, 0), 1.0f).OnComplete(()=> {
                witches[1].transform.DOMoveY(-14, 1.0f);
                ac();
            });
        } );
    }


    IEnumerator TransformCharacter(int index, Action ac) {
        eS.ShowConversionEffect(persons[index].transform.position);
        yield return new WaitForSeconds(0.1f);
        persons[index].gameObject.SetActive(false);
        witches[index].gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        ac();
    }



}
