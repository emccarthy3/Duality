using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	private float barDisplay; //current progress
	private Vector2 pos = new Vector2(20,40);
	private Vector2 size = new Vector2(300,30);
	private Texture2D emptyTex;
	private Texture2D fullTex;
	private float damage =.1f;

	void OnGUI() {

		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);

		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
		//DoDamage (.1f);
	}

	void Update() {
		//for this example, the bar display is linked to the current time,
		//however you would set this value based on your desired display
		//eg, the loading progress, the player's health, or whatever.
		if (damage != barDisplay) { 
			barDisplay = Time.time * 0.05f;
		}
		//        barDisplay = MyControlScript.staticHealth;
	}
	public void DoDamage(float damage){
		//barDisplay = 
		
	}
}
