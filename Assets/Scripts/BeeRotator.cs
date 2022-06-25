using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeRotator : MonoBehaviour
{

    [SerializeField] float rotateSpeed;
    private float yRotation;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yRotation -= rotateSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
