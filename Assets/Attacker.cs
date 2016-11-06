using UnityEngine;
using System.Collections;

public class Attacker : Battler{

	private bool isEnemy;

	public Attacker(bool isEnemy){
		this.isEnemy = isEnemy;
	}

	//creates an attack.  For now, only doing single attacks but will also implement double attacks
	public override void Move(){
	}

	private void SingleAttack(){



	}
	public override void Level(){
		
	}

	public bool IsEnemy{
		get{ return isEnemy; }
		set{ isEnemy = value; }
	}



}
