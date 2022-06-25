using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeColony : MonoBehaviour
{

    [SerializeField] GameObject babyBeePrefab;
    [SerializeField] float babyBeePositionOffsetMin;
    [SerializeField] float babyBeePositionOffsetMax;
    private BabyBee[] amountOffBabyBees;

    [SerializeField] GameObject stingPrefab;
    [SerializeField] Transform stingSpawnPoint;
    [SerializeField] float stingspeed;

    private Animator beeDeathAnimation;


    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            amountOffBabyBees = GetComponentsInChildren<BabyBee>();

            if (amountOffBabyBees.Length >= 1)
            {
                var sting = Instantiate(stingPrefab, stingSpawnPoint.position, stingSpawnPoint.rotation);
                //sting.GetComponent<Rigidbody>().velocity = stingSpawnPoint.up * stingspeed * Time.deltaTime;

                Animator babyBeeAnimation = GetComponentInChildren<Animator>();
                babyBeeAnimation.SetTrigger("Death");
                Destroy(babyBeeAnimation.gameObject, 1f);
            }
        }
    }


    public void AddBabyBee()
    {
        float spawnPositionXmin = transform.position.x - Random.Range(babyBeePositionOffsetMin, babyBeePositionOffsetMax);
        float spawnPositionXPlus = transform.position.x + Random.Range(babyBeePositionOffsetMin, babyBeePositionOffsetMax);
        float spawnPositionXRandom;
        float spawnPositionZmin = transform.position.z - Random.Range(babyBeePositionOffsetMin, babyBeePositionOffsetMax);
        float spawnPositionZPlus = transform.position.z + Random.Range(babyBeePositionOffsetMin, babyBeePositionOffsetMax);
        float spawnPositionZRandom;
        int randNumberX = Random.Range(0, 2);
        int randNumberZ = Random.Range(0, 2);

        if (randNumberX == 0)
        {
            spawnPositionXRandom = spawnPositionXmin;
        }
        else
        {
            spawnPositionXRandom = spawnPositionXPlus;
        }

        if (randNumberZ == 0)
        {
            spawnPositionZRandom = spawnPositionZmin;
        }
        else
        {
            spawnPositionZRandom = spawnPositionZPlus;
        }

        Vector3 spawnPosition = new Vector3(spawnPositionXRandom, transform.position.y, spawnPositionZRandom);
        GameObject babyBee =  Instantiate(babyBeePrefab, spawnPosition, transform.rotation);
        babyBee.transform.SetParent(transform);
    }
}
