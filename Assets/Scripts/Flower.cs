using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    public bool hasNectar;
    private ParticleSystem nectarPartical;

    [SerializeField] float refillTime;
    private float currentTime;

    void Start()
    {
        hasNectar = true;
        currentTime = refillTime;
        nectarPartical = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!hasNectar)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                nectarPartical.Play();
                hasNectar = true;
                currentTime = refillTime;
            }
        }  
    }

    public void DissableNectar()
    {
        hasNectar = false;
        nectarPartical.Pause();
        nectarPartical.Clear();
    }


}
