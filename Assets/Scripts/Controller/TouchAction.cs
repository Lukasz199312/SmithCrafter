using UnityEngine;
using System.Collections;

public class TouchAction : MonoBehaviour{

    public enum Direction
    {
        LEFT,
        RIGHT,
        NO_DETECTED_MOVE,
    };

    public enum SwapState
    {
        ENABLED,
        DISABLED,
        MOVED,
    };

    public float MinimumDistance;
    public SwapState Swap{ get; set; }

    private TouchPhase Phase = new TouchPhase();
    private Vector2 StartPoint;
    private Vector2 EndPoint;
    private bool isMoved;
    public Direction MoveDirection { get; private set; }
    public GameObject SelectedObject { get; private set; }
    private GameObject tmpSelectedObject;


    public void UntouchedObject()
    {
        SelectedObject = null;
        tmpSelectedObject = null;
    }

	// Use this for initialization
	void Start () {
        MoveDirection = Direction.NO_DETECTED_MOVE;
        Swap = SwapState.ENABLED;
	}
	
	// Update is called once per frame
	void Update () {
        MoveDirection = Direction.NO_DETECTED_MOVE;
        foreach (Touch touch in Input.touches)
        {
            Debug.Log(touch.phase);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    MoveDirection = Direction.NO_DETECTED_MOVE;
                    StartPoint = touch.position;
                    
                    Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                    RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                    if (hit != null && hit.collider != null)
                    {
                        tmpSelectedObject = hit.collider.gameObject;
                    }

                    break;
                case TouchPhase.Moved:
                    if (Swap == SwapState.ENABLED) isMoved = true;
                    Swap = SwapState.MOVED;
                    break;
                case TouchPhase.Ended:
                    if (isMoved == true && Swap == SwapState.MOVED)
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
                    else if (isMoved == false)
                    {
                        SelectedObject = tmpSelectedObject;
                    }
                    break;

            }
        }

	}

    private void DetectTouchOnGameObject()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit != null && hit.collider != null)
        {
            Debug.Log("I'm hitting " + hit.collider.name);
        }
    }

}
