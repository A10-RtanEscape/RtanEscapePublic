using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerInputController controller;

    // "isRun" 문자열은 연산 비용이 크기 때문에 고유한 해쉬값으로 변경하여 연산비용을 줄일 수 있다. ( 애니메이션 성능 향상 ) 
    private static readonly int isRun = Animator.StringToHash("isRun");
    private static readonly int isHit = Animator.StringToHash("isHit");

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<PlayerInputController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller.OnMoveEnvet += MoveAnimation;
        controller.OnMove2Envet += MoveAnimation;
    }

    private void MoveAnimation(float inputValue)
    {
        animator.SetBool(isRun, Mathf.Abs(inputValue) > 0);

    }

    private void HitAnimation()
    {
        animator.SetTrigger(isHit);

    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.H))
        {
            HitAnimation();
        }
    }
}
