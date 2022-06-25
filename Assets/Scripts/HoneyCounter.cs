using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoneyCounter : MonoBehaviour
{

    private int playerCollectedHoney;
    [SerializeField] int honeyAmountToWin;
    private Slider slider;
    [SerializeField] ParticleSystem honeyPartical;
    [SerializeField] Transform honeyParticalPosition;
    [SerializeField] GameObject winScreen;

    void Start()
    {
        slider = GetComponent<Slider>();
        playerCollectedHoney = 0;
    }


    void Update()
    {
        
    }

    public void AddHoneyPlayer()
    {
        playerCollectedHoney += 1;
        slider.value = playerCollectedHoney;
        ParticleSystem honeyParticalObject = Instantiate(honeyPartical, honeyParticalPosition.position, honeyParticalPosition.rotation);
        honeyParticalObject.transform.SetParent(honeyParticalPosition);

        if (playerCollectedHoney >= honeyAmountToWin)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
