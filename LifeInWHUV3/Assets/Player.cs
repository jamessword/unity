using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//姓名
	private string mName = "lzj";
	private string mPosition = "c3";
	private string mTime = "9:00";
	private int mWeek = 1;

	private int mHunger = 0;
	private int mEmotion = 60;
	private int mEnergy = 100;
	private int mHealth = 100;
	private int mMoney = 1000;


	//init
	void init()
	{

		string mName = "lzj";
		string mPosition = "c3";
		string mTime = "9:00";
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

	}

}
