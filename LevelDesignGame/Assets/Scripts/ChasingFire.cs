using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingFire : MonoBehaviour {
    // Use this for initialization
    Rigidbody2D rb;
    float currentSpeed;
    float currentDistance;
    float MAX_Distance;
    float MAX_Speed;
    float MIN_Speed;
    public Transform target;
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        MAX_Speed = 17.5f;
        MIN_Speed = 2.5f;
        MAX_Distance = 30.0f;
        rb.gravityScale = 0;
	}

    // Update is called once per frame
    void Update() {
        if (GameLogic.instance != null) {
            if (GameLogic.instance.started) {
                currentDistance = target.position.x - transform.position.x;
                currentSpeed = Mathf.Clamp((currentDistance / MAX_Distance * MAX_Speed), MIN_Speed, MAX_Speed);
                rb.velocity = new Vector2(currentSpeed, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            collision.GetComponent<PlayerController>().Die();
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Player") {
            collision.GetComponent<PlayerController>().Die();
        }
    }
}
