using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour
{

    public int healtToGive;

    private LevelManager theLevelManager;

    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        theLevelManager.GiveHealth(healtToGive);
        gameObject.SetActive(false);
    }
}