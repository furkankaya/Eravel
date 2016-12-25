 using UnityEngine;
using System.Collections;

// bağlandığı nesne, kamera görüş açısına girdiği anda sola doğru ilerlemeye başlar (saldıran düşmanlar vs.)
public class MoveController02 : MonoBehaviour
{

    public float moveSpeed;		// hareket hızı
    private bool canMove;		// ekrana girip girmediğine göre hareket edebilirlik durumu

    private Rigidbody2D myRigidbody;

	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
	}

    // nesne kamera görüş açısındaysa sola -x yönde hareket eder
	void Update ()
    {
	    if(canMove)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
        }
	}

    // kamera görüş açısına girdiğinde hareket edebilir olmasını sağlar
    void OnBecameVisible()
    {
        canMove = true;
    }

    // hareket eden nesnenin KillPlane'e değerse deaktif edilmesini sağlar
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        // respawn sonrası enable edilen nesnenin, hareket için yine ekrana girmeyi beklemesini sağlar
        canMove = false;
    }

}
