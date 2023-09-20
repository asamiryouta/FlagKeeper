using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    //�W�����v�p�ϐ�
    private Rigidbody2D rigidbody2D;
    public float jumpForce = 200f; //�W�����v�̍���
    public int MaxJumpCount = 2;
    private int jumpcount = 0;

    //�L�����N�^�[�ړ��p�ϐ�
    Vector3 Playerpos;
    bool isleftFlag = false;
    public float playerspeed = 15; //�L�����N�^�[�̃X�s�[�h
    public static int Move = 10;�@//�L�����N�^�[�̃X�s�[�h�̃R���g���[���p
    public float speedx; //�������ւ̈ړ�
    SpriteRenderer sprite;

    //���p�ϐ�
    bool isFastMove = false;
    int cooldown = 600;
    int hitPoint;

    //�L�����N�^�[�R���g���[���[
    private void Start()
    {
        //RigidBody2D�R���|�[�l���g�̎擾
        rigidbody2D = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Playerpos = this.transform.position; //�v���C���[�̃|�W�V�������l������

        speedx = 0; //�������͂��Ȃ��ꍇ�͎~�܂�


        //�X�y�[�X����������W�����v������
        //MaxJumpCount�̐������W�����v�ł���
        if (Input.GetKey(KeyCode.Space)
            &&
            this.jumpcount < MaxJumpCount)
        {
            this.rigidbody2D.AddForce(transform.up
                *
                jumpForce);
            jumpcount++;

        }

        //�ʏ�ړ�����
        //�������Ɉړ�
        if (Input.GetKey("a"))
        {
            speedx = -playerspeed - Move;
            isleftFlag = false;
        }
        //�E�����Ɉړ�
        if (Input.GetKey("d"))
        {
            speedx = playerspeed + Move;
            isleftFlag = true;
        }


        if (cooldown > 600)
        {
            //��������ړ�����
            //A�L�[�ƉE�N���b�N����������s
            if (Input.GetKey("a") &&
                Input.GetKey(KeyCode.LeftShift) &&
                !isFastMove)
            {
                speedx = -playerspeed;
                isleftFlag = true;

                StartCoroutine("Fastmove");

                cooldown = 0;
            }
            //D�L�[�ƉE�N���b�N����������s
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
    //���ɒ��n������AjumpCount��0�ɂ���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpcount = 0;
        }
    }
}


