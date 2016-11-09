using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ally : Character{
	private const int WARRIOR = 1;
	private const int MAGICIAN = 2;

//creates the partner character and passes personality type
	public Ally(int personalityType){
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
		Name = "ally";

	}

}
