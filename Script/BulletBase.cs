using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour {

    [SerializeField]
    protected float burretSpeed;
    [SerializeField]
    protected float destoryBulletTime;

    /// <summary>
    /// 初期設定
    /// </summary>
    protected void Init() {
        if (destoryBulletTime >= 0) {
            Destroy(gameObject, destoryBulletTime);
        }
    }

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// あたり判定（必要に応じてoverrideする）
    /// </summary>
    /// <param name="collider"></param>
    protected virtual void OnTriggerEnter (Collider collider){
        
    }
}
