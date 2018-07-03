using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletCommon;

public class Bit : CharBase {

    private bool isApproaches = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BitShot(int bitBulletType) {
        shotInterval += Time.deltaTime;
        if(shotInterval < maxShotInterval) {
            return;
        }

        switch (bitBulletType) {
            case BulletType.BULLET_TYPE_NOMAL:
                Instantiate(shotObjList[0], transform.position, transform.rotation);
                break;
            case BulletType.BULLET_TYPE_HOMING:
                Instantiate(shotObjList[0], transform.position, transform.rotation);
                break;
            case BulletType.BULLET_TYPE_LASER:
                Instantiate(shotObjList[0], transform.position, transform.rotation);
                break;
        }

        shotInterval = 0;
    }

    /// <summary>
    /// isApproachesを更新する処理
    /// </summary>
    /// <param name="_isApproaches"></param>
    public void setIsApproaches(bool _isApproaches) {
        isApproaches = _isApproaches;
    }

    /// <summary>
    /// isApproachesを取得する処理
    /// </summary>
    /// <returns></returns>
    public bool getIsApproaches() {
        return isApproaches;
    }
}
