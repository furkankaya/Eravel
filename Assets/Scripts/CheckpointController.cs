using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {

    public Sprite flagClosed;
    public Sprite flagOpen;

    private SpriteRenderer mySpriteRenderer;

    public bool checkpointActive;

	void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            mySpriteRenderer.sprite = flagOpen;
            checkpointActive = true;
        }
    }
}
