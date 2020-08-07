using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour {

	/*
	// Use this for initialization
	void Start () {
		
	}
	*/

	public void NewGame_onClick()
	{
		string mName = "lzj";
		string mPosition = "C3";
		string mTime = "09:00";
		int mWeek = 1;
		int mDate = 0;

		int mHunger = 0;
		int mMood = 60;
		int mEnergy = 100;
		int mHealth = 100;
		int mMoney = 1000;

		//保存数据
		PlayerPrefs.SetString("Name", mName);
		PlayerPrefs.SetString("Position", mPosition);
		PlayerPrefs.SetString("Time", mTime);
		PlayerPrefs.SetInt("Week", mWeek);
		PlayerPrefs.SetInt("Date", mDate);

		PlayerPrefs.SetInt("Hunger", mHunger);
		PlayerPrefs.SetInt("Mood", mMood);
		PlayerPrefs.SetInt("Energy", mEnergy);
		PlayerPrefs.SetInt("Health", mHealth);
		PlayerPrefs.SetInt("Money", mMoney);

		//SceneManager.LoadScene(1);
		SceneManager.LoadScene(7);
	}
}
