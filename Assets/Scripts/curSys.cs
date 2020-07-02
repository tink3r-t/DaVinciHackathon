using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curSys : MonoBehaviour
{
    public GameObject cL, cR;
    // Start is called before the first frame update
    void Start()
    {
        cR.transform.DOMoveX(14.0f, 2.0f);
        cL.transform.DOMoveX(-14.0f, 2.0f);
    }

}
