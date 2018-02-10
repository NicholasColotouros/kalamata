using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minVerticalRotation = 15;
    public float maxVerticalRotation = 80;

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
        // TODO Start with right click + mouse rotation and then throw in rewired
        float horizontalRot = player.GetAxis("Rotate Horizontal");
        float verticalRot = player.GetAxis("Rotate Vertical");

        Vector3 currentRotation = cameraPivot.eulerAngles;
        currentRotation += new Vector3(verticalRot, horizontalRot, 0);
        currentRotation.x = Mathf.Clamp(currentRotation.x, minVerticalRotation, maxVerticalRotation);
        cameraPivot.eulerAngles = currentRotation;
    }
}
