using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScript : MonoBehaviour {

	public void enter_onClick()
	{
		string posi = PlayerPrefs.GetString("Position");

		string[] scenes = {"Library", "Xincao", "Canteen", "C3", "Qinglou" };

		int posiNum = -1;

		string time = PlayerPrefs.GetString("Time");
		int hour = int.Parse(time.Substring(0,2));
		int minute = int.Parse(time.Substring (3, 2));

		for (int i = 0; i < scenes.Length; i++) 
		{
			if (posi == scenes [i]) 
			{
				posiNum = i;
				break;
				//SceneManager.LoadScene (2 + i);
				//print ("load "+posi);
			}
		}

		switch (posiNum) 
		{
		case -1:
			return;
		case 0:
			if (hour < 8 || hour > 22) 
			{
				// ----------------------

				//UnityEditor.EditorUtility.DisplayDialog("提示", "图书馆还没开放，请留意开放时间。" ,"ok", "cancel");

				// ----------------------
				return;
			}
			break;
		case 2:
			if (hour < 7 || (hour>9 &&hour<11) || (hour>13 &&hour<17) || hour > 19) 
			{
				// ----------------------

				//UnityEditor.EditorUtility.DisplayDialog("提示", "还未到用餐时间，食堂未供应饭菜，请留意开放时间。" ,"ok", "cancel");

				// ----------------------
				return;
			}
			break;
		case 4:
			if (hour < 7|| hour > 22) 
			{
				// ----------------------

				//UnityEditor.EditorUtility.DisplayDialog("提示", "教学楼还没开放，请留意开放时间。" ,"ok", "cancel");

				// ----------------------
				return;
			}
			break;
		}

		SceneManager.LoadScene (2 + posiNum);
	}
}
