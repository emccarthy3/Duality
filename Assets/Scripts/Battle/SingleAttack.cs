using UnityEngine;
using System.Collections;


public class SingleAttack : Action{
	private int baseDamage;
	private string name;

	public SingleAttack(string name, int baseDamage) {
		Name = name;
		BaseDamage = baseDamage;
	}


	public override void ActionBehavior ()
	{
		//no additional behavior for singleAttack
	}


}
