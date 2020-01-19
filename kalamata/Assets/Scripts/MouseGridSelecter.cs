using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGridSelecter : MonoBehaviour
{
    private Camera Camera;
    private Player Player;

    void Awake()
    {
        Player = ReInput.players.GetPlayer(0);
    }

    void Start ()
    {
        Camera = GetComponent<Camera>();
	}
	
	void Update ()
    {
        if (Player.GetButtonDown("Select"))
        {
            RaycastHit hit;

            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 hitLocation = hit.transform.position;
                Vector3 gridLocation = ConvertWorldCoordinateToGrid(hitLocation.x, hitLocation.z);
                Debug.Log("Mouse: " + Input.mousePosition + " Ray: " + ray.ToString() + "\nHit: " + hitLocation.ToString() + " Grid: " + gridLocation.ToString());
            }
        }

        // On mouse click:
        // Raycast based on click location
        // If hit:
        // Convert to board coordinates
        // Log grid coordinates

        // Next step:
        // Make a transparent square go over the highlighted area (ie not on click, just always)
    }

    // Move this to the board state or elsewhere. This is for testing for now
    public Vector3 ConvertWorldCoordinateToGrid(float x, float z)
    {
        return new Vector3(Mathf.Floor(x), 0, Mathf.Floor(z));
    }
}
