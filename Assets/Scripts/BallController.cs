using UnityEngine;

public class BallController : MonoBehaviour
{
 public Rigidbody rb;
    public float impulseForce = 3f;

    private bool ignoreNextCollision;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {

        
        if (ignoreNextCollision){
            return;
        }
        DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
        NextLVL nextl = collision.transform.GetComponent<NextLVL>();

        if (nextl){
            GameManager.singleton.NextLevel();
            Debug.Log("nxt");
        }
        if (deathPart){
            GameManager.singleton.restartLevel();
            Debug.Log("ci");
        }
        
        
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(Vector3.up*impulseForce,ForceMode.Impulse);
        ignoreNextCollision =true;
        Invoke("AllowNextCollition", 0.2f);
    }
    

    private void AllowNextCollition(){
        ignoreNextCollision = false;
    }

    public void resetBall(){
        transform.position = startPosition;
    }


}
