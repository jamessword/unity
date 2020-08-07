using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LibraryScript : MonoBehaviour {

	public GameObject selfStudyPanelObj;
	public bool selfStudyPanelFlag;

	public GameObject readPanelObj;
	public bool readPanelFlag;

	void Start()
	{
		selfStudyPanelObj = GameObject.Find ("Canvas/SelfStudyPanel");
		selfStudyPanelObj.SetActive (false);
		selfStudyPanelFlag = false;

		readPanelObj = GameObject.Find ("Canvas/ReadPanel");
		readPanelObj.SetActive (false);
		readPanelFlag = false;
	}

	public void leave_onClick()
	{
		SceneManager.LoadScene(1);

	}

	public void reading_onClick()
	{
		if (!readPanelFlag) 
		{
			readPanelObj.SetActive (true);
			readPanelFlag = true;
		}

	}

	public void readStart_onClick()
	{
		GameObject readTimeObj = GameObject.Find ("Canvas/ReadPanel/ReadTime");
		Dropdown readTime =(Dropdown) readTimeObj.GetComponent<Dropdown>();
		int read = int.Parse(readTime.captionText.text);

		//update time
		string time = PlayerPrefs.GetString ("Time");
		int hour = int.Parse(time.Substring(0,2));
		int minute = int.Parse(time.Substring (3, 2));

		int week = PlayerPrefs.GetInt("Week");
		int date = PlayerPrefs.GetInt("Date");

		minute = minute + read;
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
		if (energy - 3 * read / 15 < 100) 
		{
			PlayerPrefs.SetInt("Energy", energy - 3 * read / 15 );
		}
		else 
			PlayerPrefs.SetInt("Energy", 100);

		//update hunger
		int hunger = PlayerPrefs.GetInt("Hunger");
		if (hunger + 8 * read / 15 < 100) 
		{
			PlayerPrefs.SetInt("Hunger", hunger + 10 * read / 15 );
		}
		else 
			PlayerPrefs.SetInt("Hunger", 100);



		//--------------modify here! ---------------

		//UnityEditor.EditorUtility.DisplayDialog("阅读结束", "本次阅读时长" + read.ToString() +"分钟，又涨姿势了！","ok", "cancel");

		//------------------------------------------
	}

	public void readCancel_onClick()
	{
		readPanelObj.SetActive (false);
		readPanelFlag = false;
	}



	public void selfStudy_onClick()
	{
		if (!selfStudyPanelFlag) 
		{
			selfStudyPanelObj.SetActive (true);
			selfStudyPanelFlag = true;
		}

		//UnityEditor.EditorUtility.DisplayDialog("button clicked", "button <自习> clicked!","ok", "cancel");
	}

	public void selfStudyCancel_onClick()
	{
		selfStudyPanelObj.SetActive (false);
		selfStudyPanelFlag = false;
	}
		
	public void selfStudyStart_onClick()
	{
		
		GameObject selfStudySubjectObj = GameObject.Find ("Canvas/SelfStudyPanel/SelfStudySubject");
		Dropdown selfStudySubject = (Dropdown)selfStudySubjectObj.GetComponent<Dropdown>();
		string subject = selfStudySubject.captionText.text;

		GameObject selfStudyTimeObj = GameObject.Find ("Canvas/SelfStudyPanel/SelfStudyTime");
		Dropdown selfStudyTime =(Dropdown) selfStudyTimeObj.GetComponent<Dropdown>();
		int studyTime = int.Parse(selfStudyTime.captionText.text);

		//update time
		string time = PlayerPrefs.GetString ("Time");
		int hour = int.Parse(time.Substring(0,2));
		int minute = int.Parse(time.Substring (3, 2));

		int week = PlayerPrefs.GetInt("Week");
		int date = PlayerPrefs.GetInt("Date");

		minute = minute + studyTime;
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

		//update energy
		int energy = PlayerPrefs.GetInt("Energy");
		if (energy - 12 * studyTime / 30 > 0) 
		{
			PlayerPrefs.SetInt("Energy", energy - 12 * studyTime / 30 );
		}
		else 
			PlayerPrefs.SetInt("Energy", 0);

		//update hunger
		int hunger = PlayerPrefs.GetInt("Hunger");
		if (hunger + 15 * studyTime / 30 < 100) 
		{
			PlayerPrefs.SetInt("Hunger", hunger + 15 * studyTime / 30 );
		}
		else 
			PlayerPrefs.SetInt("Hunger", 100);



		//--------------modify here! ---------------

		//UnityEditor.EditorUtility.DisplayDialog("自习结束", "对"+subject+"的" + studyTime.ToString() +"分钟自习结束了！","ok", "cancel");

		//------------------------- ---------------
	}
}
