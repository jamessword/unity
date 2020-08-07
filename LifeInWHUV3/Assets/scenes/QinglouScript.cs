using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;
public class QinglouScript : MonoBehaviour {

	public GameObject selfStudyPanelObj;
	public bool selfStudyPanelFlag;
	public Flowchart flowchart;

	static int[,] lessonMatrix= new int[2,7]{
		{0,1,2,3,0,5,0},
		{0,0,0,4,0,0,0}
	};

	void Start()
	{
		selfStudyPanelObj = GameObject.Find ("Canvas/SelfStudyPanel");
		selfStudyPanelObj.SetActive (false);
		selfStudyPanelFlag = false;

	}


	public void takeLesson_onclick()
	{
		//if(checkLesson())
		string time = PlayerPrefs.GetString("Time");
		int hour = int.Parse(time.Substring(0,2));
		int minute = int.Parse(time.Substring (3, 2));

		int date = PlayerPrefs.GetInt("Date");
		int lessonNum = -1;
		bool isMorning = false;

		for (int row = 0; row < 2; row++) 
		{
			if( lessonMatrix [row,date] != 0)
			{
				lessonNum = lessonMatrix [row,date];
				if (row == 0)
					isMorning = true;
			}
		}

		switch (lessonNum)
		{
		case -1:
				// ------------- modify here -------------------

				//UnityEditor.EditorUtility.DisplayDialog("提示", "当前时间段没有课哦！", "ok", "cancel");
				//flowchart.SendFungusMessage("noclass");

				//------------------------------------------------
				return;

		case 1:
			
			if ((hour == 9 && minute > 30) || (hour == 10 && minute < 20)) {

				// ------------- replace with c# conversation -------------------

				//C# conversation
				//UnityEditor.EditorUtility.DisplayDialog ("提示", "上了C#课", "ok", "cancel");
				//flowchart.ExecuteBlock("c#");

					//------------------------------------------------
				}
			else
			{
				// ------------- modify here -------------------

				//UnityEditor.EditorUtility.DisplayDialog ("提示", "现在不是上课时间。", "ok", "cancel");

				//------------------------------------------------

				return;
			}
			break;
		case 2:
			if ((hour == 9 && minute > 30) || (hour == 10 && minute < 20)) {

				// ------------- replace with jizu conversation-------------------

				//UnityEditor.EditorUtility.DisplayDialog ("提示", "上了计组课", "ok", "cancel");

				//------------------------------------------------
			}
			else
			{
				// ------------- modify here -------------------

				//UnityEditor.EditorUtility.DisplayDialog ("提示", "现在不是上课时间。", "ok", "cancel");

				//------------------------------------------------

				return;
			}
			break;
		case 3:
			if ((hour == 9 && minute > 30) || (hour == 10 && minute < 20)) {

				// ------------- replace with data structure conversation -------------------

				//UnityEditor.EditorUtility.DisplayDialog ("提示", "上了数据结构课。", "ok", "cancel");

				//------------------------------------------------
			}
			else
			{
				// ------------- modify here -------------------

				//UnityEditor.EditorUtility.DisplayDialog ("提示", "现在不是上课时间。", "ok", "cancel");

				//------------------------------------------------
				return;
			}
			break;
		case 4:
			if ((hour == 13 && minute > 45) || (hour == 14 && minute < 35)) {

				// ------------- replace with possibility conversation -------------------

				//UnityEditor.EditorUtility.DisplayDialog ("提示", "上了概率论", "ok", "cancel");

				//------------------------------------------------

				return;
			}
			else
			{
				// ------------- modify here -------------------

				//UnityEditor.EditorUtility.DisplayDialog ("提示", "现在不是上课时间。", "ok", "cancel");

				//------------------------------------------------

				return;
			}
			break;
		case 5:
			if ((hour == 13 && minute > 45) || (hour == 14 && minute < 35)) {

				// ------------- replace with java conversation -------------------

				//UnityEditor.EditorUtility.DisplayDialog ("提示", "上了Java", "ok", "cancel");

				//------------------------------------------------
			}
			else
			{
				// ------------- modify here -------------------

				//UnityEditor.EditorUtility.DisplayDialog ("提示", "现在不是上课时间。", "ok", "cancel");

				//------------------------------------------------

				return;
			}
			break;
		}

		//update time
		if (isMorning) {
			minute = 30;
			hour = 11;
		} 
		else 
		{
			minute = 30;
			hour = 16;
		}


		string currTime = hour.ToString()+":"+ minute.ToString();
		PlayerPrefs.SetString("Time", currTime);

		//update energy
		int energy = PlayerPrefs.GetInt("Energy");
		if (energy - 42  > 0) 
		{
			PlayerPrefs.SetInt("Energy", energy-42 );
		}
		else 
			PlayerPrefs.SetInt("Energy", 0);

		//update hunger
		int hunger = PlayerPrefs.GetInt("Hunger");
		if (hunger + 40 < 100) 
		{
			PlayerPrefs.SetInt("Hunger", hunger + 40 );
		}
		else 
			PlayerPrefs.SetInt("Hunger", 100);
	
	}

	public void selfStudy_onclick()
	{

		if (!selfStudyPanelFlag) 
		{
			selfStudyPanelObj.SetActive (true);
			selfStudyPanelFlag = true;
		}
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

		//UnityEditor.EditorUtility.DisplayDialog("自习结束", "对"+subject+"的" + studyTime.ToString() +"分钟自习结束了！","ok", "cancel");

	}

	public void leave_onClick()
	{
		SceneManager.LoadScene(1);
	}
		

}
