using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//defines Enemy based on personality type for choosing class type
public class Enemy : Character{
	//use a hashmap instead here
	public Enemy(int personalityType){
		Level = 0;
		HP = 10;
		GetClassTypeFromHashtable (personalityType);
		Debug.Log ("class type " + Type);
		Name = "ally";
	}
}