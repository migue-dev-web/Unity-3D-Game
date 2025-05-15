using System.Collections.Generic;
using System.Linq.Expressions;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 LastTapPosition;
    private Vector3 startRotation;
    public float speed = 0.1f;

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
        foreach (GameObject go in spawnedLevesl){
            Destroy(go);

        }
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
