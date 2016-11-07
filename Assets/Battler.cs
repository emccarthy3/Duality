using UnityEngine;
using System.Collections;

public interface Battler {


	//determines action taken during battler's turn
	void Attack ();

	void Heal();
	void Block ();

}
