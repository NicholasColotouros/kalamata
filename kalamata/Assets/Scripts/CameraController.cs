using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float MinVerticalRotation = 15;
    public float MaxVerticalRotation = 80;

    public float MinDistance = 5;
    public float MaxDistance = 15;

    private Transform CameraPivot;
    private Player Player;
    
    void Awake()
    {
        Player = ReInput.players.GetPlayer(0);
    }

    void Start ()
    {
        CameraPivot = transform.parent.transform;
        transform.LookAt(CameraPivot.transform);
	}
	
	void Update ()
    {
        ProcessRotationInput();
        ProcessZoomInput();
    }

    void ProcessRotationInput()
    {
        if (Player.GetButtonTimedPress("ActivateRotation", 0))
        {
            float horizontalRot = Player.GetAxis("Rotate Horizontal");
            float verticalRot = Player.GetAxis("Rotate Vertical");


            Vector3 currentRotation = CameraPivot.eulerAngles;
            currentRotation += new Vector3(verticalRot, horizontalRot, 0);
            currentRotation.x = Mathf.Clamp(currentRotation.x, MinVerticalRotation, MaxVerticalRotation);
            CameraPivot.eulerAngles = currentRotation;
        }
    }

    void ProcessZoomInput()
    {
        // Camera is on the -Z so we invert
        Vector3 localposition = transform.localPosition;
        localposition.z = Mathf.Clamp(localposition.z += Player.GetAxis("Zoom"), -MaxDistance, -MinDistance);

        transform.localPosition = localposition;
    }
}
