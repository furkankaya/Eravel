using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public bool bossActive;

    public float timeBetweenDrops;
    private float dropCount;

    public float waitForPlatforms;
    private float platformCount;

    public Transform leftPoint;
    public Transform rightPoint;
    public Transform dropSawSpawnPoint;

    public GameObject dropSaw;

    public GameObject theBoss;

    public bool bossRight;

    public GameObject rightPlatforms;
    public GameObject leftPlatforms;

	void Start ()
    {
        dropCount = timeBetweenDrops;
        platformCount = waitForPlatforms;

        theBoss.transform.position = rightPoint.position;
        bossRight = true;
	}
	
	void Update ()
    {
	    if(bossActive)
        {
            theBoss.SetActive(true);

            if(dropCount > 0)
            {
                dropCount -= Time.deltaTime;
            }
            else
            {
                dropSawSpawnPoint.position = new Vector3(Random.Range(leftPoint.position.x, rightPoint.position.x), dropSawSpawnPoint.position.y, dropSawSpawnPoint.position.z);
                Instantiate(dropSaw, dropSawSpawnPoint.position, dropSawSpawnPoint.rotation);
                dropCount = timeBetweenDrops;
            }

            if(bossRight)
            {
                if(platformCount > 0)
                {
                    platformCount -= Time.deltaTime;
                }
                else
                {
                    rightPlatforms.SetActive(true);
                }
            }
            else
            {
                if (platformCount > 0)
                {
                    platformCount -= Time.deltaTime;
                }
                else
                {
                    leftPlatforms.SetActive(true);
                }
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            bossActive = true;
        }
    }
}
