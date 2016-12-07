using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ally : Character{

	//creates the partner character and passes personality type
	public Ally(ClassType type){
		Level = 0;
		HP = 10;
		RP = 5;
		Type = type;
		Debug.Log (" Ally class type " + Type);
		Name = "ally";

	}

}
