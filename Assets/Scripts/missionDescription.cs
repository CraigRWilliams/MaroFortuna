﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class missionDescription : MonoBehaviour {
	// Use this for initialization
	void Start () {



        if (Data.characterSelected)
		    Data.currentCharDesc.isPicked = false;    //make sure that the isPicked isn't still flagged from crew menu
        Data.onCrewScene = false;

		//select the description of the mission picked
		string missionDesc = Data.pickedMission.description;
		Text guiText = GameObject.Find("Description").GetComponent<Text>();
		guiText.text = Data.pickedMission.title + "\n" + missionDesc;


        /*
		//at end of displaying messages clear isListed properties for missions 
		foreach(Mission m in Data.missionList){
			m.isListed = false;
		}
        */



		for (int i = 0; i < Data.charList.Count; i++) {
            GameObject.Find(Data.charList[i].charName).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/" + Data.charList[i].charName + " Sil");
            GameObject.Find(Data.charList[i].charName).GetComponent<SpriteRenderer>().color = Color.gray;
        }

        int level;
        for (int i = 0; i < Data.currentChars.Count; i++)
        {
           
            float x = ((Data.currentChars[i].experience) / 500);
            level = (int)(1 + x);
            GameObject.Find(Data.currentChars[i].charName + " lvl").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Circle" + level);


            GameObject.Find(Data.currentChars[i].charName).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/" + Data.currentChars[i].charName);
            if (Data.currentChars[i].onCooldown)
            {
                GameObject.Find(Data.currentChars[i].charName).GetComponent<SpriteRenderer>().color = Color.gray;
            }

        }

    }
	
	// Update is called once per frame
	void Update () {
		//string remaining = "";
		Text guiText = GameObject.Find("Remaining").GetComponent<Text>();
		guiText.text = "Characters Needed:\n               " + (Data.pickedMission.squadSize - Data.currentCrewSize);
        if((Data.pickedMission.squadSize - Data.currentCrewSize) == 0)
            guiText.color = Color.white;

    }
}
