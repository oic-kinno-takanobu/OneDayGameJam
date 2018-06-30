using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChar : CharBase {

	[SerializeField]
	protected int hp;
	// Use this for initialization
	void Start () {
		hp = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			//消滅時のエフェクトを自身の位置にclone
			//スコアカウント用の関数呼び出し
			Destroy (gameObject);
		}
	}
		
	public void SetDamage (int damage) {
		hp -= damage;
	}
}
