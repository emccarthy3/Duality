using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingState : State {

	public BlockingState(UIController ui, Battle battle ,Character battler): base(ui, battle, battler){
		if (battler.GetType ().Name == "Enemy") {
			ui.ChangeEnemyButtonVisibility (battler.Name, false);
			battle.AttackableEnemies.Remove (battler);
		} else {
			battle.AttackablePlayers.Remove (battler);
		}
	}
}
