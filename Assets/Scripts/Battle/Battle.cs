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
	private List<Character> attackablePlayers;
	private List<Character> attackableEnemies;
	private List<int> enemyRandomAttacks;
	private Character attacker;
	private Character defender;
	private int attackerIndex = 0;
	private GameObject gc;
	private GameController gameController;
	private const int FINAL_PLAYER = 2;
	private const int NUM_PERSONALITIES = 3;
	private const int FINAL_ENEMY = 4;
	private const int ENEMY_LOOP = 6;
	private const int DEFAULT_HP = 10;
	private Dictionary<int,Enemy> enemies;
	[SerializeField] private AudioClip shootArrow;
	private AudioSource source; 
	private int healCount = 3;
	//initializes battle. 

	public override void Start(){
		source = GetComponent<AudioSource> ();
		enemies = new Dictionary<int, Enemy>();
		gc = GameObject.Find ("GameController");
		gameController = gc.GetComponent <GameController> ();
		//between battles, the amount of times you can heal decreases
		healCount -= gameController.BattleLoop;
		InitializeEnemyDictionary ();
		GameObject background = GameObject.Find ("Background");
		background.GetComponent<SpriteRenderer> ().sprite = gameController.Backgrounds[gameController.BattleLoop];
		battlers = new List<Character> ();
		yourTeam = new List<Character> ();
		attackablePlayers = new List<Character> ();
		attackableEnemies = new List<Character> ();
		playerChar = gameController.YourPlayer;
		Debug.Log(playerChar.HP + "Player hp");
		partnerChar = gameController.YourPartner;
		status.text = "RP: " + playerChar.RP;
		enemy1= enemies[gameController.YourPlayer.PersonalityType % NUM_PERSONALITIES * 2 + (ENEMY_LOOP * gameController.BattleLoop)];
		enemy2 = enemies[gameController.YourPlayer.PersonalityType % NUM_PERSONALITIES  * 2 + (ENEMY_LOOP * gameController.BattleLoop)  + 1];
		GameObject enemy1Sprite = GameObject.Find ("Enemy1Sprite");
		enemy1Sprite.GetComponent<SpriteRenderer> ().sprite = enemy1.PlayerSprite;
		GameObject enemy2Sprite = GameObject.Find ("Enemy2Sprite");
		enemy2Sprite.GetComponent<SpriteRenderer> ().sprite = enemy2.PlayerSprite;
		enemy1.Name = "Enemy 1";
		enemy2.Name = "Enemy 2";
		enemy1.HP = gameController.BattleLoop * 2 + DEFAULT_HP;
		enemy2.HP = gameController.BattleLoop * 2 + DEFAULT_HP;
		ui.SetButtonListeners (playerChar);
		battlers.Add (playerChar);
		battlers.Add (partnerChar);
		battlers.Add (enemy1);
		battlers.Add (enemy2);
		for (int i = 0; i < battlers.Count; i++) {
			battlers [i].HealCount = healCount;
		}
		yourTeam.Add (playerChar);
		yourTeam.Add (partnerChar);
		attackablePlayers.Add (playerChar);
		attackablePlayers.Add (partnerChar);
		attackableEnemies.Add (enemy1);
		attackableEnemies.Add (enemy2);
		attacker = playerChar;
	}

	//checks to see if both enemies were defeated and will load the next scene if true
	public override void Update(){
		if (!battlers.Contains (enemy1) && !battlers.Contains (enemy2)) {
			ui.OnBattleEndDialogue (true);
			ui.ChangeButtonVisibility (false);
		}
		if(!battlers.Contains(playerChar)){
			ui.ChangeButtonVisibility (false);
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
		//if the enemy's HP is less than half and the enemy has heals available, heal
		if (attacker.HP <= (gameController.BattleLoop * 2 + DEFAULT_HP) / 2 && attacker.HealCount > 0) {
			StartCoroutine (Heal ());
		} else {
			if (attackablePlayers.Count > 0) {
				SelectedAction = enemy1.Type.Actions [0];
				//need to check for empty list
				Fight (attackablePlayers [Random.Range (0, attackablePlayers.Count)]);
			} else { 
				StartCoroutine (Block ());
			}
		}
	}

	//calculates team attack damage and tells ui to update labels
	public void DoTeamAttack(int damage){
		defender.HP -= damage;
		ui.UpdateDamageDealt (attacker.Name, defender.Name, damage);
		ui.UpdateHPLabels (defender.Name, battlers.IndexOf(defender), defender.HP, defender.HasEffectDamage);
		StartCoroutine(CheckIfDefeated (defender,true));
	}

	// Performs fighting moves (will use animation) when chosen.  Puts a delay between action selected and the move performing for a more natural feel
	public void Fight(Character defender){
		source.PlayOneShot (shootArrow);
		this.defender = defender;
		double damage = DealDamage (defender);
		//if the status effect attack hit, do status effect damage on the defender
		if (selectedAction.GetType().Name == "StatusEffectAttack" && damage > 0) {
			defender.HasEffectDamage = true;
		}
		ui.UpdateDamageDealt (attacker.Name, defender.Name, damage);
		ui.UpdateHPLabels (defender.Name, battlers.IndexOf(defender), defender.HP, defender.HasEffectDamage);
		StartCoroutine(CheckIfDefeated (defender,true));
	}

	public IEnumerator Block(){
		attacker.IsBlocking = true;
		attackablePlayers.Remove (attacker);
		ui.UpdateBlockStatus (attacker.Name);
		if (attacker.GetType ().Name == "Enemy") {
			Debug.Log ("Enemy is blocking!");
			ui.ChangeEnemyButtonVisibility (attacker.Name, false);
			attackableEnemies.Remove (attacker);
			Debug.Log("Attackable enemies count: " + attackableEnemies.Count);
		}
		yield return new WaitForSeconds (1);
		SwitchAttacker ();
	}

	//this method will check whether or not the defender was defeated in battle. If the defender was defeated, the UI will update accordingly and the battler will be taken out of the battler list
	public IEnumerator CheckIfDefeated(Character target, bool needToSwitch){
		if (target.HP <= 0) {
			ui.RemoveFromHPList (battlers.IndexOf (target));
			battlers.Remove (target);
			if (defender.GetType ().Name == "Enemy") {
				ui.ChangeEnemyButtonVisibility (target.Name, false);
			} else {
				yourTeam.Remove (target);
			}
		}
		yield return new WaitForSeconds (1);
		if (needToSwitch) {
			SwitchAttacker ();
		}
	}

	//property for setting/getting the move selected for the current turn
	public Action SelectedAction{
		get{return selectedAction;}
		set{ selectedAction = value; }
	}

	//will calculate damage dealt. More damage is dealt depending on the battle loop
	public double DealDamage(Character defender){
		double damageDealt = selectedAction.CalculateDamage(attacker , defender);
		//if the attack doesn't miss, do additional damage based on the battle loop
		if (damageDealt > 0) {
			damageDealt += gameController.BattleLoop;
		}
		defender.HP -= damageDealt;
		return damageDealt;
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

	public List<Character> AttackableEnemies{
		get{ return attackableEnemies; }
		set{ attackableEnemies = value; }
	}

	public IEnumerator Heal (){
		if (attacker.HP < DEFAULT_HP + gameController.BattleLoop * 2 && attacker.HealCount > 0) {
			if (attacker.HP <= DEFAULT_HP + gameController.BattleLoop * 2 - 2) {
				attacker.HP += gameController.BattleLoop + 2;
			} else {
				attacker.HP = DEFAULT_HP + gameController.BattleLoop * 2;
				}
			ui.UpdateHPLabels (attacker.Name, battlers.IndexOf (attacker), attacker.HP, defender.HasEffectDamage);
			ui.UpdateHealStatus (attacker.Name, gameController.BattleLoop + 2, true);
			attacker.HealCount--;
			yield return new WaitForSeconds (1);
			SwitchAttacker ();
		} else {
			ui.UpdateHealStatus (attacker.Name, 0, false);
		}
	}
	//allows for turn based attack system. 
	public void SwitchAttacker(){
		attackerIndex++;
		if (attackerIndex > battlers.Count-1) {
			attackerIndex = 0;
			ui.ChangeButtonVisibility (true);
		}
		attacker = battlers [attackerIndex];

		if (attacker.IsBlocking) {
			attacker.IsBlocking = false;
			if (attacker.GetType ().Name == "Enemy") {
				ui.ChangeEnemyButtonVisibility (attacker.Name, true);
				attackableEnemies.Add (attacker);
			} else {
				attackablePlayers.Add (attacker);
			}
		}
		if (attacker.GetType ().Name == "Enemy") {			
			ui.ChangeButtonVisibility (false);
			EnemyAttacks ();
		}
		ui.SetButtonListeners (battlers [attackerIndex]);

		//status effect damage will be dealt at the beginning of the affected player's turn
		if (attacker.HasEffectDamage) {
			attacker.HP -= 1;
			ui.UpdateHPLabels (attacker.Name, battlers.IndexOf(attacker), attacker.HP, true);
			StartCoroutine(CheckIfDefeated(attacker,false));
		}
		currentPlayer.text = attacker.Name + "'s turn";

	}

}
