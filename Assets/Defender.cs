using UnityEngine;
using System.Collections;

public class Defender : Battler{
	//creates an attack.  For now, only doing single attacks but will also implement double attacks
	public override void Move(){
	}

	private void SingleAttack(){

	}
	public void TakeDamage(){
		HP -= 5;
	}
	public override void Level(){

	}
}
