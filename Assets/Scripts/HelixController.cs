using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 LastTapPosition;
    private Vector3 startPosition;
    public float speed = 0.1f;
    void Start()
    {
        startPosition = transform.localEulerAngles;

    }

    
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Vector2 CurrentTapPosition = Input.mousePosition;
            if (LastTapPosition == Vector2.zero)
            {
                LastTapPosition = CurrentTapPosition;
            }
            float distance = LastTapPosition.x - CurrentTapPosition.x;
            transform.Rotate(Vector3.up * distance*speed);
            LastTapPosition = CurrentTapPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            LastTapPosition = Vector2.zero;
        }
    }
}
