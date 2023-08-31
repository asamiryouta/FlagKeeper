using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCont : MonoBehaviour
{
    private GameObject Flag;    //Flag�̏����i�[
    private Vector3 FlagPosition;   //Flag�ʒu���擾�p�̕ϐ�
    private Vector3 EnemyPosition;  //�G�̈ʒu���擾�p�̕ϐ�
    
    void Start()
    {
        Flag = GameObject.Find("Flag");�@//Flag�̏����擾
        FlagPosition = Flag.transform.position; //�ϐ���Flag�̈ʒu�����擾
        EnemyPosition = transform.position; 
    }
    void Update()
    {

        FlagPosition = Flag.transform.position; //Flag�̍��W
        EnemyPosition = transform.position; //Enemy�̍��W

        if(FlagPosition.x > EnemyPosition.x)
        {
            EnemyPosition.x = EnemyPosition.x + 0.01f;
        }
        else if (FlagPosition.x < EnemyPosition.x)
        {
            EnemyPosition.x = EnemyPosition.x + 0.01f;
        }
        else if (FlagPosition.y > EnemyPosition.y)
        {
            EnemyPosition.y = EnemyPosition.y + 0.01f;
        }
        else if (FlagPosition.y < EnemyPosition.y)
        {
            EnemyPosition.y = EnemyPosition.y + 0.01f;
        }

        transform.position = EnemyPosition;

    }
}
