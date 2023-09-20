using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    //ジャンプ用変数
    private Rigidbody2D rigidbody2D;
    public float jumpForce = 200f; //ジャンプの高さ
    public int MaxJumpCount = 2;
    private int jumpcount = 0;

    //キャラクター移動用変数
    Vector3 Playerpos;
    bool isleftFlag = false;
    public float playerspeed = 15; //キャラクターのスピード
    public static int Move = 10;　//キャラクターのスピードのコントロール用
    public float speedx; //横方向への移動
    SpriteRenderer sprite;

    //回避用変数
    bool isFastMove = false;
    int cooldown = 600;
    int hitPoint;

    //キャラクターコントローラー
    private void Start()
    {
        //RigidBody2Dコンポーネントの取得
        rigidbody2D = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Playerpos = this.transform.position; //プレイヤーのポジションを獲得する

        speedx = 0; //何も入力しない場合は止まる


        //スペースを押したらジャンプさせる
        //MaxJumpCountの数だけジャンプできる
        if (Input.GetKey(KeyCode.Space)
            &&
            this.jumpcount < MaxJumpCount)
        {
            this.rigidbody2D.AddForce(transform.up
                *
                jumpForce);
            jumpcount++;

        }

        //通常移動処理
        //左方向に移動
        if (Input.GetKey("a"))
        {
            speedx = -playerspeed - Move;
            isleftFlag = false;
        }
        //右方向に移動
        if (Input.GetKey("d"))
        {
            speedx = playerspeed + Move;
            isleftFlag = true;
        }


        if (cooldown > 600)
        {
            //回避高速移動処理
            //Aキーと右クリックをしたら実行
            if (Input.GetKey("a") &&
                Input.GetKey(KeyCode.LeftShift) &&
                !isFastMove)
            {
                speedx = -playerspeed;
                isleftFlag = true;

                StartCoroutine("Fastmove");

                cooldown = 0;
            }
            //Dキーと右クリックをしたら実行
            if (Input.GetKey("d") &&
                Input.GetKey(KeyCode.LeftShift) &&
                !isFastMove)
            {
                speedx = playerspeed;
                isleftFlag = false;

                StartCoroutine("Fastmove");

                cooldown = 0;
            }
        }
        cooldown++;
    }

    IEnumerator Fastmove()
    {
        isFastMove = true;
        Debug.Log("fastmove");
        yield return new WaitForSeconds(0.1f);
        isFastMove = false;

    }

    public void FixedUpdate()
    {
        if (!isFastMove)
        {
            this.transform.Translate(speedx / 70, 0, 0);
        }
        if (isFastMove)
        {
            this.transform.Translate(speedx / 25, 0, 0);
        }

    }
    //床に着地したら、jumpCountを0にする
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpcount = 0;
        }
    }
}


