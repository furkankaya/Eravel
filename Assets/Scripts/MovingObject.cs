using UnityEngine;
using System.Collections;

// bu script'in bağlandığı cisim, verilen iki nokta arasında gidip gelir (uçan platformlar vs.)
// noktalar yatay olmak zorunda değil
public class MovingObject : MonoBehaviour {

	public GameObject objectToMove;			// hareket ettirilecek nesne
	public Transform startPoint;			// birinci nokta
	public Transform endPoint;				// ikinci nokta
	public float moveSpeed;					// hareket hızı
	private Vector3 currentTarget;			// anlık hedefi tutan değişken

	void Start () {
		// başlangıçta gidilecek hedefi endPoint olarak belirle
		currentTarget = endPoint.position;
	}

	void Update ()
	{
		// hareket ettirilecek nesnenin pozisyonunu zamana bağlı olarak değiştir  !! MoveTowards fonksiyonuna dikkat
		objectToMove.transform.position = Vector3.MoveTowards (objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

		// hedefe varıldığında hedefi diğer nokta olarak değiştir
		if (objectToMove.transform.position == endPoint.position)
		{
			currentTarget = startPoint.position;
		}

		// hedefe varıldığında hedefi diğer nokta olarak değiştir
		if (objectToMove.transform.position == startPoint.position)
		{
			currentTarget = endPoint.position;
		}
			
	}
}
