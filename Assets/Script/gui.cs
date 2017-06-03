using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gui : MonoBehaviour {

	float doubleClickStart = 0;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {



		if(Input.GetMouseButtonDown(0))
		{
			// do something
			if ((Time.time - doubleClickStart) < 0.3f)
			{
				this.OnDoubleClick();
				doubleClickStart = -1;
			}
			else
			{
				doubleClickStart = Time.time;
			}
		}
	}

	void OnDoubleClick()
	{
		//Debug.Log("Double Clicked!");
	}

	void onMouseUp()
	{
		//Debug.Log("Mouse up!");
	}

}
