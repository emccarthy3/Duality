using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Battle : MonoBehaviour {
	int turn = 0;

	private Character playerChar;
	private Character partnerChar;
	private Character enemy1;
	private Character enemy2;
	private Moves selectedMove;
	[SerializeField] private Text status;
	[SerializeField] private Text currentPlayer;
	[SerializeField] private UIController ui;
	private List<Character> battlers;

	private List<int> enemyRandomAttacks;
	private Character attacker;
	private Character defender;
	//used to keep track of turns


	private const int LAST_ATTACKER = 3;
	private const int NUM_PLAYERS = 2;
	private int battleCount =1;

	//adds all battlers to a list in order to allow a loop through for turn based RPG


	void Start () {
		
		//get these characters from the first scene
		playerChar= new Player ();
		partnerChar= new Ally();
		enemy1= new Enemy();
		enemy2 = new Enemy ();
		ui.SetButtonListeners (playerChar);
		//playerChar.RP = 8;
		//partnerChar.RP = 8;
		//ui.SetButtonListeners(playerChar);
	}
	public void EnemyAttacks(){
		enemy1.Attack ();
		enemy2.Attack ();
		//ui.EnableButtonsForPlayerAttack
		//right now gui calls attack
	//attacker.attack

	}


	public IEnumerator Fight(string action){
		status.text = action + SelectedMove;
		SelectedMove.MoveBehavior ();
		yield return new WaitForSeconds (1);
		currentPlayer.text = attacker+ "'s turn";
	}

	public Moves SelectedMove{
		get{return selectedMove;}
		set{ selectedMove = value; }
	}
/*	public void SwitchAttacker(){
		if (battleCount == LAST_ATTACKER) {
			ui.EnableButtonsForPlayerAttack();
		}else{
			Debug.Log (battlers [0]);
			//attacker = (Attacker)battlers[battleCount + 1]; 
			//attacker.setBlocking(false);
		}
		if (battleCount == 2 ) {
			ui.DisableButtonsForEnemyAttack();
			attacker.Attack();
		}
	}
	*/
	/*

/*	public void SwitchAttacker(){
		if (battlers.IndexOf (_attacker) == 3) {
			_attacker = battlers [0];
			ui.EnableButtonsForPlayerAttack();
		}else{
			_attacker = battlers [battlers.IndexOf (_attacker) + 1]; 
			_attacker.setBlocking(false);
		}if (battlers.IndexOf (_attacker) >=2 ) {
			ui.DisableButtonsForEnemyAttack();
			EnemyAttack ();
		}
	}
>>>>>>> d569f4b257595d5cd20ae31c2e66afec25266df4
	// Update is called once per frame
	void Update () {
		if((enemy1Char.HP <=0 && enemy2Char.HP <= 0) || (playerChar.HP <=0 && partnerChar.HP <=0)){
			status.text = "Game Over";
			ui.DisableButtonsForEnemyAttack ();
		}
	}
	public void EnemyAttack(){
		_defender = battlers[Random.Range(0,2)];
		if (!_defender.getBlocking()) {
			_defender.HP -= CalculateDamage ();
			ui.UpdateHPLabels (_defender.Name, battlers.IndexOf (_defender), _defender.HP);
			StartCoroutine (Fight (_attacker.Name + " dealt " + CalculateDamage () + " damage to " + _defender.Name));
		} else {
			status.text = _defender + "is blocking right now!";
		}
	}
	public void DoubleAttack(string defenderName){
		if (defenderName.Equals ("Enemy1")) {
			_defender = enemy1Char;
		} else {
			_defender = enemy2Char;
		}
		if (!_defender.getBlocking()) {
			_defender.HP -= _attacker.RP;
			ui.UpdateHPLabels (_defender.Name, battlers.IndexOf (_defender), _defender.HP);
			StartCoroutine (Fight (_attacker.Name + " dealt " + playerChar.RP + " damage to " + _defender.Name + "with their partner"));
		} else {
			status.text = _defender + "is blocking right now!";
		}

	}
	public void Heal(){
		if (_attacker.HP <= 8) {
			_attacker.HP += 2;
			ui.UpdateHPLabels(_attacker.Name, battlers.IndexOf(_attacker),_attacker.HP);
		}
		StartCoroutine (Fight(_attacker.Name + " recovered 2 HP "));

	}
	public void Block(){
		_attacker.setBlocking(true);
		StartCoroutine (Fight(_attacker.Name + " is blocking "));

	}
	public void SingleAttack(string defenderName){
		if (defenderName.Equals ("Enemy1")) {
			_defender = enemy1Char;
		} else {
			_defender = enemy2Char;
		}
		if (!_defender.getBlocking()) {
			_defender.HP -= CalculateDamage ();
			ui.UpdateHPLabels (_defender.Name, battlers.IndexOf (_defender), _defender.HP);
			StartCoroutine (Fight (_attacker.Name + " dealt " + CalculateDamage () + " damage to " + _defender.Name));
		} else {
			status.text = _defender + "is blocking right now!";
			SingleAttack (battlers [battlers.IndexOf (_defender) + 1].Name);
		}


	}
<<<<<<< HEAD

=======
	public IEnumerator Fight(string action){
		status.text = action;
		yield return new WaitForSeconds (1);
		SwitchAttacker();
		currentPlayer.text = _attacker.Name + "'s turn";
	}
>>>>>>> d569f4b257595d5cd20ae31c2e66afec25266df4
	private int CalculateDamage(){
		//make a hashmap for this
		int damage =0;
		if(_attacker.ClassType.Equals("W")){
			if(_defender.ClassType.Equals("M")){
				damage = 1;
			}
			else if(_defender.ClassType.Equals("R")){
				damage = 5;
			}
			else{
				damage = 3;
			}
		}
			else if(_attacker.ClassType.Equals("M")){
				if(_defender.ClassType.Equals("M")){
					damage = 3;
				}
				else if(_defender.ClassType.Equals("R")){
					damage = 1;
				}
				else{
					damage = 5;
				}
		} else if(_attacker.ClassType.Equals("R")){
			if(_defender.ClassType.Equals("M")){
				damage = 5;
			}
			else if(_defender.ClassType.Equals("R")){
				damage = 3;
			}
			else{
				damage = 1;
			}
		} 
		return damage;
	}
	public Player Defender{
		get{
			return _defender;}
		set{
			_defender= value;
		}
	} */
}
