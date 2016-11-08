using UnityEngine;
using System.Collections;


public abstract class Moves {
	private int baseDamage;



	public int BaseDamage {
		get{return baseDamage;}
		set{ baseDamage = value; }

	}

	public int CalculateDamage(Character attacker, Character defender){
		//get base damage of move 
		//add additional damage based on class of attacker and defender

		return baseDamage;
	}


	public abstract void MoveBehavior();


}
