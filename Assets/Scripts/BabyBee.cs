using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBee : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Sting>())
        {
            if (other.gameObject.tag != "PlayerSting")
            {
                Destroy(other.gameObject);
                animator.SetTrigger("Death");
                Destroy(this.gameObject, 1f);
            }
        }
    }
}
