using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class XincaoScript : MonoBehaviour {

	public GameObject sportPanelObj;
	public bool sportPanelFlag;

	void Start()
	{
		sportPanelObj = GameObject.Find ("Canvas/SportPanel");
		sportPanelObj.SetActive (false);
		sportPanelFlag = false;
	}


	public void takePE_onclick()
	{
		string time = PlayerPrefs.GetString("Time");
		int hour = int.Parse(time.Substring(0,2));
		int minute = int.Parse(time.Substring (3, 2));

		int date = PlayerPrefs.GetInt ("Date");

		if (date == 4 && ((hour == 13 && minute > 45) || (hour == 14 && minute < 35))) {

			minute = 30;
			hour = 16;

			string currTime = hour.ToString()+":"+ minute.ToString();
			PlayerPrefs.SetString("Time", currTime);

			//update energy
			int energy = PlayerPrefs.GetInt("Energy");
			if (energy - 37  > 0) 
			{
				PlayerPrefs.SetInt("Energy", energy-21 );
			}
			else 
				PlayerPrefs.SetInt("Energy", 0);

			//update hunger
			int hunger = PlayerPrefs.GetInt("Hunger");
			if (hunger + 43 < 100) 
			{
				PlayerPrefs.SetInt("Hunger", hunger + 19 );
			}
			else 
				PlayerPrefs.SetInt("Hunger", 100);

			/*
			 * 
			 *       jump to PE game scene here
			 * 
			 */
		}
		else
		{
			// ------------ modify here ------------------
			//UnityEditor.EditorUtility.DisplayDialog("提示", "当前没有体育课", "ok", "cancel");
			// -------------------------------------------
		}
	}



	public void takeHam_onclick()
	{
		string time = PlayerPrefs.GetString("Time");
		int hour = int.Parse(time.Substring(0,2));
		int minute = int.Parse(time.Substring (3, 2));

		int date = PlayerPrefs.GetInt ("Date");
		int week = PlayerPrefs.GetInt ("Week");

		minute += 15;
		while (minute >= 60) 
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


		//update energy
		int energy = PlayerPrefs.GetInt("Energy");
		if (energy - 21  > 0) 
		{
			PlayerPrefs.SetInt("Energy", energy-21 );
		}
		else 
			PlayerPrefs.SetInt("Energy", 0);

		//update hunger
		int hunger = PlayerPrefs.GetInt("Hunger");
		if (hunger + 19 < 100) 
		{
			PlayerPrefs.SetInt("Hunger", hunger + 19 );
		}
		else 
			PlayerPrefs.SetInt("Hunger", 100);


		// -------------modify here----------------

		//UnityEditor.EditorUtility.DisplayDialog("汉姆运动", "进行了一次汉姆运动!", "ok", "cancel");

		// ----------------------------------------
	}

	public void takeSports_onclick()
	{
		if (!sportPanelFlag) 
		{
			sportPanelObj.SetActive (true);
			sportPanelFlag = true;
		}
	}

	public void sportStart_onClick()
	{
		GameObject sportTimeObj = GameObject.Find ("Canvas/SportPanel/SportTime");
		Dropdown sportTime =(Dropdown) sportTimeObj.GetComponent<Dropdown>();
		int sport = int.Parse(sportTime.captionText.text);

		//update time
		string time = PlayerPrefs.GetString ("Time");
		int hour = int.Parse(time.Substring(0,2));
		int minute = int.Parse(time.Substring (3, 2));

		int week = PlayerPrefs.GetInt("Week");
		int date = PlayerPrefs.GetInt("Date");

		minute = minute + sport;
		while (minute >= 60) 
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

		//update energy
		int energy = PlayerPrefs.GetInt("Energy");
		if (energy - 3 * sport / 15 < 100) 
		{
			PlayerPrefs.SetInt("Energy", energy - 3 * sport / 15 );
		}
		else 
			PlayerPrefs.SetInt("Energy", 100);

		//update hunger
		int hunger = PlayerPrefs.GetInt("Hunger");
		if (hunger + 10 * sport / 15 < 100) 
		{
			PlayerPrefs.SetInt("Hunger", hunger + 10 * sport / 15 );
		}
		else 
			PlayerPrefs.SetInt("Hunger", 100);

		//update health


		//--------------modify here! ---------------

		//UnityEditor.EditorUtility.DisplayDialog("运动结束", "本次运动时长" + sport.ToString() +"分钟，生命在于运动！","ok", "cancel");

		//------------------------------------------
	}

	public void sportCancel_onClick()
	{
		sportPanelObj.SetActive (false);
		sportPanelFlag = false;
	}

	public void leave_onClick()
	{
		SceneManager.LoadScene(1);
	}
}
