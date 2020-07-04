using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int flag = 10;
    string Desc = "One Rose";
    string DescDE = "Eine Rose";

    private Vector3 pos;
    private Transform parent;

    private void OnMouseEnter()
    {
        if (Preferences.LanguageInt == (int)LANGUAGE.EN)
            CommunicationSystem.Instance.Notify(Desc);
        else
            CommunicationSystem.Instance.Notify(DescDE);
        Pointer.Instance.ChangeState(CursorState.Grab);
    }

    private void OnMouseDown()
    {
        pos = transform.position;
        parent = transform.parent;
        this.transform.SetParent(GameObject.Find("Cursor").transform);
    }

    private void OnMouseUp()
    {
        if (transform.position.x < 2 && transform.position.x > -2 && transform.position.y < -1)
        {
            GameObject.Find("Romeo").GetComponent<Character>().dosts();
            Destroy(this.gameObject, 0.10f);
        }
        else
        {
            transform.SetParent(parent);
            transform.position = pos;

        }


    }

    private void OnMouseExit()
    {
        Pointer.Instance.ChangeState(CursorState.Idle);
    }


}
