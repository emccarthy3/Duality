using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealState : State {

	public HealState(UIController ui, Battle battle ,Character battler): base(ui, battle, battler){
		
	}

	public abstract void Heal (int maxHP, int healAmount);
}
