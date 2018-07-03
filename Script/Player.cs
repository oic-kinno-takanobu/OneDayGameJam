using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletCommon;

public class Player : CharBase {

    GameObject shotObj;

    [SerializeField]
    private GameObject bitObj;

    int bitBulletTyep = BulletType.BULLET_TYPE_NOMAL;

    float bitMoveTime = 0;
    float bitMoveSpeed = 0.5f;
    float bitAngle;

    const int MAX_BIT_NUM = 6;
    const float BIT_RANGE = 2.0f;
    const float BIT_MAX_MOVE_TIME = 1.0f;
    const float BASE_ANGLE = 360;

    GameObject[] bitObjList = new GameObject[MAX_BIT_NUM];

    // Use this for initialization
    void Start () {
        shotObj = GetShotObj(0);

        for (int i = 0; i < MAX_BIT_NUM; i++) {
            BitAdd();
        }
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

        // 小型機の弾発射
        for (int i = 0; i < bitObjList.Length; i++) {
            if(bitObjList[i] != null) {
                bitObjList[i].GetComponent<Bit>().BitShot(bitBulletTyep);
            } 
        }

        shotInterval += Time.deltaTime;
        if(shotInterval < maxShotInterval) {
            return;
        }
        // 自機の弾発射
        Instantiate(shotObj, transform.position, transform.rotation);
       
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
            float totalAngle = bitAngle * i + BASE_ANGLE * bitMoveTime;
            Vector3 vector = getVectorByAlgle(totalAngle, BIT_RANGE);
            Bit bitScript = bitObjList[i].GetComponent<Bit>();

            if (bitScript.getIsApproaches()) {
                //自機に近づく処理
                Vector3 distans = (transform.position + vector) - bitObjList[i].transform.localPosition;
                bitObjList[i].transform.localPosition += distans / 20.0f;
                if(Mathf.Sqrt(distans.x * distans.x + distans.z * distans.z) <= BIT_RANGE) {
                    bitScript.setIsApproaches(false);
                }

            } else {
                bitObjList[i].transform.localPosition = transform.position + vector;
            }
           
        }

        bitMoveTime += Time.deltaTime * bitMoveSpeed;
        if (bitMoveTime > BIT_MAX_MOVE_TIME) {
            bitMoveTime -= BIT_MAX_MOVE_TIME;
        }
    }

    /// <summary>
    /// 小型機を追加する処理
    /// </summary>
    private void BitAdd() {
        float randomAngle = Random.Range(0, 360);
        Vector3 vector = getVectorByAlgle(randomAngle, BIT_RANGE * 10);

        for (int i = 0; i < MAX_BIT_NUM; i++) {
            if(bitObjList[i] == null) {
                bitObjList[i] = Instantiate(bitObj, vector, new Quaternion(0, 0, 0, 0)) as GameObject;
                break;
            }
        }

    }

    /// <summary>
    /// 角度から2次元座標取得処理
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="lenge"></param>
    /// <returns></returns>
    private Vector3 getVectorByAlgle (float angle, float lenge) {
        float radianAngele = (angle) * Mathf.Deg2Rad;
        float angleX = Mathf.Sin(radianAngele) * lenge;
        float angleY = Mathf.Cos(radianAngele) * lenge;

        return new Vector3(angleX, 0, angleY);
    }
}
