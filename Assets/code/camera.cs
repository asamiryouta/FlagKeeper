using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    GameObject playerObj;   //Player�̏����擾
    CharController Player;  //CharController�̃N���X
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
        transform.position = new Vector3(playerTransform.position.x,    //Player��x���W���擾
                                         playerTransform.position.y,    //Player��y���W���擾
                                         transform.position.z);
    }
}
