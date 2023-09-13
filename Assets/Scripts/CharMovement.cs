using UnityEngine;
using UnityEngine.SceneManagement;


public class CharMovement : MonoBehaviour
{
   public Animator anim;
    private GameObject character;
    private Rigidbody rb;
    public GameManager gameManager;
    public Transform rayStart;
    public float speed;
    public float maxSpeed;
    public bool turnRotate = true;
    public bool isGrounded;
    

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        if(!gameManager.gameStart)
        {
            return;
        }
        else
        {
            anim.SetTrigger("Running"); 
        }
        speed = Mathf.Min(speed, maxSpeed);
        Vector3 velocity = transform.forward * speed;
        rb.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    public void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Turn();
        }

        if(!IsGrounded())
        {
            anim.SetTrigger("Falling");
        }
        else
        {
            anim.SetTrigger("NotFalling");
        }

        if(transform.position.y < -2)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
    public bool IsGrounded()
    {
        RaycastHit hit;

        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            float distanceGround = hit.distance;
            if (distanceGround < 1f)
            {
                return false;
            }
        }
        return true;
    }
    public void Turn()
    {
        if(!gameManager.gameStart)
        {
            return;
        }

        turnRotate= !turnRotate;
        if(turnRotate)
        {
            transform.rotation = Quaternion.Euler(new Vector3 (0,45,0));
            
        }
        else{
            transform.rotation = Quaternion.Euler(new Vector3 (0,-45,0));
        }
    }
}
