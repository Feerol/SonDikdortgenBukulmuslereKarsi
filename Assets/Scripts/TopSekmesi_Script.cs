using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopSekmesi_Script : MonoBehaviour
{   
    public GameManagerScript gameManager;
    Rigidbody2D rb;
    Vector3 LastVelocity;

    public static bool isDead;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LastVelocity=rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed=LastVelocity.magnitude;
        var direction=Vector3.Reflect(LastVelocity.normalized,collision.contacts[0].normal);
        rb.velocity=direction*Mathf.Max(speed,0f);

        
        
        if(collision.gameObject.name =="SonEngel")
        {
            gameManager.winner();
        }
        if(collision.gameObject.name =="Wall3" && !isDead)
        {
            isDead=true;
            gameManager.gameOver();
        }

        
    }
}
