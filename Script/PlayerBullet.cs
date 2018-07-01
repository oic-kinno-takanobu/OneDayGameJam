using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletBase {

	// Use this for initialization
	void Start () {
        base.Init();
	}
	
	// Update is called once per frame
	void Update () {
        ShotMove();
    }

    private void ShotMove() {
        transform.position += transform.forward * Time.deltaTime * burretSpeed;
    }

}
