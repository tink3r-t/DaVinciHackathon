using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EffectsSystem : MonoBehaviour
{
    [SerializeField]
    private Animator poofer;

    public List<GameObject> clouds;
    private List<Vector3> cloud_positions = new List<Vector3>();

    private void Start()
    {
        for (int i = 0; i < clouds.Count; i++)
        {
            cloud_positions.Add(clouds[i].transform.position);
        }
    }

    public void ShowConversionEffect(Vector3 position) {
        poofer.transform.position = position;
        poofer.SetTrigger("show");
    }


    public void ShowFogClouds() {
        for (int i = 0; i < clouds.Count; i++)
        {
            clouds[i].transform.DOMove(Vector3.zero, 2.0f).SetEase(Ease.OutSine);
        }
    }


    public void HideFogClouds()
    {
        for(int i = 0; i < clouds.Count; i++)
        {
            clouds[i].transform.DOMove(cloud_positions[i], 2.0f).SetEase(Ease.Linear);
        }
    }


}
