using UnityEngine;
using System.Collections;

public class Player {
	private string _classType;
	private int _hp;
	private int _rp;
	private string _name;
	private bool isBlocking;
	public Player (){
	}
	public Player(string _name,string _classType,int _hp){
		this._name = _name;
		this._classType = _classType;
		this._hp = _hp;
	}
	// Use this for initialization
	void Start () {
		isBlocking = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Attack(){
		//if enemy is warrior  damage = 3
		//if enemy is mage  damage = 1
		// if enemy is ranger damage =5
	}

	public int HP{
		get{
			return _hp;}
		set{
			_hp = value;
		}
	}
	public void setBlocking(bool isBlocking){
		this.isBlocking = isBlocking;
	}
	public bool getBlocking(){
		return isBlocking;
	}
	public string ClassType{
		get{
			return _classType;}
		set{
			_classType= value;
		}
	}
	public int RP {
		get {
			return _rp;
		}
		set {
			_rp = value;
		}
	}
		public string Name{
			get{
				return _name;}
			set{
				_name = value;
			}
	}

		
}
