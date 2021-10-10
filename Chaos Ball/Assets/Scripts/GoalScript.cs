using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class GoalScript : MonoBehaviour
{
    public bool IsSolved = false;
    private GameObject colliderWith;
    private List<GameObject> ball = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
         colliderWith = other.gameObject;
         
        if (colliderWith.tag == gameObject.tag)
        {
            ball.Add(colliderWith);
            IsSolved = true;
            GetComponent<Light>().enabled = false;
            colliderWith.SetActive(false);
        }

    }

    public void Respawn()
    {
        GetComponent<Light>().enabled = true;
        IsSolved = false;
        for (int i = 0; i < ball.Count; i++)
        {
            ball[i].SetActive(true);
            if (ball[i].tag == "Blue")
            {
                ball[i].transform.localPosition = new Vector3(6,2,-6);
            }
            if (ball[i].tag == "Green")
            {
                ball[i].transform.localPosition = new Vector3(21,2,3);
            }
            if (ball[i].tag == "Orange")
            {
                ball[i].transform.localPosition = new Vector3(17,2,-15);
            }
            if (ball[i].tag == "Red")
            {
                ball[i].transform.localPosition = new Vector3(-8,2,-14);
            }
        }
        
        
    }
}
