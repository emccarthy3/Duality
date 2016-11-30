using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//Class for  controlling the battle.  Written by: Betsey
using UnityEngine.SceneManagement;


public class Battle : State{
	private Character playerChar;
	private Character partnerChar;
	private Enemy enemy1;
	private Enemy enemy2;
	private Action selectedAction;
	[SerializeField] private Text status;
	[SerializeField] private Text currentPlayer;
	[SerializeField] private UIController ui;
	private List<Character> battlers;
	private List<Character> yourTeam;
	private List<int> enemyRandomAttacks;
	private Character attacker;
	private Character defender;
	private int attackerIndex = 0;
	private GameObject gc;
	private GameController gameController;
	private const int FINAL_PLAYER = 2;
	private const int FINAL_ENEMY = 4;


	//initializes battle. 
	public override void Start(){
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		battlers = new List<Character> ();
		yourTeam = new List<Character> ();
		playerChar = gameController.YourPlayer;
		Debug.Log(playerChar.HP + "Player hp");
		partnerChar = gameController.YourPartner;
		status.text = "RP: " + playerChar.RP;
		enemy1= new Enemy(new Ranger());
		enemy2 = new Enemy (new Warrior());
		ui.SetButtonListeners (playerChar);
		battlers.Add (playerChar);
		battlers.Add (partnerChar);
		battlers.Add (enemy1);
		battlers.Add (enemy2);
		yourTeam.Add (playerChar);
		yourTeam.Add (partnerChar);
		attacker = playerChar;
	}

	public override void Update(){
		if (!battlers.Contains (enemy1) && !battlers.Contains (enemy2)) {
			SceneManager.LoadScene ("Dialogue1");
		}
	}
	// Method to trigger enemy attacks after both player characters attack.  will implement AI
	public void EnemyAttacks(){
		SelectedAction = enemy1.Type.Actions[0];
		StartCoroutine(Fight (yourTeam[Random.Range(0,2)]));
	}

	// Performs fighting moves (will use animation) when chosen.  Puts a delay between action selected and the move performing for a more natural feel
	public IEnumerator Fight(Character defender){
		DealDamage (defender);
		ui.UpdateHPLabels (defender.Name, battlers.IndexOf(defender), defender.HP);
		selectedAction.ActionBehavior ();
		yield return new WaitForSeconds (1);
		if (defender.HP <= 0) {
			ui.RemoveFromHPList (battlers.IndexOf (defender));
			battlers.Remove (defender);
			Debug.Log (defender.Name + " Was defeated !!!");
		}
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
		if (attackerIndex > battlers.Count-1) {
			attackerIndex = 0;
			ui.ChangeButtonVisibility (true);
		}
		attacker = battlers [attackerIndex];
		if (attacker.GetType ().Name == "Enemy") {			
			ui.ChangeButtonVisibility (false);
			EnemyAttacks ();
		}
		ui.SetButtonListeners (battlers [attackerIndex]);
		attacker = battlers [attackerIndex];
		currentPlayer.text = attacker.Name + "'s turn";

	}

	public int GetIndex(Character battler){
		return battlers.IndexOf (battler);
	}


}
