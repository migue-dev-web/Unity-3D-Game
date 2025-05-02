using UnityEngine;

public class testcolor : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

}
