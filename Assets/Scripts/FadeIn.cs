using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// bölüm açılışında siyah ekrandan normal bölüme geçiş efekti (geçişin yapılacağı UI Image'a bu script eklenir)
public class FadeIn : MonoBehaviour
{
    public float fadeTime;		// geçişin süresi

    private Image blackScreen;	// hangi resimden oyuna geçiş yapılacağı

	void Start () {
        blackScreen = GetComponent<Image>();
	}
	
	void Update () {
        blackScreen.CrossFadeAlpha(0f, fadeTime, false);

        if(blackScreen.color.a == 0)
        {
            gameObject.SetActive(false);
        }
	}
}
