using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform target;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (GameLogic.instance != null) {
            if (GameLogic.instance.started) {
                Vector3 desiredPosition;
                Vector3 smoothedPosition;

                desiredPosition = new Vector3(target.position.x + 22, transform.position.y, -10);
                smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 2);
                transform.position = smoothedPosition;
            }
        }
    }
}
