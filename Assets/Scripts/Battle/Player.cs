using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Character{
	private const int WARRIOR = 1;
	private const int MAGICIAN = 2;

	public Player(int personalityType){
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

	}


}