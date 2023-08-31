using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCont : MonoBehaviour
{
    private GameObject Flag;    //Flagの情報を格納
    private Vector3 FlagPosition;   //Flag位置情報取得用の変数
    private Vector3 EnemyPosition;  //敵の位置情報取得用の変数
    
    void Start()
    {
        Flag = GameObject.Find("Flag");　//Flagの情報を取得
        FlagPosition = Flag.transform.position; //変数にFlagの位置情報を取得
        EnemyPosition = transform.position; 
    }
    void Update()
    {

        FlagPosition = Flag.transform.position; //Flagの座標
        EnemyPosition = transform.position; //Enemyの座標

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
