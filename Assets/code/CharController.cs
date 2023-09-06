using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D; 

    public float jumpForce = 200f; //ジャンプの高さ

    public int MaxJumpCount = 2;
    private int jumpcount = 0;

    public float speed= 0.05f; //キャラクターのスピード
    public int slow = 5;　//キャラクターのスピードのコントロール用

    //キャラクターコントローラー
    private void Start()
    {
        //RigidBody2Dコンポーネントの取得
        rigidbody2D= GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 position = transform.position;

        //スペースを押したらジャンプさせる
        //MaxJumpCountの数だけジャンプできる
        if(Input.GetKey(KeyCode.Space) 
            &&
            this.jumpcount < MaxJumpCount)
        {
            this.rigidbody2D.AddForce(transform.up
                *
                jumpForce);
            jumpcount++;
        }
       
        if (Input.GetKey("s"))
        {
            position.y -= speed / slow;
        }
        if (Input.GetKey("a"))
        {
            position.x -= speed / slow;
        }
        if (Input.GetKey("d"))
        {
            position.x += speed / slow;
        }

        transform.position = position;
    }

    //床に着地したら、jumpCountを0にする
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            jumpcount = 0;
        }
    }
}


