using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemScript : MonoBehaviour {

	public GameObject helpPanelObj;
	public bool helpPanelFlag;

	void Start () {
		helpPanelObj = GameObject.Find ("Canvas/SystemBarPanel/HelpPanel");

		if (helpPanelObj != null) 
		{
			helpPanelObj.SetActive (false);
			helpPanelFlag = false;
		}
			
	}

	public void helpClose_onClick()
	{
		helpPanelObj.SetActive (false);
		helpPanelFlag = false;
	}

	public void help_onClick()
	{
		if (!helpPanelFlag) 
		{
			helpPanelObj.SetActive (true);
			helpPanelFlag = true;
		}
	}
	

}
