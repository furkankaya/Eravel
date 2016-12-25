using UnityEngine;
using System.Collections;

// player karakterin altında, düşmanların üstüne sıçradığında bunu algılayan stompbox'un çalışmasını sağlar
public class StompEnemy : MonoBehaviour {

    public GameObject deathSplosion;		// yok edilen düşmanların oynatacağı efekt
    private Rigidbody2D playerRigidbody;	// oyuncuya kuvvet uygulayabilmek için rigidbody'e referans olacak değişken
    public float bounceForce;				// düşmanlara hamle sonrası geri sekme kuvvetin büyüklüğü

	void Start ()
	{
        playerRigidbody = transform.parent.GetComponent<Rigidbody2D>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.SetActive(false);														// düşmanı yok et
            Instantiate(deathSplosion, other.transform.position, other.transform.rotation); 		// düşmanın yok olduğu yerde efekt oynatılması
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, bounceForce, 0f);	// düşmana hamle yapınca geri sekme
        }

		if (other.tag == "Boss")
		{
			playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, bounceForce, 0f);	// boss'a hamle yapınca geri sekme
			other.transform.parent.GetComponent<Boss>().takeDamage = true;							// boss'u zarar alma moduna sok (işlem Boss script'inde)
		}

    }
}
