using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnHoverChangeColor : MonoBehaviour
{
    public SelectionSystem ss;

    public int no = 1;
    private TextMeshPro textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    private void OnMouseDown()
    {
        ss.selected(no);
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
