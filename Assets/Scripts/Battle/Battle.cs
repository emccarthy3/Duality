using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//Class for  controlling the battle.  Written by: Betsey
public class Battle : MonoBehaviour{
	private Character playerChar;
	private Character partnerChar;
	private Enemy enemy1;
	private Enemy enemy2;
	private Action selectedAction;
	[SerializeField] private Text status;
	[SerializeField] private Text currentPlayer;
	[SerializeField] private UIController ui;
	private List<Character> battlers;
	private List<int> enemyRandomAttacks;
	private Character attacker;
	private Character defender;
	private int attackerIndex = 0;
	private const int FINAL_PLAYER = 2;
	private const int FINAL_ENEMY = 3;

	//initializes battle.  Having issues with turn based combat.  Want to use a List of battlers but getting null when casting players to Character
	void Start(){
		battlers = new List<Character> ();
		playerChar= new Player (1);
		partnerChar= new Ally(2);
		partnerChar.Name = "Betsey";
		partnerChar.RP = 8;
		enemy1= new Enemy(3);
		enemy2 = new Enemy (1);
		ui.SetButtonListeners (playerChar);
		battlers.Add (playerChar);
		battlers.Add (partnerChar);
		battlers.Add (enemy1);
		battlers.Add (enemy2);
		attacker = playerChar;
	}

	// Method to trigger enemy attacks after both player characters attack.  will implement AI
	public void EnemyAttacks(){
		Debug.Log (playerChar);
		SelectedAction = enemy1.Actions[0];
		StartCoroutine(Fight (playerChar));
	}

	// Performs fighting moves (will use animation) when chosen.  Puts a delay between action selected and the move performing for a more natural feel
	public IEnumerator Fight(Character defender){
		
		status.text = attacker +  "" + SelectedAction;
		DealDamage (defender);
		ui.UpdateHPLabels (defender.Name, battlers.IndexOf(defender), defender.HP);
		selectedAction.ActionBehavior ();
		yield return new WaitForSeconds (1);
		SwitchAttacker ();

	}

	//property for setting/getting the move selected for the current turn
	public Action SelectedAction{
		get{return selectedAction;}
		set{ selectedAction = value; }
	}

	//will calculate damage dealt
	public void DealDamage(Character defender){
		defender.HP -= selectedAction.CalculateDamage(attacker , defender);
	}

	//property for setting enemies for player attacks. Used in UIController to set enemy choice buttons
	public Enemy  Enemy1{
		get{ return enemy1; }
		set{ enemy1 = value; }
	}

	//property for setting enemies for player attacks. Used in UIController to set enemy choice buttons
	public Enemy Enemy2{
		get{ return enemy2; }
		set{ enemy2 = value; }
	}
	//allows for turn based attack system. Want this to go through a loop of battlers
	public void SwitchAttacker(){
		attackerIndex++;
		attacker = battlers [attackerIndex];
		currentPlayer.text = attacker.Name + "'s turn";
		if (attackerIndex >= FINAL_PLAYER && attackerIndex < FINAL_ENEMY) {			
			Debug.Log ("ENEMY IS ATTACKING NOW ");
			ui.ChangeButtonVisibility (false);
			EnemyAttacks ();
	
		} else {
			ui.ChangeButtonVisibility (true);
			ui.SetButtonListeners (battlers [attackerIndex]);
			attacker = battlers [attackerIndex];

			ui.SetButtonListeners (battlers [attackerIndex]);
		}
	}
	

}

