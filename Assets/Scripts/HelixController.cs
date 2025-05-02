using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 LastTapPosition;
    private Vector3 startPosition;
    public float speed = 0.1f;

    public Transform topTransform;
    public Transform goalTransform;

    public GameObject HelixLevelPrefab;

    public List<Stage> allStages = new List<Stage>();

    public float helixDistance;

    private List<GameObject> spawnedLevesl = new List<GameObject>();

    private void Awake()
    {
        helixDistance = topTransform.localPosition.y - goalTransform.localPosition.y + .1f;
        //loadStage(0);
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

    public void loadStage(int stageNumber)
    {

    }
}
