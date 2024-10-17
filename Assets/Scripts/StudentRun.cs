using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StudentRun : MonoBehaviour
{
    private Rigidbody2D body ;
    [SerializeField] private StudentRunSpot studentRunSpot ;
    private float speed = 5f ;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>() ;
    }

    // Update is called once per frame
    void Update()
    {
        if (studentRunSpot.playerEnter) {
            body.velocity = new Vector2(-speed,0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player") {
            Destroy(gameObject) ;
        }
    }
}