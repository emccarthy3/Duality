using UnityEngine;
using System.Collections;


public class SingleAttack : Action{

	public SingleAttack(string name, int baseDamage,ParticleSystem particleSystem) : base(name,  baseDamage,  particleSystem){
	}

	public override void ActionBehavior ()
	{
		//no additional behavior for singleAttack
	}


}
