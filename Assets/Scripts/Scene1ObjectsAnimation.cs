using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Scene1ObjectsAnimation : MonoBehaviour
{

    public Transform simpleClouds;
    public Transform darkClouds;

    public Transform sun;
    public Transform elec;

    public Transform mc;
    public Transform skColor;




    void Start()
    {
        //Invoke("Animate", 2.0f);
    }

    public  void Animate(Action ac){
        simpleClouds.DOLocalMoveY(10, 2);
        darkClouds.DOLocalMoveY(-8.54f, 2);
        sun.DOLocalMoveX(-17, 2).OnComplete(()=> { ac(); sun.gameObject.SetActive(false); });
        elec.DOLocalMoveX(-11, 2);
        mc.DOMove(new Vector3(-0.8f,-2.5f,0),2);
        skColor.DOLocalMoveY(1.0f,2);
    }
}
