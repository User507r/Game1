using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{

    public int Halth;
    public Player player;
    public enum State { stay, walk, atack, idle}

    public State state;

    public float speed;

    public Transform[] points = new Transform[2];

    Rigidbody2D rb;

    public bool flip;
    void Start()
    {
        state = State.walk;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();
    }

    private bool CheckDistPlayer()
    {
        bool close = false;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= 5) close = true;
        return close;
    }




    void Update()
    {
        if(CheckDistPlayer()) state = State.atack; else state = State.walk;
        switch (state) 
        {
            case State.idle: break;
            case State.atack: Atack(); break;
            case State.walk: Walk(); break;
            case State.stay: break;


        }

    }

    void Atack() 
    {
        Debug.Log("Atack");
    
    }

    void Walk()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= points[0].position.x && !flip)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            flip = true;
        }
        else if (transform.position.x <= points[1].position.x && flip)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            flip = false;
        }


    }


}