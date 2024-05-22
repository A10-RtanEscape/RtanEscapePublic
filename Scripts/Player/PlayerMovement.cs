using System;
using UnityEngine;

[RequireComponent (typeof(PlayerInputController)), RequireComponent(typeof(Rigidbody2D))] 
public class PlayerMovement : MonoBehaviour
{
    private PlayerInputController controller;
    private Rigidbody2D rigid;

    [Header("플레이어 이동")]
    [SerializeField] private float moveSpeed = 5f;
    private float axisHorizontal;
    

    [Header("플레이어 회전")]
    [SerializeField] private SpriteRenderer[] sprites;

    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
        rigid = GetComponent<Rigidbody2D>();

        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid.gravityScale = 0;
        controller.OnMoveEnvet += Move;
        controller.OnMove2Envet += Move;
    }

    private void Move(float inputValue)
    {
        axisHorizontal = inputValue;
    }

    private void FixedUpdate()
    {
        ApplyMovement(axisHorizontal);
    }

    private void ApplyMovement(float axisHorizontal)
    {
        Filp();

        axisHorizontal *= moveSpeed;

        rigid.velocity = new Vector2 (axisHorizontal, 0);
    }

    private void Filp()
    {
        if (axisHorizontal < 0)
        {
            foreach ( var item in sprites)
            {
                item.flipX = true;
            }
            
        }
        else if ( axisHorizontal > 0)
        {
            //sprite.flipX= false;

            foreach (var item in sprites)
            {
                item.flipX = false;
            }
        }
    }
}
