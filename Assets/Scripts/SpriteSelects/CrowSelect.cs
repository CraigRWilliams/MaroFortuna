﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrowSelect : MonoBehaviour {
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnMouseDown()
    {

        bool available = false;


        if (Data.onCrewScene)
        {

            int i;
            for (i = 0; i < Data.currentChars.Count; i++)
            {
                if (Data.currentChars[i].charName == "Lucia the Crow")
                {
                    available = true;
                    break;
                }
            }

            if (available)
            {

                if (!Data.currentChars[i].isPicked)
                {
                    GameObject.Find("Lucia the Crow").GetComponent<SpriteRenderer>().color = Color.green;
                    Data.currentChars[i].setPicked();
                    Data.currentCharDesc = Data.currentChars[i];
                }
                else if (Data.currentChars[i].isPicked)
                {
                    GameObject.Find("Lucia the Crow").GetComponent<SpriteRenderer>().color = Color.white;
                    Data.currentChars[i].setPicked();
                }

            }

        }

        else
        {
            int i;
            for (i = 0; i < Data.currentChars.Count; i++)
            {
                if (Data.currentChars[i].charName == "Lucia the Crow")
                {
                    if (!Data.currentChars[i].onCooldown)
                    {
                        available = true;
                        break;
                    }
                }
            }

            if (available)
            {
                if (!(Data.currentChars[i].isPicked) && (Data.currentCrewSize < Data.pickedMission.squadSize))
                {

                    GameObject.Find("Lucia the Crow").GetComponent<SpriteRenderer>().color = Color.green;
                    Data.activeMissionChars.Add(Data.currentChars[i]);
                    Data.currentCrewSize += 1;
                    Data.currentChars[i].setPicked();
                }
                else if (Data.currentChars[i].isPicked)
                {
                    GameObject.Find("Lucia the Crow").GetComponent<SpriteRenderer>().color = Color.white;
                    Data.activeMissionChars.Remove(Data.currentChars[i]);
                    Data.currentCrewSize -= 1;
                    Data.currentChars[i].setPicked();
                }
            }
        }
    }
}