using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BallController : MonoBehaviour
{
 public Rigidbody rb;
    public float impulseForce = 3f;

    private bool ignoreNextCollision;

    private Vector3 startPosition;

    public int perfectPass;
    
    public float superSpeed = 8;

    private bool isSuperSpeedActive;

    private int perfectPassCount = 3;

    private void Start()
    {
        startPosition = transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {

        
        if (ignoreNextCollision){
            return;
        }

        if (isSuperSpeedActive && !collision.transform.GetComponent<NextLVL>() && !collision.transform.GetComponent<EmptyScript>() )
        {
            Destroy(collision.transform.parent.gameObject, 0.2f);

        }else{
             DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
             if (deathPart){
            GameManager.singleton.restartLevel();
            Debug.Log("ci");
        }
        }

       
        NextLVL nextl = collision.transform.GetComponent<NextLVL>();

        if (nextl){
            GameManager.singleton.NextLevel();
            Debug.Log("nxt");
        }
        perfectPass = 0;
        isSuperSpeedActive=false;
        
        
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(Vector3.up*impulseForce,ForceMode.Impulse);
        ignoreNextCollision =true;
        Invoke("AllowNextCollition", 0.2f);
    }
    
    private void Update()
    {
        if (perfectPass>=perfectPassCount && !isSuperSpeedActive )
        {
            isSuperSpeedActive = true;
            rb.AddForce(Vector3.down*superSpeed,ForceMode.Impulse);
        }

    }

    private void AllowNextCollition(){
        ignoreNextCollision = false;
    }

    public void resetBall(){
        transform.position = startPosition;
    }


}
