using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ally : Character{

//creates the partner character and passes personality type
	public Ally(int personalityType){
		Level = 0;
		HP = 10;
		GetClassTypeFromHashtable (personalityType);
		Debug.Log (" Ally class type " + Type);
		Name = "ally";

	}

}
