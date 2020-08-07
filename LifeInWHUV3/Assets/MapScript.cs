using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MapScript : MonoBehaviour {


	GameObject currPosi = null;
	bool registerFlag = false;
	// Use this for initialization
	void Start () {

		//init info board
		if (!registerFlag) 
		{
			eventRegister ();
			registerFlag = true;
		}
		GameObject nameObj = GameObject.Find ("Canvas/InfoPanel/Username");
		Text name = (Text)nameObj.GetComponent<Text> ();
		name.text = PlayerPrefs.GetString("Name");

		updateAttributes ();


		GameObject clockObj = GameObject.Find ("Canvas/PhonePanel/Clock");
		Text clock = (Text)clockObj.GetComponent<Text> ();
		clock.text = PlayerPrefs.GetString("Time");
	
		updateDate ();

		string position = PlayerPrefs.GetString ("Position");
		setPosition (position);

	}


	void setPosition(string position)
	{
		GameObject[] posis = {GameObject.Find ("Canvas/MapPanel/Library"), GameObject.Find ("Canvas/MapPanel/Xincao"),
							GameObject.Find ("Canvas/MapPanel/Canteen"),GameObject.Find ("Canvas/MapPanel/C3"),
							GameObject.Find ("Canvas/MapPanel/Qinglou") };

		for (int i = 0; i < posis.Length; i++) 
		{
			if (posis[i].name.Equals( position))
			{
				currPosi = posis[i];
				PlayerPrefs.SetString("Position", currPosi.name);
				currPosi.GetComponent<Image> ().color = Color.gray;
			}
		}
			

	}

	void eventRegister()
	{
		GameObject c3Obj = GameObject.Find ("Canvas/MapPanel/C3");
		GameObject qinglouObj = GameObject.Find ("Canvas/MapPanel/Qinglou");
		GameObject libraryObj = GameObject.Find ("Canvas/MapPanel/Library");
		GameObject canteenObj = GameObject.Find ("Canvas/MapPanel/Canteen");
		GameObject xincaoObj = GameObject.Find ("Canvas/MapPanel/Xincao");

		Button c3 = (Button)c3Obj.GetComponent<Button> ();
		Button qinglou = (Button)qinglouObj.GetComponent<Button> ();
		Button library = (Button)libraryObj.GetComponent<Button> ();
		Button canteen = (Button)canteenObj.GetComponent<Button> ();
		Button xincao = (Button)xincaoObj.GetComponent<Button> ();

		c3.onClick.AddListener (delegate() {
				onClick (c3Obj);
		});

		qinglou.onClick.AddListener (delegate() {
				onClick (qinglouObj);
		});

		library.onClick.AddListener (delegate() {
				onClick (libraryObj);
		});

		canteen.onClick.AddListener (delegate() {
				onClick (canteenObj);
		});

		xincao.onClick.AddListener (delegate() {
				onClick (xincaoObj);
		});
	}


	void onClick (GameObject obj)
	{
		print ("click!");

		if (obj != currPosi) {
			print ("move to  " + obj.name);

			if (currPosi != null) 
				currPosi.GetComponent<Image> ().color = Color.white;
			obj.GetComponent<Image> ().color = Color.gray;



			// calculate move time
			int time = MoveMatrix.calcuTime (currPosi.name, obj.name);

			GameObject clockObj = GameObject.Find ("Canvas/PhonePanel/Clock");

			string clockText;
			if (clockObj != null) {
				Text clock = (Text)clockObj.GetComponent<Text> ();
				clockText = clock.text;
			} 
			else
			{
				clockText = PlayerPrefs.GetString ("Time");
			}


			print (clockText.Substring (0, 2));


			// update time
			int hour = int.Parse(clockText.Substring(0,2));
			int minute = int.Parse(clockText.Substring (3, 2));

			int week = PlayerPrefs.GetInt("Week");
			int date = PlayerPrefs.GetInt("Date");

			minute = minute + time;
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

			currPosi = obj;

			// update playerprefs
			PlayerPrefs.SetString("Position", currPosi.name);
			PlayerPrefs.SetString("Time", currTime);
			PlayerPrefs.SetInt("Week",week);
			PlayerPrefs.SetInt ("Date", date);

			// update UI text
			if (clockObj != null) 
			{
				Text clock = (Text)clockObj.GetComponent<Text> ();
				clock.text = currTime;
			}

			updateDate ();

			GameObject nameObj = GameObject.Find ("Canvas/InfoPanel/Username");
			Text name = (Text)nameObj.GetComponent<Text> ();
			name.text = PlayerPrefs.GetString("Name");

			//update state 
			GameObject stateObj = GameObject.Find ("Canvas/InfoPanel/State");
			Text state = (Text)stateObj.GetComponent<Text> ();
			string stateString = getStateString (currPosi.name);
			if(stateString!=null)
				state.text = "位置: "+ stateString;
		}

	}

	string getStateString(string position)
	{
		string[] scenes = {"Library", "Xincao", "Canteen", "C3", "Qinglou" };
		string[] discriptions= { "信图，自习/阅读的场所，开放时间为每天的8:00~22:00。", 
								 "信操，体育课/跑汉姆/锻炼身体的场所，全天开放。", 
								 "食堂，用餐场所，正餐供应时间为7:00~9:00, 11:00~13:00, 17:00~19:00。", 
								 "C3，宿舍，你可以在这里休息/自习/游戏。",
								 "青楼，信部教学楼，上课/自习的主要场所。" };
		for (int i = 0; i < scenes.Length; i++) 
		{
			if (position == scenes [i]) 
			{
				return discriptions [i];
			}
		}

		return null;
	}

	void updateAttributes()
	{
		GameObject attributesObj = GameObject.Find ("Canvas/InfoPanel/Attributes");
		Text attributes = (Text)attributesObj.GetComponent<Text> ();
		attributes.text =   "饥饿：" + PlayerPrefs.GetInt ("Hunger").ToString()  + "/100 \n\n" +
							"心情：" + PlayerPrefs.GetInt ("Mood").ToString() + "/100 \n\n" +
							"精力：" + PlayerPrefs.GetInt ("Energy").ToString()  + "/100 \n\n" +
							"健康：" + PlayerPrefs.GetInt ("Health").ToString()  + "/100 \n\n" +
							"账户余额：" + PlayerPrefs.GetInt ("Money").ToString()  + "¥";
	}

	void updateDate()
	{

		int week = PlayerPrefs.GetInt("Week");
		int date = PlayerPrefs.GetInt("Date");

		GameObject dateObj = GameObject.Find ("Canvas/PhonePanel/Date");
		if (dateObj != null) {
			Text dateText = (Text)dateObj.GetComponent<Text> ();
			string day = "";
			switch (date) {
			case 0:
				day = "周日";
				break;
			case 1:
				day = "周一";
				break;
			case 2:
				day = "周二";
				break;
			case 3:
				day = "周三";
				break;
			case 4:
				day = "周四";
				break;
			case 5:
				day = "周五";
				break;
			case 6:
				day = "周六";
				break;

			}
			dateText.text = "Week" + week.ToString () + "," + day + "                4G";
		}
	}
}
