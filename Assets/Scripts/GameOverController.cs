using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverController : MonoBehaviour {

	public Image scoreImage1;
	public Image scoreImage2;
	public Image scoreImage3;

	void Start () {
		int score = PlayerPrefs.GetInt ("Score");

		int[] digits = new int[3];
		for (int i = 0; i < 3; i++)
			digits[i] = 0;
		
		string strScore = score.ToString ();
		
		int j = strScore.Length - 1;
		for (int i = 2; i >= 0; i--) {
			digits[i] = strScore[j] - '0';
			j--;
			if (j < 0)
				break;
		}
		
		scoreImage1.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite>(string.Format ("sprites/{0}", toWord(digits[2])));
		scoreImage2.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite>(string.Format ("sprites/{0}", toWord(digits[1])));
		scoreImage3.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite>(string.Format ("sprites/{0}", toWord(digits[0])));
	}

	string toWord(int n) {
		switch (n) {
		case 1: 
			return "one";
		case 2:
			return "two";
		case 3:
			return "three";
		case 4:
			return "four";
		case 5:
			return "five";
		case 6: 
			return "six";
		case 7: 
			return "seven";
		case 8:
			return "eight";
		case 9:
			return "nine";
		case 0:
			return "zero";
		default:
			return "zero";
		}
	}
}
