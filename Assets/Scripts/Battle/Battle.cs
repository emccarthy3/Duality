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
	private const int ENEMY_LOOP = 6;
	private Dictionary<int,Enemy> enemies;

	//initializes battle. 
	public override void Start(){
		enemies = new Dictionary<int, Enemy>();
		gc = GameObject.Find ("GameController");
		gameController = gc.GetComponent <GameController> ();
		InitializeEnemyDictionary ();
		GameObject background = GameObject.Find ("Background");
		background.GetComponent<SpriteRenderer> ().sprite = gameController.Backgrounds[gameController.BattleLoop];
		battlers = new List<Character> ();
		yourTeam = new List<Character> ();
		playerChar = gameController.YourPlayer;
		Debug.Log(playerChar.HP + "Player hp");
		partnerChar = gameController.YourPartner;
		status.text = "RP: " + playerChar.RP;
		enemy1= enemies[gameController.YourPlayer.PersonalityType % 3 * 2 + (ENEMY_LOOP * gameController.BattleLoop)];
		Debug.Log (gameController.YourPlayer.PersonalityType % 3 * 2 + (ENEMY_LOOP * gameController.BattleLoop) + "ENEMY 1 INDEX");
		enemy2 = enemies[gameController.YourPlayer.PersonalityType % 3  * 2 + (ENEMY_LOOP * gameController.BattleLoop)  + 1];
		GameObject enemy1Sprite = GameObject.Find ("Enemy1Sprite");
		enemy1Sprite.GetComponent<SpriteRenderer> ().sprite = enemy1.PlayerSprite;
		GameObject enemy2Sprite = GameObject.Find ("Enemy2Sprite");
		enemy2Sprite.GetComponent<SpriteRenderer> ().sprite = enemy2.PlayerSprite;
		enemy1.Name = "Enemy 1";
		enemy2.Name = "Enemy 2";
		enemy1.HP = gameController.BattleLoop * 2 + 10;
		enemy2.HP = gameController.BattleLoop * 2 + 10;
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
			ui.OnBattleEndDialogue (true);
		}
		if(!battlers.Contains(playerChar)){
			ui.OnBattleEndDialogue (false);
		}
	}
	//Enemy dictionary is used to generate the enemies in the different battles. The enemies' classes will depend on your player and partner's classes.  For the first battle, you will have an advantage against both enemies, battle 2 you will only 
	//have one advantage, and battle 3 will have no advantages.
	private void InitializeEnemyDictionary(){
		//enemies if your player is a magician, 1st battle.
		enemies.Add(0,new Enemy(new Warrior(),gameController.Sprites[3])); 
		enemies.Add(1,new Enemy(new Magician(),gameController.Sprites[5]));
		//enemies if your player is a warrior, 1st battle 
		enemies.Add(2,new Enemy(new Ranger(),gameController.Sprites[4])); 
		enemies.Add(3,new Enemy(new Warrior(),gameController.Sprites[3])); 
		//enemies if your player is a ranger, 1st battle
		enemies.Add(4, new Enemy(new Magician(),gameController.Sprites[5])); 
		enemies.Add(5, new Enemy(new Ranger(),gameController.Sprites[4])); 
		//enemies if your player is a magician, 2nd battle 
		enemies.Add(6,new Enemy(new Warrior(),gameController.Sprites[6])); 
		enemies.Add(7,new Enemy(new Ranger(),gameController.Sprites[7])); 
		//enemies if your player is a warrior, 2nd battle 
		enemies.Add(8,new Enemy(new Ranger(),gameController.Sprites[7])); 
		enemies.Add(9,new Enemy(new Magician(),gameController.Sprites[8])); 
		//enemies if your player is a ranger, 2nd battle 
		enemies.Add(10,new Enemy(new Magician(),gameController.Sprites[8])); 
		enemies.Add(11,new Enemy(new Warrior(),gameController.Sprites[6])); 
		//enemies if your player is a magician, 3rd battle 
		enemies.Add(12,new Enemy(new Ranger(),gameController.Sprites[10])); 
		enemies.Add(13,new Enemy(new Ranger(),gameController.Sprites[10])); 
		//enemies if your player is a warrior, 3rd battle 
		enemies.Add(14,new Enemy(new Magician(),gameController.Sprites[11])); 
		enemies.Add(15,new Enemy(new Magician(),gameController.Sprites[11])); 
		//enemies if your player is a ranger, 3rd battle 
		enemies.Add(16,new Enemy(new Warrior(),gameController.Sprites[9])); 
		enemies.Add(17,new Enemy(new Warrior(),gameController.Sprites[9])); 

	}

	// Method to trigger enemy attacks after both player characters attack.  will implement AI
	public void EnemyAttacks(){
		SelectedAction = enemy1.Type.Actions[0];
		Fight (yourTeam[Random.Range(0,yourTeam.Count)]);
	}

	//calculates team attack damage and tells ui to update labels
	public void DoTeamAttack(int damage){
		defender.HP -= damage;
		ui.UpdateDamageDealt (attacker.Name, defender.Name, damage);
		ui.UpdateHPLabels (defender.Name, battlers.IndexOf(defender), defender.HP);
		StartCoroutine(CheckIfDefeated ());
	}

	// Performs fighting moves (will use animation) when chosen.  Puts a delay between action selected and the move performing for a more natural feel
	public void Fight(Character defender){
		this.defender = defender;
		double damage = DealDamage (defender);
		ui.UpdateDamageDealt (attacker.Name, defender.Name, damage);
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
			} else {
				yourTeam.Remove (defender);
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
	public double DealDamage(Character defender){
		defender.HP -= selectedAction.CalculateDamage(attacker , defender) + gameController.BattleLoop;
		return selectedAction.CalculateDamage(attacker , defender) + gameController.BattleLoop;
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
