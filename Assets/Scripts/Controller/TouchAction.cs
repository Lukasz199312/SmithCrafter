using UnityEngine;
using System.Collections;

public class TouchAction : MonoBehaviour{

    public enum Direction
    {
        LEFT,
        RIGHT,
        NO_DETECTED_MOVE,
    };

    public float MinimumDistance;

    private TouchPhase Phase = new TouchPhase();
    private Vector2 StartPoint;
    private Vector2 EndPoint;
    private bool isMoved;
    public Direction MoveDirection { get; private set; }

	// Use this for initialization
	void Start () {
        MoveDirection = Direction.NO_DETECTED_MOVE;
	}
	
	// Update is called once per frame
	void Update () {
        MoveDirection = Direction.NO_DETECTED_MOVE;
        foreach (Touch touch in Input.touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    MoveDirection = Direction.NO_DETECTED_MOVE;
                    StartPoint = touch.position;
                    break;
                case TouchPhase.Moved:
                    isMoved = true;
                    break;
                case TouchPhase.Ended:
                    if (isMoved == true)
                    {
                        float Distance = Vector2.Distance(StartPoint, touch.position);
                        if (Distance > MinimumDistance)
                        {
                            if (StartPoint.x < touch.position.x)
                            {
                                MoveDirection = Direction.RIGHT;
                            }
                            else MoveDirection = Direction.LEFT;
                            isMoved = false;
                        }
                    }
                    break;

            }
        }
	}

 
}
