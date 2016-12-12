using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	public GameObject objectToMove;
	public Transform startPoint;
	public Transform endPoint;
	public float moveSpeed;
	private Vector3 currentTarget;

	void Start () {
		currentTarget = endPoint.position;
	}

	void Update () {
		objectToMove.transform.position = Vector3.MoveTowards (objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

		if (objectToMove.transform.position == endPoint.position)
		{
			currentTarget = startPoint.position;
		}

		if (objectToMove.transform.position == startPoint.position)
		{
			currentTarget = endPoint.position;
		}
			
	}
}
