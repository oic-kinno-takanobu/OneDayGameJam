using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBase : MonoBehaviour {

    [SerializeField]
    protected GameObject[] shotObjList;

    [SerializeField]
	protected float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 弾を取得する処理
    /// </summary>
    /// <param name="indx"></param>
    /// <returns></returns>
    protected GameObject GetShotObj(int indx) {
        return shotObjList[indx];
    }
}
