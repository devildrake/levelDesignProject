using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb;
    public Vector2 maxSpeed;
    public Vector2 acceleration;
    public float speedMultiplier;
    public float slowTimer;
    public float slowMultiplier;
    public Vector2 auxiliarSpeed;
    bool added = false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        maxSpeed = new Vector2(20.0f, 30.0f);
        acceleration = new Vector2(15,35.0f);
        slowTimer = 0;
        speedMultiplier = 1;

	}

    public void GetSlowed(float time) {
        slowTimer = time;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameLogic.instance != null) {

            if (!added) {
                GameLogic.instance.player = this;
                GameLogic.instance.originalPlayerPos = transform.position;
                added = true;
            }

            if (GameLogic.instance.started) {
                if (slowTimer > 0) {
                    if (auxiliarSpeed.x == 0 && auxiliarSpeed.y == 0) {
                        auxiliarSpeed = rb.velocity;
                    }

                    slowMultiplier = 0.3f;
                    slowTimer -= Time.deltaTime;

                    if (InputManager.upButton) {
                        auxiliarSpeed.y += acceleration.y * Time.deltaTime;
                        rb.gravityScale = 0.05f;
                    } else {
                        rb.gravityScale = 5.0f;
                    }

                    if (InputManager.rightButton) {
                        auxiliarSpeed.x += acceleration.x * Time.deltaTime;
                    } else {
                        auxiliarSpeed.x -= acceleration.x * Time.deltaTime;
                    }

                    if (rb != null) {
                        auxiliarSpeed.y = Mathf.Clamp(auxiliarSpeed.y, -maxSpeed.y, maxSpeed.y);
                        auxiliarSpeed.x = Mathf.Clamp(auxiliarSpeed.x, 2, maxSpeed.x);
                        rb.velocity = auxiliarSpeed*slowMultiplier;
                    }


                } else {
                    auxiliarSpeed = new Vector2(0, 0);
                    slowTimer = 0;
                    slowMultiplier = 1;
                    Vector2 finalVelocity = rb.velocity;
                    if (InputManager.upButton) {
                        finalVelocity.y += acceleration.y * Time.deltaTime;
                        rb.gravityScale = 0.05f;
                    } else {
                        rb.gravityScale = 5.0f;
                    }

                    if (InputManager.rightButton) {
                        finalVelocity.x += speedMultiplier * acceleration.x * Time.deltaTime;
                    } else {
                        finalVelocity.x -= acceleration.x * Time.deltaTime;
                    }

                    if (rb != null) {
                        finalVelocity.y = Mathf.Clamp(finalVelocity.y, -maxSpeed.y, maxSpeed.y);
                        finalVelocity.x = Mathf.Clamp(finalVelocity.x, 2, maxSpeed.x * speedMultiplier);
                        rb.velocity = finalVelocity;
                    }
                }


            } else {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(0,0);
            }
        }
	}


}
