using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviourPun
{
    Rigidbody rb;
    public float speed = 300.0f;
    private Vector3 movement;
    private string name;
    public int playerScore;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (GetComponent<NetworkView>().isMine)
        {
            name = PlayerPrefs.GetString("username");
            playerScore = 0;
        }
    }

    void Awake ()
    {
        DontDestroyOnLoad(this.gameObject);
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

    void OnLevelWasLoaded()
    {
        if (photonView.IsMine == true)
        {
            Debug.Log("level loaded");
            rb.transform.position = new Vector3(0f, 5f, 0f);
        }
    }

    public void updatePlayerScore(int score)
    {
        playerScore = playerScore + score;
    }
}
