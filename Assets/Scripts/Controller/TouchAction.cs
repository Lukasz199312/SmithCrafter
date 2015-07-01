using UnityEngine;
using System.Collections;

public class TouchAction : MonoBehaviour{

    public enum Direction
    {
        LEFT,
        RIGHT,
        NO_DETECTED_MOVE,
    };

    private Vector2 Old_Position = new Vector2();
    private Vector2 New_Postion = new Vector2();
    private Direction TouchPhaseDirection = Direction.NO_DETECTED_MOVE;
    private bool isMoved = false;

    public Direction GetLastDirection()
    {
        return TouchPhaseDirection;
    }

    public void ResetPhaseDirection() 
    { 
        TouchPhaseDirection = Direction.NO_DETECTED_MOVE; 
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

 
}
