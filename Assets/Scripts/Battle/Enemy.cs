using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//defines Enemy based on personality type for choosing class type
public class Enemy : Character{
	private List<Action> enemyActions;	
	public Enemy(ClassType type, Sprite sprite){
		Level = 0;
		HP = 10;
		Name = "Enemy ";
		Type = type;
		PlayerSprite = sprite;
	}
	//property for which moves the enemy has
	public List<Action> EnemyActions {
		get{return enemyActions;}
		set{ enemyActions = value; }
	}
}