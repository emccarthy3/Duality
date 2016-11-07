using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Character{


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public override void Attack (){
		Debug.Log ("enemy is attacking");
	}

	public void Heal(){
	}
	public void Block (){
	}

}