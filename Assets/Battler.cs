using UnityEngine;
using System.Collections;

public abstract class Battler : Character {
	private bool isAttackable;

	//determines action taken during battler's turn
	public abstract void Move ();

	public void Heal(){
		if (HP < 10) {
			//increment HP by two
		}
	}
	public void Block(){
		if (HP < 10) {
			//increment HP by two
		}
	}

}
