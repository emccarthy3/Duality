﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//defines your player character.
public class Player : Character{

//Constructor for creating player by passing a personality type
	public Player(int personalityType){
		Debug.Log (personalityType + "Personality type");
		Level = 0;
		HP = 10;
		GetClassTypeFromHashtable (personalityType);
		Debug.Log ("Move 1 " + Actions[0].Name);
		Debug.Log ("PLayer contrstcurotr class typesss ! ! :D " + Type);
		Name = "player";
	}
}