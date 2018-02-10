using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minVerticalRotation = 15;
    public float maxVerticalRotation = 80;

    public float minDistance = 5;
    public float maxDistance = 15;

    private Transform cameraPivot;
    private Player player;
    
    void Awake()
    {
        player = ReInput.players.GetPlayer(0);
    }

    void Start ()
    {
        cameraPivot = transform.parent.transform;
        transform.LookAt(cameraPivot.transform);
	}
	
	void Update ()
    {
        ProcessRotationInput();
        ProcessZoomInput();
    }

    void ProcessRotationInput()
    {
        if (player.GetButtonTimedPress("ActivateRotation", 0))
        {
            float horizontalRot = player.GetAxis("Rotate Horizontal");
            float verticalRot = player.GetAxis("Rotate Vertical");


            Vector3 currentRotation = cameraPivot.eulerAngles;
            currentRotation += new Vector3(verticalRot, horizontalRot, 0);
            currentRotation.x = Mathf.Clamp(currentRotation.x, minVerticalRotation, maxVerticalRotation);
            cameraPivot.eulerAngles = currentRotation;
        }
    }

    void ProcessZoomInput()
    {
        // Camera is on the -Z so we invert
        Vector3 localposition = transform.localPosition;
        localposition.z = Mathf.Clamp(localposition.z += player.GetAxis("Zoom"), -maxDistance, -minDistance);

        transform.localPosition = localposition;
    }
}
