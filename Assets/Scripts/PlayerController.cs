using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	private bool movingLeft;
	private bool movingRight;

    public float moveSpeed;
    private float activeMoveSpeed;

    public Rigidbody2D myRigidbody;

    public float jumpSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private bool isGrounded;

    private Animator myAnim;

    public Vector3 respawnPosition;

    public LevelManager theLevelManager;

    public GameObject stompBox;

    public float knockbackForce;
    public float knockbackLenght;
    private float knockbackCounter;

    public float invincibilityLenght;
    private float invincibilityCounter;

    public AudioSource jumpSound;
    public AudioSource hurtSound;

    private bool onPlatform;
    public float onPlatformSpeedModifier;

    public bool canMove;

	bool isRunning;
	float runMultiplier;

	public bool autoRun;

	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        respawnPosition = transform.position;
        theLevelManager = FindObjectOfType<LevelManager>();
        activeMoveSpeed = moveSpeed;
        canMove = true;
	}

	void Update ()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround );



        if(knockbackCounter <= 0 && canMove)
        { 
			// hareketli platform üzerinde aşırı hızlı hareketi engellemek için
            if(onPlatform)
            {
                activeMoveSpeed = moveSpeed * onPlatformSpeedModifier;
            }
            else
            {
                activeMoveSpeed = moveSpeed;
            }



			// Touch joystick x-axis controller v1

//			Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), 0f) * activeMoveSpeed;
//			bool isBoosting = CrossPlatformInputManager.GetButton("Run");
//			myRigidbody.AddForce(moveVec * (isRunning ? runMultiplier : 1));




			// Touch joystick x-axis controller v2

			if( CrossPlatformInputManager.GetAxis("Horizontal") > 0f && CrossPlatformInputManager.GetAxis("Vertical") < 0.65f)
       		{
				if (CrossPlatformInputManager.GetAxis ("Horizontal") < 0.35f)
				{
					activeMoveSpeed /= 2;
				}
	          	myRigidbody.velocity = new Vector3(activeMoveSpeed, myRigidbody.velocity.y, 0f);
	           	transform.localScale = new Vector3(1f,1f,1f);
				myAnim.SetFloat("Speed", Mathf.Abs(CrossPlatformInputManager.GetAxis("Horizontal")));
        	}
			else if (CrossPlatformInputManager.GetAxis ("Horizontal") < 0f && CrossPlatformInputManager.GetAxis("Vertical") < 0.65f)
			{
				if (CrossPlatformInputManager.GetAxis ("Horizontal") > -0.35f)
				{
					activeMoveSpeed /= 2;
				}
	          	myRigidbody.velocity = new Vector3(-activeMoveSpeed, myRigidbody.velocity.y, 0f);
	          	transform.localScale = new Vector3(-1f, 1f, 1f);
				myAnim.SetFloat("Speed", Mathf.Abs(CrossPlatformInputManager.GetAxis("Horizontal")));
    		}
			else
			{
         		myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
				myAnim.SetFloat("Speed", 0f);
          	}

			if(CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
			{
				myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
				jumpSound.Play();
			}

			if (autoRun)
			{
				myRigidbody.velocity = new Vector3(activeMoveSpeed, myRigidbody.velocity.y, 0f);
				myAnim.SetFloat ("Speed", 1); 
			}


//			// PC Controller
//            if( Input.GetAxisRaw ("Horizontal") > 0f)
//            {
//                myRigidbody.velocity = new Vector3(activeMoveSpeed, myRigidbody.velocity.y, 0f);
//                transform.localScale = new Vector3(1f,1f,1f);
//            } else if (Input.GetAxisRaw ("Horizontal") < 0f) {
//                myRigidbody.velocity = new Vector3(-activeMoveSpeed, myRigidbody.velocity.y, 0f);
//                transform.localScale = new Vector3(-1f, 1f, 1f);
//            } else {
//                myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
//            }
//
//            if(Input.GetButtonDown("Jump") && isGrounded) {
//                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
//                jumpSound.Play();
//            }


//			//Two Button Joystick Controller
//
//			movingLeft = CrossPlatformInputManager.GetButton("MoveLeft");
//			movingRight = CrossPlatformInputManager.GetButton("MoveRight");
//
//			if (movingRight)
//			{
//				myRigidbody.velocity = new Vector3 (activeMoveSpeed, myRigidbody.velocity.y, 0f);
//				transform.localScale = new Vector3(1f,1f,1f);
//			}
//			else if (movingLeft)
//			{
//				myRigidbody.velocity = new Vector3 (-activeMoveSpeed, myRigidbody.velocity.y, 0f);
//				transform.localScale = new Vector3(-1f, 1f, 1f);
//			}
//			else
//			{
//				myRigidbody.velocity = new Vector3 (0f, myRigidbody.velocity.y, 0f);
//			}
//
//			if(CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
//			{
//				myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
//				jumpSound.Play();
//			}
        }

        if(invincibilityCounter>0)
        {
            invincibilityCounter -= Time.deltaTime;
        }

        if(invincibilityCounter<=0)
        {
            theLevelManager.invincible = false;
        }

        if(knockbackCounter>0)
        {
            knockbackCounter -= Time.deltaTime;
            if(transform.localScale.x>0)
                myRigidbody.velocity = new Vector3(-knockbackForce, knockbackForce, 0f);
            else
                myRigidbody.velocity = new Vector3(knockbackForce, knockbackForce, 0f);
        }


        myAnim.SetBool("Grounded", isGrounded);

        // stompBox'u sadece oyuncu aşağı yönde gidiyorsa aktif et
        if(myRigidbody.velocity.y < 0)
        {
            stompBox.SetActive(true);
        }
        else
        {
            stompBox.SetActive(false);
        }

    }

    public void Knockback()
    {
        knockbackCounter = knockbackLenght;
        invincibilityCounter = invincibilityLenght;
        theLevelManager.invincible = true;
    }

    void OnTriggerEnter2D (Collider2D other)
    { 
        if(other.tag == "KillPlane")
        {
            //gameObject.SetActive(false);
            //transform.position = respawnPosition;
			Debug.Log("killplane hit");
            theLevelManager.Respawn();
        }

        if(other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
            onPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
            onPlatform = false;
        }
    }


}
