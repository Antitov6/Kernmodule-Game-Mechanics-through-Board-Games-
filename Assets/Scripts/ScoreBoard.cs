using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{

    public int scorePlayer;
    public int scoreEnemy1;
    public int scoreEnemy2;

    [SerializeField] GameObject lossScreen;

    [SerializeField] Material blueMaterial;
    [SerializeField] Material redMaterial;
    [SerializeField] Material yellowMaterial;
    [SerializeField] Material basicMeterial;

    // Start is called before the first frame update
    void Start()
    {
        scorePlayer = 0;
        scoreEnemy1 = 0;
        scoreEnemy2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (scoreEnemy1 > scoreEnemy2 && scoreEnemy1 > scorePlayer)
        {
            FindObjectOfType<BeeHive>().GetComponent<MeshRenderer>().material = redMaterial;
        }
        else if (scoreEnemy2 > scoreEnemy1 && scoreEnemy2 > scorePlayer)
        {
            FindObjectOfType<BeeHive>().GetComponent<MeshRenderer>().material = blueMaterial;
        }
        else if (scorePlayer > scoreEnemy1 && scorePlayer > scoreEnemy2)
        {
            FindObjectOfType<BeeHive>().GetComponent<MeshRenderer>().material = yellowMaterial;
        }*/
        //else
        //{
            //FindObjectOfType<BeeHive>().GetComponent<MeshRenderer>().material = basicMeterial;
        //}


    }

    public void AddScorePlayer()
    {
        scorePlayer += 1;

        if(scorePlayer >= 5)
        {
            
        }
    }
    public void AddScoreEnemy1()
    {
        scoreEnemy1 += 1;

        if (scoreEnemy1 >= 6)
        {
            GameOver();
        }
    }

    public void AddScoreEnemy2()
    {
        scoreEnemy2 += 1;

        if (scoreEnemy2 >= 6)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        lossScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
