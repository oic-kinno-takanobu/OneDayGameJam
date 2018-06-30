using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharBase {

    GameObject shotObj;

    GameObject[] bitObjList;

    const int MAX_BIT_NUM = 3;

	// Use this for initialization
	void Start () {
        //shotObj = GetShotObj(0);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Shot();
	}

    private void Move() {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        if (inputX == 0 && inputY == 0) {
            return;
        }
        float timeMoveSpeed = moveSpeed * Time.deltaTime;

        float moveX = inputX * timeMoveSpeed;
        float moveY = inputY * timeMoveSpeed;

        transform.localPosition += new Vector3(moveX, 0, moveY);
    }

    private void Shot() {
        if (!Input.GetButton("Jump") || shotObj == null) {
            return;
        }

        
    }
}
