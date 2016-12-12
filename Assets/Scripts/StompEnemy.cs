using UnityEngine;
using System.Collections;

public class StompEnemy : MonoBehaviour {

    public GameObject deathSplosion;
    private Rigidbody2D playerRigidbody;
    public float bounceForce;

	void Start () {
        playerRigidbody = transform.parent.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            Instantiate(deathSplosion, other.transform.position, other.transform.rotation); // patlama animasyonu
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, bounceForce, 0f);
        }
    }
}
