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
		gameController = gc.GetComponent <GameController> ();
		GameObject background = GameObject.Find ("Background");
		background.GetComponent<SpriteRenderer> ().sprite = gameController.Backgrounds[gameController.BattleLoop];
		battlers = new List<Character> ();
		yourTeam = new List<Character> ();
		playerChar = gameController.YourPlayer;
		Debug.Log(playerChar.HP + "Player hp");
		partnerChar = gameController.YourPartner;
		status.text = "RP: " + playerChar.RP;
		enemy1= new Enemy(new Ranger());
		enemy2 = new Enemy (new Warrior());
		enemy1.Name = "Enemy 1";
		enemy2.Name = "Enemy 2";
		ui.SetButtonListeners (playerChar);
		battlers.Add (playerChar);
		battlers.Add (partnerChar);
		battlers.Add (enemy1);
		battlers.Add (enemy2);
		yourTeam.Add (playerChar);
		yourTeam.Add (partnerChar);
		attacker = playerChar;
	}

	//checks to see if both enemies were defeated and will load the next scene if true
	public override void Update(){
		if (!battlers.Contains (enemy1) && !battlers.Contains (enemy2)) {
			ui.OnBattleEndDialogue ();
		}
		if(!battlers.Contains(playerChar)){
			SceneManager.LoadScene ("newBattle");
		}
	}

	// Method to trigger enemy attacks after both player characters attack.  will implement AI
	public void EnemyAttacks(){
		SelectedAction = enemy1.Type.Actions[0];
		Fight (yourTeam[Random.Range(0,2)]);
	}

	//calculates team attack damage and tells ui to update labels
	public void DoTeamAttack(int damage){
		defender.HP -= damage;
		ui.UpdateHPLabels (defender.Name, battlers.IndexOf(defender), defender.HP);
		StartCoroutine(CheckIfDefeated ());
	}

	// Performs fighting moves (will use animation) when chosen.  Puts a delay between action selected and the move performing for a more natural feel
	public void Fight(Character defender){
		this.defender = defender;
		DealDamage (defender);
		ui.UpdateHPLabels (defender.Name, battlers.IndexOf(defender), defender.HP);
		selectedAction.ActionBehavior ();
		StartCoroutine(CheckIfDefeated ());
	}
	//this method will check whether or not the defender was defeated in battle. If the defender was defeated, the UI will update accordingly and the battler will be taken out of the battler list
	public IEnumerator CheckIfDefeated(){
		if (defender.HP <= 0) {
			ui.RemoveFromHPList (battlers.IndexOf (defender));
			battlers.Remove (defender);
			if (defender.GetType ().Name == "Enemy") {
				ui.RemoveDefeatedEnemyButton (defender.Name);
			}
		}
		yield return new WaitForSeconds (1);
			SwitchAttacker ();
		}

	//property for setting/getting the move selected for the current turn
	public Action SelectedAction{
		get{return selectedAction;}
		set{ selectedAction = value; }
	}

	//will calculate damage dealt. More damage is dealt depending on the battle loop
	public void DealDamage(Character defender){
		defender.HP -= selectedAction.CalculateDamage(attacker , defender) + gameController.BattleLoop;
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
	public Character Defender{
		get{ return defender; }
		set{ defender = value; }
	}
	public List<Character> Battlers{
		get{ return battlers; }
		set{ battlers = value; }
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

}
