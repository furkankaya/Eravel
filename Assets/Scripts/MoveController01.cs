using UnityEngine;
using System.Collections;

// bağlandığı nesneyi, karakterin leftPoint ve rightPoint child'ları arasında hareket ettirir (örnek: arı, yarasa vs.) ?uçanlarda denendi, yerde de işe yarar mı kontrol et
// !!!!! nesnenin leftPoint ve rightPoint'i child olarak tanımlanmalıdır !!!!!
public class MoveController01 : MonoBehaviour {

    public Transform leftPoint;
    public Transform rightPoint;

    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    private bool movingRight;

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
            transform.localScale = new Vector3(1f, 1f, 1f);    //görünümü de döndür
        }
        // sola giderken sol sınır noktasını geçerse, sağa dön
        if(!movingRight && transform.position.x < leftPoint.position.x)
        {
            movingRight = true;
            transform.localScale = new Vector3(-1f, 1f, 1f);     //görünümü de döndür
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
