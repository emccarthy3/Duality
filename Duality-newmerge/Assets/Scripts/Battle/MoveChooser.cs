using UnityEngine;
using System.Collections;

public class MoveChooser : MonoBehaviour {
	[SerializeField] private GameObject panel;
	[SerializeField] private GameObject button;
	// Use this for initialization
	void Start () {
	
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
}
