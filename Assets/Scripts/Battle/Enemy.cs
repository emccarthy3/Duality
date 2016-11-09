using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//defines Enemy based on personality type for choosing class type
public class Enemy : Character{

	private const int WARRIOR = 1;
	private const int MAGICIAN = 2;

	public Enemy(int personalityType){
		Level = 0;
		if (personalityType == WARRIOR) {
			Type = new Warrior(this);

		}
		else if (personalityType == MAGICIAN) {
			Type = new Magician(this);

		}
		else{
			Type = new Ranger(this);
		}
		Debug.Log ("Moves!" + Actions[0].Name);
		Name = "enemy1";
	}

}