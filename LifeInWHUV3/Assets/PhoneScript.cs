using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneScript : MonoBehaviour {

	public GameObject phoneObj;
	public GameObject schedulePanelObj;
	public bool scheduleFlag;

	void Start()
	{
		phoneObj = GameObject.Find ("Canvas/PhonePanel");
		schedulePanelObj = GameObject.Find ("Canvas/SchedulePanel");

		if (schedulePanelObj != null) 
		{
			schedulePanelObj.SetActive (false);
			scheduleFlag = false;
		}

	}
	public void home_onClick()
	{
		phoneObj.SetActive (false);
	}

	public void phone_onClick()
	{
		phoneObj.SetActive (true);

		GameObject clockObj = GameObject.Find ("Canvas/PhonePanel/Clock");
		Text clock = (Text)clockObj.GetComponent<Text> ();
		clock.text = PlayerPrefs.GetString ("Time");
	}

	public void schedule_onClick()
	{
		if (scheduleFlag)
			schedulePanelObj.SetActive (false);
		else
			schedulePanelObj.SetActive (true);

		scheduleFlag = !scheduleFlag;
	}

}
