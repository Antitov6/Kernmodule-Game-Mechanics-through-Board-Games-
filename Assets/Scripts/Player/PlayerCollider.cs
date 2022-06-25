using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    private bool collectedNectar;

    private ParticleSystem honeyPartical;

    [SerializeField] GameObject slider;
    [SerializeField] GameObject lossScreen;

    private Animator animator;

    void Start()
    {
        collectedNectar = false;
        honeyPartical = GetComponentInChildren<ParticleSystem>();
        honeyPartical.Pause();
        animator = GetComponentInParent<Animator>();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        DeathPlayer(other);
        AddBabyBee(other);
        Flower(other);
        BeeHive(other);
    }

    private void DeathPlayer(Collider other)
    {
        if (other.GetComponent<Sting>())
        {
            if(other.gameObject.tag != "PlayerSting")
            {
                animator.SetTrigger("Death");
                Destroy(this.gameObject, 1f);
                Destroy(other.gameObject);
                lossScreen.SetActive(true);
                Time.timeScale = 0f;
            }     
        }
    }

    private void AddBabyBee(Collider other)
    {
        if (other.GetComponent<WildBabyBee>())
        {
            gameObject.GetComponent<BeeColony>().AddBabyBee();
            Destroy(other.gameObject);
        }
    }


    private void Flower(Collider other)
    {
        if (other.GetComponent<Flower>())
        {
            if (other.GetComponent<Flower>().hasNectar)
            {
                other.GetComponent<Flower>().DissableNectar();
                collectedNectar = true;
                honeyPartical.Play();
            }
        }
    }

    private void BeeHive(Collider other)
    {
        if (other.GetComponent<BeeHive>())
        {
            if (collectedNectar)
            {
                for (int i = 0; i < 3; i++)
                {
                    gameObject.GetComponent<BeeColony>().AddBabyBee();
                }

                slider.GetComponent<HoneyCounter>().AddHoneyPlayer();
                collectedNectar = false;
                honeyPartical.Pause();
                honeyPartical.Clear();
            }
        }
    }
}
