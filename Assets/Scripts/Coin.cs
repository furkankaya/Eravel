using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public LevelManager theLevelManager;

    public int coinValue;

	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theLevelManager.AddCoins(coinValue);
            gameObject.SetActive(false); //destroy etmeyip deaktif edersek tekrar aktifleştirileiblir
        }
    }
}
