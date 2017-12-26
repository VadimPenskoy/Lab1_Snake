using UnityEngine;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public void whiteClick() {
		PlayerPrefs.SetString ("Color", "White");
	}

	public void redClick() {
		PlayerPrefs.SetString ("Color", "Red");
	}

	public void greenClick() {
		PlayerPrefs.SetString ("Color", "Green");
	}

	public void blueClick() {
		PlayerPrefs.SetString ("Color", "Blue");
	}
}
