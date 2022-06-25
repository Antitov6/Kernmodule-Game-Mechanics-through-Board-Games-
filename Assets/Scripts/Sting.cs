using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting : MonoBehaviour
{

    [SerializeField] float life;
    [SerializeField] float stingspeed;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Destroy(gameObject, life);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * stingspeed * Time.deltaTime;
    }
}
