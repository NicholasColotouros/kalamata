using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform cameraPivot;

    // For zooming
    public float minDist;
    public float maxDist;

    // For rotating vertically
    public float minXRotation = 0;
    public float maxXRotation = 90;

    private float currentRotation = 0;
    private float currentDistance = 0;

    // Use this for initialization
    void Start () {
        transform.LookAt(transform.parent.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		// TODO Start with right click + mouse rotation and then throw in rewired
	}
}
