using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class CutsceneController : MonoBehaviour {

	public Image imageContainer;	// resimlerin gösterileceği UI elemanı !!! editör üzerinden atanır
	public Text textContainer;		// altyazıların gösterileceği UI elemanı !!! editör üzerinden atanır

	public Sprite[] images;			// gösterilecek resimleri tutan dizi !!! boyutu ve içeriği editör üzerinden ayarlanır
	public string[] texts;			// gösterilecek altyazıları tutan dizi !!! boyutu ve içeriği editör üzerinden ayarlanır

	private int counter;			// kaç ekran daha kaldığını tutan sayaç

	public Sprite okSprite;			// son ekranda butonun gözükeceği durum

	public GameObject nextButton;	// son sahnede görünümü değiştirilecek olan next butonu !!! editörden ata

	public string levelToLoad;		// bitince yüklenecek bölüm !!! editörde yaz

	void Start ()
	{
		imageContainer.sprite = images[0];
		textContainer.text = texts[0];
		counter = 1;
	}

	void Update ()
	{
		if (counter == images.Length)
		{
			nextButton.GetComponent<Image>().sprite = okSprite;
		}

		if(CrossPlatformInputManager.GetButtonDown("Next"))
		{
			if (counter == images.Length) {
				SceneManager.LoadScene (levelToLoad);
			}
			else
			{
				imageContainer.sprite = images [counter];
				textContainer.text = texts[counter];
				counter = counter+1;
			}
				
		}
	}
}