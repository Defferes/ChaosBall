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
    private Transform posBall;

    private void OnTriggerEnter(Collider other)
    {
         colliderWith = other.gameObject;
         
        if (colliderWith.tag == gameObject.tag)
        {
            IsSolved = true;
            GetComponent<Light>().enabled = false;
            colliderWith.SetActive(false);
        }

    }

    public void Respawn()
    {
        Random rnd = new Random();
        GetComponent<Light>().enabled = true;
        IsSolved = false;
        colliderWith.SetActive(true);
        if (colliderWith.tag == "Blue")
        {
            colliderWith.transform.localPosition = new Vector3(6,2,-6);
        }
        if (colliderWith.tag == "Green")
        {
            colliderWith.transform.localPosition = new Vector3(21,2,3);
        }
        if (colliderWith.tag == "Orange")
        {
            colliderWith.transform.localPosition = new Vector3(17,2,-15);
        }
        if (colliderWith.tag == "Red")
        {
            colliderWith.transform.localPosition = new Vector3(-8,2,-14);
        }
        
    }
}
