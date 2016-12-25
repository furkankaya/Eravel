using UnityEngine;
using System.Collections;

// oyuncu respawn olduğunda pozisyonunun resetlenmesi istenen nesnelere bu script bağlanır (düşmanlar, toplanabilir cisimler vs.)
// nesnenin rigidbody'si varsa hızını direkt sıfırlar (kameraya girdiğinde koşan düşmanların hızını sıfırlama vs.)
public class ResetOnRespawn : MonoBehaviour {

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 startLocalScale;

    private Rigidbody2D myRigidbody;

	void Start () {

		// nesnenin başlangıçtaki pos, rot, scale değerlerini sakla
        startPosition = transform.position;
        startRotation = transform.rotation;
        startLocalScale = transform.localScale;

		// nesnenin Rigidbody2D'si varsa eriş (daha sonra hızını sıfırlamak için)
        if(GetComponent<Rigidbody2D>() != null)
        { 
            myRigidbody = GetComponent<Rigidbody2D>();
        }
    }
	
	void Update () {
	
	}

	// bu fonksiyon çağrıldığında nesnenin pos, rot, scale değerlerini ilk baştakine döndürür. Rigidbody2D'si varsa hızını da sıfırlar.
    public void ResetObject()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.localScale = startLocalScale;

        if(myRigidbody != null)
        {
            myRigidbody.velocity = Vector3.zero;
        }
    }
}
