using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : ResetableObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void ResetPosition() {
        GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            GameLogic.instance.coinsGrabbed++;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
