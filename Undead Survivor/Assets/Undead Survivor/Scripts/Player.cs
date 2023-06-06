using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }

        anim.SetFloat("Speed", inputVec.magnitude);
    }

    void FixedUpdate()
    {
        //rigid.AddForce(inputVec);
        //rigid.velocity = inputVec;
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }
}