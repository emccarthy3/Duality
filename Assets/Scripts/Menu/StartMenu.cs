using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {
	[SerializeField] private Button startButton;
	[SerializeField] private Button storyButton;
	[SerializeField] private StoryPanel storyPanel;
	// Use this for initialization
	void Start () {
		startButton.onClick.AddListener(() =>  SwitchScenes());
		storyButton.onClick.AddListener(() =>  ShowStory());
		storyPanel.Close ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void SwitchScenes(){
		SceneManager.LoadScene ("Quiz");
	}

	public void ShowStory(){
		storyPanel.Open ();
	}

}
