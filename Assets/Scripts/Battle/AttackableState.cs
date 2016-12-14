using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableState : State {

	public AttackableState(UIController ui, Battle battle ,Character battler): base(ui, battle, battler){
	if (battler.GetType ().Name == "Enemy") {
		ui.ChangeEnemyButtonVisibility (battler.Name, true);
		battle.AttackableEnemies.Add (battler);
	} else {
		battle.AttackablePlayers.Add (battler);
	}
	}
}
