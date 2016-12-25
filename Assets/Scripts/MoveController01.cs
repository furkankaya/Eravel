using UnityEngine;
using System.Collections;

// bağlandığı nesneyi, karakterin leftPoint ve rightPoint child'ları arasında hareket ettirir (örnek: arı, yarasa vs.)
// uçanlar için Y ekseni kilitlenmelidir
// !!!!! nesnenin leftPoint ve rightPoint'i child olarak tanımlanmalıdır !!!!!
public class MoveController01 : MonoBehaviour {

	public Transform leftPoint;			// aralarında gidip geleceği yatay iki nokta
    public Transform rightPoint;

	public float moveSpeed;				// hareket hızı

    private Rigidbody2D myRigidbody;

	private bool movingRight;			// gidilen yön

    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        // sağa giderken sağ sınır noktasını geçerse, sola dön
        if(movingRight && transform.position.x > rightPoint.position.x)
        {
            movingRight = false;
			//görünümü de döndür
            transform.localScale = new Vector3(1f, 1f, 1f);    
        }
        // sola giderken sol sınır noktasını geçerse, sağa dön
        if(!movingRight && transform.position.x < leftPoint.position.x)
        {
            movingRight = true;
			//görünümü de döndür
            transform.localScale = new Vector3(-1f, 1f, 1f);     
        }
        // sağa giderken sınırlar içindeyse hızı belirle
        if(movingRight)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
        }
        // sola giderken sınırlar içindeyse hızı belirle
        if(!movingRight)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
        }
	
	}
}
