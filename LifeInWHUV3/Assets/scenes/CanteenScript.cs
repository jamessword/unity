using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanteenScript : MonoBehaviour {

	public void haveMeal_onclick()
	{
		// ------------ modify here! ---------------

		//UnityEditor.EditorUtility.DisplayDialog("提示", "吃了一顿饭，饥饿值下降了，花费了15¥。", "ok", "cancel");

		// -----------------------------------------

		int hunger = PlayerPrefs.GetInt ("Hunger");
		int money = PlayerPrefs.GetInt ("Money");

		hunger -= 60;
		if(hunger<= 0)
			hunger = 0;
		money -= 15;

		PlayerPrefs.SetInt ("Hunger",hunger);
		PlayerPrefs.SetInt ("Money", money);

		//update time
		int mealTime = 15;

		string time = PlayerPrefs.GetString ("Time");
		int hour = int.Parse(time.Substring(0,2));
		int minute = int.Parse(time.Substring (3, 2));

		int week = PlayerPrefs.GetInt("Week");
		int date = PlayerPrefs.GetInt("Date");

		minute = minute + mealTime;
		if (minute >= 60) 
		{
			minute -= 60;
			hour += 1;
		}

		if (hour >= 24) 
		{
			hour -= 24;
			date++;
		}

		if (date >= 7) 
		{
			date -= 7;
			week++;
		}


		string zeroHour = "0", zeroMinute = "0";
		if (hour >= 10)
			zeroHour = "";
		if (minute >= 10)
			zeroMinute = "";

		string currTime = zeroHour + hour.ToString()+":"+ zeroMinute + minute.ToString();
		PlayerPrefs.SetString("Time", currTime);

	}

	public void leave_onClick()
	{
		SceneManager.LoadScene(1);
	}
		
}
