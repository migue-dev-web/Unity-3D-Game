using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HelixController : MonoBehaviour
{
    private Vector2 LastTapPosition;
    private Vector3 startRotation;
    public float speed = 0.9f;

    public Transform topTransform;
    public Transform goalTransform;

    public GameObject HelixLevelPrefab;

    public List<Stage> allStages = new List<Stage>();

    public float helixDistance;

    private List<GameObject> spawnedLevesl = new List<GameObject>();

    private void Awake()
    {
        helixDistance = topTransform.localPosition.y - goalTransform.localPosition.y -.1f;
        loadStage(0);
         startRotation = transform.localEulerAngles;
    }
    
    void Update()
{
    Vector2 currentTapPosition = Vector2.zero;

    if (Mouse.current != null && Mouse.current.leftButton.isPressed)
    {
        currentTapPosition = Mouse.current.position.ReadValue();
    }
    else if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
    {
        currentTapPosition = Touchscreen.current.primaryTouch.position.ReadValue();
    }
    else
    {
        LastTapPosition = Vector2.zero;
        return;
    }

    if (LastTapPosition == Vector2.zero)
    {
        LastTapPosition = currentTapPosition;
    }

    float distance = LastTapPosition.x - currentTapPosition.x;
    transform.Rotate(Vector3.up * distance * speed);
    LastTapPosition = currentTapPosition;
}

void HandleInput(Vector2 currentTapPosition)
{
    if (LastTapPosition == Vector2.zero)
        LastTapPosition = currentTapPosition;

    float distance = LastTapPosition.x - currentTapPosition.x;
    transform.Rotate(Vector3.up * distance * speed);
    LastTapPosition = currentTapPosition;
}

    public void loadStage(int stageNumber)
    {
        Stage stage = allStages[Mathf.Clamp(stageNumber,0,allStages.Count-1)];

        if (stage == null){
            Debug.Log("no hay nada ");
            return;
        }
        if (stageNumber > allStages.Count)
        {
            
        }
        Debug.Log("COLOR: " + stage.stageBackgroundColor);
        Camera.main.backgroundColor = allStages[stageNumber].stageBackgroundColor;
        FindFirstObjectByType<BallController>().GetComponent<Renderer>().material.color = allStages[stageNumber].stageball;
        transform.localEulerAngles = startRotation;
        foreach (GameObject go in spawnedLevesl)
{
    Destroy(go);
}
spawnedLevesl.Clear();
        float levelDistance = helixDistance / stage.levels.Count;
        float spawnPosY = topTransform.localPosition.y;

        for (int i = 0; i < stage.levels.Count; i++)
        {
            spawnPosY -= levelDistance;
            GameObject level = Instantiate(HelixLevelPrefab,transform);
            level.transform.localPosition = new Vector3(0, spawnPosY, 0);
             spawnedLevesl.Add(level);

             int partToDisable = 12-stage.levels[i].partCount;
             List<GameObject> disabledParts = new List<GameObject>();

             while (disabledParts.Count<partToDisable)
             {
                GameObject randomPart = level.transform.GetChild(Random.Range(0,level.transform.childCount)).gameObject;
                if (!disabledParts.Contains(randomPart)){
                    randomPart.SetActive(false);
                    disabledParts.Add(randomPart);
                }
             }

             List<GameObject> leftParts = new List<GameObject>();
             foreach (Transform t in level.transform){
                t.GetComponent<Renderer>().material.color = allStages[stageNumber].stageLevelPartColor;
                if (t.gameObject.activeInHierarchy){
                    leftParts.Add(t.gameObject);
                }
             }

             List<GameObject> deathParts = new List<GameObject>();
             while(deathParts.Count<stage.levels[i].deathPartCount){
                GameObject RANDOMpART = leftParts[(Random.Range(0,leftParts.Count))];
                if(!deathParts.Contains(RANDOMpART)){
                    RANDOMpART.gameObject.AddComponent<DeathPart>();
                    deathParts.Add(RANDOMpART);
                }
             }
        }

    }
}
