using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D; 

    public float jumpForce = 200f; //�W�����v�̍���

    public int MaxJumpcount = 2;
    private int jumpcount = 0;

    public float speed= 0.05f; //�L�����N�^�[�̃X�s�[�h
    public int slow = 5;�@//�L�����N�^�[�̃X�s�[�h�̃R���g���[���p

    //�L�����N�^�[�R���g���[���[
    void Update()
    {
        Vector2 position = transform.position;

        if (Input.GetKey("w"))
        {
            position.y += speed / slow;
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
}


