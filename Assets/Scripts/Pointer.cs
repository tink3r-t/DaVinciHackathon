using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum CursorState {
    Idle = 0,
    Grab = 1,
    Goto = 2,
    LookAt = 3,
    Talk = 4
};


[RequireComponent(typeof(SpriteRenderer))]
public class Pointer : MonoBehaviour
{

    private Camera cam;
    private Animator animator;
    public CursorState curState;

    public static Pointer Instance;

    private void Start()
    {
        cam = Camera.main;
        animator = GetComponent<Animator>();
        Cursor.visible = false;
        Instance = this;
    }

    private void Update()
    {
        Vector2 cursorPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;

        animator.SetInteger("State", (int)curState);

    }

    public void ChangeState(CursorState cursorState) {
        curState = cursorState;
    }

}
