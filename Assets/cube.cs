using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cube : MonoBehaviour {

	public GameObject levelText;
	public GameObject unitNumberText;
	public GameObject levelUpIndicator;
	public int maxLevel = 4;
	public float[] produceSpd = {2.0f, 1.5f, 1.0f, 0.5f};
	int[] unitLimit = { 40, 60, 80, 100 };
	int[] cost = { 5, 10, 20, 40 };

	private int unitNumber = 0;
	private int level = 1;
	private float prevTime = 0.0f;
	private float currentSpd = 0.0f;

	private float doubleClickStart = 0;

	// Use this for initialization
	void Start () {
		currentSpd = produceSpd [0];
		levelUpIndicator.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		levelText.GetComponent<Text> ().text = "Level " + level.ToString();
		unitNumberText.GetComponent<Text> ().text = unitNumber.ToString();

		if (unitNumber >= cost [level - 1]) {
			levelUpIndicator.SetActive (true);
		} else {
			levelUpIndicator.SetActive (false);
		}
	}

	void FixedUpdate () {
		if (Time.time - prevTime >= currentSpd) {
			produceUnit ();
			prevTime = Time.time;
		}
	}

	void produceUnit ()
	{
		if (unitNumber < unitLimit [level - 1]) {
			unitNumber++;
		}
	}

	void levelUp()
	{
		if (unitNumber >= cost [level - 1]) {
			if (level == maxLevel) {
				Debug.Log ("level is max.");
				return;
			}
			Debug.Log ("level up!");
			unitNumber -= cost [level - 1];
			level++;
			currentSpd = produceSpd [level - 1];
		}
	}


	void OnMouseUp ()
	{
		if (Time.time - doubleClickStart < 0.3f) {
			OnDoubleClick ();
			doubleClickStart = -1;
		} 
		else {
			doubleClickStart = Time.time;
		}
	}

	void OnDoubleClick()
	{
		levelUp ();
	}
}
