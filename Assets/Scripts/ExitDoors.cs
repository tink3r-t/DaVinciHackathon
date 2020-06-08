using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class ExitDoors : MonoBehaviour
{

    public SpriteRenderer rend;

    public int sceneToLoad = 0;

    private void OnMouseDown()
    {
        rend.sortingLayerName = "Pointer";
        rend.sortingOrder = 15;
        rend.DOColor(Color.black, 2.0f).OnComplete( ()=> { SceneManager.LoadScene(sceneToLoad); } );
    }

    private void OnMouseEnter()
    {
        Pointer.Instance.ChangeState(CursorState.Goto);
    }

    private void OnMouseExit()
    {
        Pointer.Instance.ChangeState(CursorState.Idle);
    }

}
