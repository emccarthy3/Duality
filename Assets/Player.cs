using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Character{
	private List<Moves> moves;
	public Player(){
		moves = new List<Moves> ();
	}
	public override void Attack (){
		Debug.Log ("player is attacking");
	}

	public void Heal(){
	}
	public void Block (){
	}
	public void Level(){
	}
}