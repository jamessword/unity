using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMatrix : MonoBehaviour {

	static int[,] mapMatrix= new int[5,5]{
		{0,5,10,12,15},
		{5,0,5,5,8},
		{10,5,0,5,8},
		{12,5,5,0,5},
		{15,8,8,5,0},
	};

	static string[] places=new string[]{"C3","Canteen","Qinglou","Xincao","Library"};


	public static int calcuTime(string ori, string des){
		int oriidx = System.Array.IndexOf (places, ori);
		int desidx = System.Array.IndexOf (places, des);
		if(oriidx!=-1 && desidx!=-1){
			return mapMatrix[oriidx,desidx];
		}

		return -1;
	}

}
