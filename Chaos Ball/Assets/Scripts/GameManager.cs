using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    public GoalScript blue, green, red, orange;
    public GameObject player, blueSphere, blueBall;
    private Transform playerPos;
    private FirstPersonController m_FirstPersonController;
    private bool isGameOver = false;
    private bool isRunning = false;
    private float elapsedTime = 0;

    void Update ()
    {
        isGameOver = blue.IsSolved && green.IsSolved && red.IsSolved && orange.IsSolved;
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    private void Start()
    {
        blueBall = blueSphere;
        playerPos = player.transform;
        m_FirstPersonController = player.GetComponent<FirstPersonController>();
        m_FirstPersonController.enabled = false;
    }

    void OnGUI()
    {
        
        Rect startButton = new Rect(Screen.width/2 - 120, Screen.height/2-60, 240, 30);
       if (!isRunning)
        {
            string  message = "Click or Press Enter to Play";
            if (GUI.Button(startButton, message) || Input.GetKeyDown(KeyCode.R))
            {
                isRunning = true;
                m_FirstPersonController.enabled = true;
            }
        }
       if(isGameOver) 
       {
           string message = "Press R to Play";
           GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height / 2, 130, 40), message);
           m_FirstPersonController.enabled = false;
           if (Input.GetKeyDown(KeyCode.R))
           {
               StartGame();
           }
       }
        if(isRunning)
        { 
            GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Your Time Is");
            GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), ((int)elapsedTime).ToString());
        }
    }

    private void StartGame()
    {
        blue.Respawn();
        green.Respawn();
        orange.Respawn();
        red.Respawn();
        isGameOver = false;
        m_FirstPersonController.enabled = true;
        //m_FirstPersonController.transform.localPosition = new Vector3(0,1,0);
        isRunning = true;
    }
}
