using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float yOffset;
    [SerializeField] float zOffset;


    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, yOffset, player.transform.position.z - zOffset);
    }
}
