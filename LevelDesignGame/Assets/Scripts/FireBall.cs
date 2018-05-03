using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
    public GameObject objectA;
    public GameObject objectB;
    Vector3 positionA;
    Vector3 positionB;
    bool goingA;
    Rigidbody2D rb;
    float speed;
	// Use this for initialization
	void Start () {
        speed = 8.0f;
        rb = GetComponent<Rigidbody2D>();
        positionA = objectA.transform.position;
        positionB = objectB.transform.position;
        Destroy(objectA);
        Destroy(objectB);
	}
	
	// Update is called once per frame
	void Update () {
        if (goingA) {
            if (Vector2.Distance(positionA, transform.position)>0.1f) {
                rb.velocity = (positionA - transform.position).normalized * speed;
            } else {
                goingA = false;
                transform.position = positionA;
            }
        } else {
            if (Vector2.Distance(positionB, transform.position) > 0.1f) {
                rb.velocity = (positionB - transform.position).normalized * speed;
            } else {
                goingA = true;
                transform.position = positionB;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            GameLogic.instance.KillPlayer();
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Player") {
            GameLogic.instance.KillPlayer();
        }
    }

}
