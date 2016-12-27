using UnityEngine;
using System.Collections;

// kameranın oyuncuyu takibini sağlar ve düzenler
public class CameraController : MonoBehaviour {

    public GameObject target;
    public float followAhead;

    private Vector3 targetPosition;

    public float smoothing;

    public bool followTarget;

	void Start ()
	{
        followTarget = true;
	}
	
	void Update ()
	{

        if(followTarget)
        { 
            targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            //moves target of the camera ahead of the player
            if(target.transform.localScale.x > 0f)  //facing right
            {
                targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
            }
			else                                  //facing left
            {
                targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
            }

            //transform.position = targetPosition;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}
