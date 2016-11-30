using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//defines Enemy based on personality type for choosing class type
public class Enemy : Character{
	
	public Enemy(ClassType  type){
		Level = 0;
		HP = 10;
		Name = "Enemy ";
		Type = type;
	}
}