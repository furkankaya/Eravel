using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour
{

	public float lifeTime;

	void Start ()
    {
	
	}
	
	void Update ()
    {
		lifeTime = lifeTime - Time.deltaTime;

		if(lifeTime <= 0f)
		{
			Destroy(gameObject);
		}
	}
}
