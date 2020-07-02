using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuButton : MonoBehaviour
{
    public UnityEvent uevent;

    private TextMeshPro textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    private void OnMouseDown()
    {
        uevent.Invoke();
    }

    private void OnMouseOver()
    {
        textMesh.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        textMesh.color = Color.white;
    }

}
