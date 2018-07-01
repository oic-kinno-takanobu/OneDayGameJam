using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharBase {

    GameObject shotObj;
    [SerializeField]
    GameObject[] bitObjList;

    float maxShotInterval = 0.15f;
    float shotInterval = 0f;

    float bitMoveTime = 0;
    float bitMoveSpeed = 0.5f;
    float bitAngle;

    const int MAX_BIT_NUM = 3;
    const float BIT_RANGE = 2.0f;
    const float BIT_MAX_MOVE_TIME = 1.0f;
    const float BASE_ANGLE = 360;

	// Use this for initialization
	void Start () {
        shotObj = GetShotObj(0);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        BitMove();
        Shot();
	}

    /// <summary>
    /// 移動
    /// </summary>
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

    /// <summary>
    /// 弾発射（小型機の弾発射もここで管理する）
    /// </summary>
    private void Shot() {
        if (!Input.GetButton("Jump") || shotObj == null) {
            return;
        }

        shotInterval += Time.deltaTime;
        if(shotInterval < maxShotInterval) {
            return;
        }
        // 自機の弾発射
        Instantiate(shotObj, transform.position, transform.rotation);
        // 小型機の弾発射
        for (int i = 0; i < bitObjList.Length; i++) {
            //未実装
        }

        shotInterval = 0;
    }

    /// <summary>
    /// 小型機が自分の周りを回る処理
    /// </summary>
    private void BitMove() {

        bitAngle = BASE_ANGLE / bitObjList.Length;

        for (int i = 0; i < bitObjList.Length; i++) {
            if (bitObjList[i] == null) {
                continue;
            }
            float radianAngele = (bitAngle * i + BASE_ANGLE * bitMoveTime) * Mathf.Deg2Rad;
            float angleX = Mathf.Sin(radianAngele) * BIT_RANGE;
            float angleY = Mathf.Cos(radianAngele) * BIT_RANGE;

            bitObjList[i].transform.localPosition = transform.position + new Vector3(angleX, 0, angleY);
        }

        bitMoveTime += Time.deltaTime * bitMoveSpeed;
        if (bitMoveTime > BIT_MAX_MOVE_TIME) {
            bitMoveTime -= BIT_MAX_MOVE_TIME;
        }
    }
}
