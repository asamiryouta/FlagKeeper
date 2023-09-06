using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D; 

    public float jumpForce = 200f; //�W�����v�̍���

    public int MaxJumpCount = 2;
    private int jumpcount = 0;

    public float speed= 0.05f; //�L�����N�^�[�̃X�s�[�h
    public int slow = 5;�@//�L�����N�^�[�̃X�s�[�h�̃R���g���[���p

    //�L�����N�^�[�R���g���[���[
    private void Start()
    {
        //RigidBody2D�R���|�[�l���g�̎擾
        rigidbody2D= GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 position = transform.position;

        //�X�y�[�X����������W�����v������
        //MaxJumpCount�̐������W�����v�ł���
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

    //���ɒ��n������AjumpCount��0�ɂ���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            jumpcount = 0;
        }
    }
}


