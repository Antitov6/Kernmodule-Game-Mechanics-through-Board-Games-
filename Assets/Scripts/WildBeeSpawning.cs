using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildBeeSpawning : MonoBehaviour
{

    [SerializeField] GameObject wildBeePrefab;

    [SerializeField] float refillTime;
    private float currentTime;
    public bool isActive;

    void Start()
    {
        isActive = true;
    }


    void Update()
    {
        if(gameObject.GetComponentInChildren<WildBabyBee>())
        {
            currentTime = refillTime;
        }
        else
        {
            currentTime -= Time.deltaTime;
            isActive = false;

            if (currentTime <= 0)
            {
                GameObject wildBee = Instantiate(wildBeePrefab, transform.position, Quaternion.identity);
                wildBee.transform.SetParent(transform);
                isActive = true;
            }
        }     
    }
}
