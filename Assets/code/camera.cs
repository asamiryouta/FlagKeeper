using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    GameObject playerObj;   //Playerの情報を取得
    CharController Player;  //CharControllerのクラス
    Transform playerTransform; 
    void Start()
    {
        playerObj = GameObject.Find("Player");
        Player = playerObj.GetComponent<CharController>();
        playerTransform = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x,    //Playerのx座標を取得
                                         playerTransform.position.y,    //Playerのy座標を取得
                                         transform.position.z);
    }
}
