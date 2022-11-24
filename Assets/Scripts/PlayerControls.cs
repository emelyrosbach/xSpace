using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviourPun
{
    Rigidbody rb;
    public float speed = 300.0f;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (photonView.IsMine == false)
        {
            return;
        }

        if (photonView.IsMine == true)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            movement = new Vector3(x, 0, z).normalized;
        }

    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector3 direction)
    {
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
}
