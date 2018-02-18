using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardState : MonoBehaviour
{

    public const int BoardLength = 0;
    public const int BoardWidth = 0;
    public int[,] Board = new int[BoardLength, BoardWidth]; // Will only store the height for now. Pawns to be added soon

    private Vector2 ConvertWorldCoordinateToGrid(int x, int z)
    {
        return new Vector3();
    }

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
