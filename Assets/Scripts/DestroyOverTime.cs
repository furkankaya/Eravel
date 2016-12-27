using UnityEngine;
using System.Collections;

// bu script'e sahip nesneler lifeTime sonunda yok edilir (tepeden düşen düşmanların ekrandan çıkınca yok edilmesi vs.)
public class DestroyOverTime : MonoBehaviour
{
	public float lifeTime;

	void Update ()
    {
		lifeTime = lifeTime - Time.deltaTime;

		if(lifeTime <= 0f)
		{
			Destroy(gameObject);
		}
	}
}