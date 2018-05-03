using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetableObject : MonoBehaviour {
    public bool added=false;
    public Vector3 originalPos;
    public virtual void ResetPosition() {
        transform.position = originalPos;
    }
}
