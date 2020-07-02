using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class SelectionSystem : MonoBehaviour
{
    public List<TextMeshPro> opts;

    public event Action<int> callback;

    void Start()
    {
        opts[0].GetRenderedValues(true);
        opts[1].GetRenderedValues(true);
        opts[2].GetRenderedValues(true);
    }

    public void showOptions(string opt1, string opt2, string opt3, Action<int> c) {
        opts[0].autoSizeTextContainer = true;
        opts[1].autoSizeTextContainer = true;
        opts[2].autoSizeTextContainer = true;

        opts[0].fontSizeMin = 1;
        opts[1].fontSizeMin = 1;
        opts[2].fontSizeMin = 1;

        opts[0].fontSizeMax = 8;
        opts[1].fontSizeMax = 8;
        opts[2].fontSizeMax = 8;

        opts[0].GetComponent<BoxCollider2D>().enabled = true;
        opts[1].GetComponent<BoxCollider2D>().enabled = true;
        opts[2].GetComponent<BoxCollider2D>().enabled = true;
        opts[0].text = opt1;
        opts[1].text = opt2;
        opts[2].text = opt3;

        opts[0].ForceMeshUpdate();
        opts[1].ForceMeshUpdate();
        opts[2].ForceMeshUpdate();

        float s0 = opts[0].fontSize;
        float s1 = opts[1].fontSize;
        float s2 = opts[2].fontSize;

        opts[0].autoSizeTextContainer = false;
        opts[1].autoSizeTextContainer = false;
        opts[2].autoSizeTextContainer = false;

        float min = Mathf.Min(s0,s1,s2);
        opts[0].fontSizeMin = min;
        opts[1].fontSizeMin = min;
        opts[2].fontSizeMin = min;

        opts[0].fontSizeMax = min;
        opts[1].fontSizeMax = min;
        opts[2].fontSizeMax = min;

        opts[0].ForceMeshUpdate();
        opts[1].ForceMeshUpdate();
        opts[2].ForceMeshUpdate();

        callback = c;
    }
    
    public void selected(int no)
    {
        opts[0].GetComponent<BoxCollider2D>().enabled = false;
        opts[1].GetComponent<BoxCollider2D>().enabled = false;
        opts[2].GetComponent<BoxCollider2D>().enabled = false;
        callback(no);
    }

}
