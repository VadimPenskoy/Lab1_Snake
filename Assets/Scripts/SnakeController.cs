using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class SnakeController : MonoBehaviour {

	Vector2 dir = Vector2.right;
	List<Transform> tail = new List<Transform>();
	bool ate = false;

	private int score = -1;
	
	public GameObject tailPrefab;
	public Image scoreImage1;
	public Image scoreImage2;
	public Image scoreImage3;

	void Awake () {
		PlayerPrefs.SetInt ("Score", 0);
		string color = PlayerPrefs.GetString ("Color");
		switch (color) {
			default:
			case "White": 
				this.GetComponent<SpriteRenderer>().color = Color.white;
				this.GetComponent<SnakeController>().tailPrefab.GetComponent<SpriteRenderer>().color = Color.white;
				break;
			case "Red":
				this.GetComponent<SpriteRenderer>().color = Color.red;
				this.GetComponent<SnakeController>().tailPrefab.GetComponent<SpriteRenderer>().color = Color.red;
				break;
			case "Green":
				this.GetComponent<SpriteRenderer>().color = Color.green;
				this.GetComponent<SnakeController>().tailPrefab.GetComponent<SpriteRenderer>().color = Color.green;
				break;
			case "Blue":
				this.GetComponent<SpriteRenderer>().color = new Color(0, 116, 255, 255);
				this.GetComponent<SnakeController>().tailPrefab.GetComponent<SpriteRenderer>().color = new Color(0, 116, 255, 255);
				break;
		}
		updateScore ();
	}

	void Start () {
		float speed = 0.2f / PlayerPrefs.GetFloat("Speed");
		InvokeRepeating ("Move", speed, speed);
	}

	void Update () {
		if (Input.GetKey (KeyCode.RightArrow))
			dir = Vector2.right;
		else if (Input.GetKey (KeyCode.DownArrow))
			dir = -Vector2.up;
		else if (Input.GetKey (KeyCode.LeftArrow))
			dir = -Vector2.right;
		else if (Input.GetKey (KeyCode.UpArrow))
			dir = Vector2.up;
	}

	void Move() {
		Vector2 v = transform.position;
		transform.Translate (dir);

		if (ate) {
			GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
			tail.Insert(0, g.transform);
			ate = false;
		}

		else if (tail.Count > 0) {
			tail.Last ().position = v;
			tail.Insert (0, tail.Last ());
			tail.RemoveAt (tail.Count-1);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.name.StartsWith ("FoodPrefab")) {
			ate = true;
			Destroy (coll.gameObject);
			updateScore();
		} else {
			Application.LoadLevel ("GameOver");
		}
	}

	void updateScore() {
		score++;
		PlayerPrefs.SetInt ("Score", score);

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
