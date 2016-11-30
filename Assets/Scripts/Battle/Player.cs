using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//defines your player character.
public class Player : Character{

	//Constructor for creating player by passing a personality type
	public Player(ClassType type){
		Level = 0;
		HP = 10;
		RP = 5;
		Type = type;
		Name = "player";
	}
}