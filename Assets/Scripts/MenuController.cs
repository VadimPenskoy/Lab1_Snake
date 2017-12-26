using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

	public Slider sliderSpeed;
	public Slider sliderSpawnRate;

	

	void Awake() {
	
	}

	public void clickStart() {
		Application.LoadLevel ("Play");
		
	}

	public void clickOptions() {
		Application.LoadLevel ("Options");
		
	}

	public void clickCredits() {
		Application.LoadLevel ("Credits");
		
	}

	public void clickReturn() {
		Application.LoadLevel ("Start");
	
	}

	public void clickOptionsReturn() {
		PlayerPrefs.SetFloat ("Speed", sliderSpeed.value);
		PlayerPrefs.SetFloat ("Spawn Rate", sliderSpawnRate.value);
		clickReturn ();
	}
}
