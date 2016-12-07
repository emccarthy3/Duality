using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelpMenu : MonoBehaviour {
	[SerializeField] private Button weaponsTriangle;
	[SerializeField] private Button moves;
	[SerializeField] private Button back;
	[SerializeField] private Button rp;
	[SerializeField] private Button teamAttack;
	[SerializeField] private Button dialogue;

	[SerializeField] private Text descriptionText;
	// Use this for initialization
	void Start () {
		back.gameObject.SetActive (false);
		descriptionText.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Open(){
		gameObject.SetActive (true);
	}

	public void Close(){
		gameObject.SetActive (false);
	}

	public void ChangeButtonVisibility(bool enable){
		weaponsTriangle.gameObject.SetActive (enable);
		moves.gameObject.SetActive (enable);
		rp.gameObject.SetActive (enable);
		teamAttack.gameObject.SetActive (enable);
		dialogue.gameObject.SetActive (enable);
		back.gameObject.SetActive (!enable);
		descriptionText.gameObject.SetActive (!enable);
	}

	public void Back(){
		ChangeButtonVisibility (true);
	}

	public void ShowWeaponsTriangle(){
		ChangeButtonVisibility (false);
		descriptionText.text = "The Weapons triangle determines any bonus damage dealt to the opponent when attacking.  When the attacking class has an advantage " +
		"the attack will deal x 2 damage.  Warriors are strong against rangers, rangers are strong against magicians, and magicians are strong against warriors." +
		"If the attacking character attacks someone who has an advantage against them, they will only deal .5 x damage, so strategize accordingly!";
	}

	public void Moves(){
		ChangeButtonVisibility (false);
		descriptionText.text = "Right now, all your moves will do 1 base damage (this will increase by 1 between battles to increase difficulty, let us know how we can make the moves more interesting!!).  Your team attack damage will be dependent on how many orbs you hit as well as your relationship with your partner (RP)";
	}
	public void RP(){
		ChangeButtonVisibility (false);
		descriptionText.text = "RP is dependent on your relationship with your partner.  If you had a good conversation with your partner, this value will be higher (Max value is 10).  Having a higher relationship will allow you to execute a more successful team move";
	}
	public void TeamAttack(){
		ChangeButtonVisibility (false);
		descriptionText.text = "In order to successfully do a Team Attack, you will have to hold down the proper arrow keys as the orbs fall. Remember, the higher your RP, the easier it will be to hit the orbs and do more damage.";
	}
	public void Dialogue(){
		ChangeButtonVisibility (false);
		descriptionText.text = "The dialogue you just had with your partner determined your relationship points.  If you pick answers your partner agrees with, your relationship will increase allowing team attacks to be more useful";
	}
}
