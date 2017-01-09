using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class StoryBookA : MonoBehaviour {

	public Text text;

	public Text buttonA;
	public Text buttonB;
	public Text buttonC;

	private enum States {
		cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, stairs_0, stairs_1,
		stairs_2, courtyard, floor, corridor_1, corridor_2, corridor_3,closet_door, in_closet
	};
	private States myState;

	public string levelToLoad;		// bu kısım tamamlandığında yüklenecek bölüm !!! editör üzerinden yazılmalıdır

	void Start () {
		myState = States.cell;
	}
		
	void Update () {
		print (myState);
		if 		(myState == States.cell) 		{cell();}
		else if (myState == States.sheets_0) 	{sheets_0();}
		else if (myState == States.sheets_1) 	{sheets_1();}
		else if (myState == States.lock_0) 		{lock_0();}
		else if (myState == States.lock_1) 		{lock_1();}
		else if (myState == States.mirror) 		{mirror();}
		else if (myState == States.cell_mirror) {cell_mirror();}
		else if (myState == States.corridor_0) 	{corridor_0();}
//		else if (myState == States.stairs_0) 	{stairs_0();}
//		else if (myState == States.stairs_1) 	{stairs_1();}
//		else if (myState == States.stairs_2) 	{stairs_2();}
//		else if (myState == States.courtyard) 	{courtyard();}
//		else if (myState == States.floor) 		{floor();}
//		else if (myState == States.corridor_1) 	{corridor_1();}
//		else if (myState == States.corridor_2) 	{corridor_2();}
//		else if (myState == States.corridor_3) 	{corridor_3();}
//		else if (myState == States.closet_door) {closet_door();}
//		else if (myState == States.in_closet) 	{in_closet();}
	}

//	void in_closet() {
//		text.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
//			"Seems like your day is looking-up.\n\n" +
//			"Press D to Dress up, or R to Return to the corridor";
//		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.corridor_2;}
//		else if (Input.GetKeyDown(KeyCode.D)) 	{myState = States.corridor_3;}
//	}
//
//	void closet_door() {
//		text.text = "You are looking at a closet door, unfortunately it's locked. " +
//			"Maybe you could find something around to help enourage it open?\n\n" +
//			"Press R to Return to the corridor";
//		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.corridor_0;}
//	}
//
//	void corridor_3() {
//		text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
//			"You strongly consider the run for freedom.\n\n" +
//			"Press S to take the Stairs, or U to Undress";
//		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.courtyard;}
//		else if (Input.GetKeyDown(KeyCode.U))	{myState = States.in_closet;}
//	}
//
//	void corridor_2() {
//		text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
//			"Press C to revisit the Closet, and S to climb the stairs";
//		if 		(Input.GetKeyDown(KeyCode.C)) 	{myState = States.in_closet;}
//		else if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairs_2;}
//	}
//
//	void corridor_1() {
//		text.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
//			"Now what? You wonder if that lock on the closet would succumb to " +
//			"to some lock-picking?\n\n" +
//			"P to Pick the lock, and S to climb the stairs";
//		if (Input.GetKeyDown(KeyCode.P)) 		{myState = States.in_closet;}
//		else if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairs_1;}
//	}
//
//	void floor () {
//		text.text = "Rummagaing around on the dirty floor, you find a hairclip.\n\n" +
//			"Press R to Return to the standing, or H to take the Hairclip." ;
//		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.corridor_0;}
//		else if (Input.GetKeyDown(KeyCode.H)) 	{myState = States.corridor_1;}
//	}	
//
//	void courtyard () {
//		text.text = "You walk through the courtyard dressed as a cleaner. " +
//			"The guard tips his hat at you as you waltz past, claiming " +
//			"your freedom. You heart races as you walk into the sunset.\n\n" +
//			"Press P to Play again." ;
//		if (Input.GetKeyDown(KeyCode.P)) 		{myState = States.cell;}
//	}	
//
//	void stairs_0 () {
//		text.text = "You start walking up the stairs towards the outside light. " +
//			"You realise it's not break time, and you'll be caught immediately. " +
//			"You slither back down the stairs and reconsider.\n\n" +
//			"Press R to Return to the corridor." ;
//		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.corridor_0;}
//	}
//
//	void stairs_1 () {
//		text.text = "Unfortunately weilding a puny hairclip hasn't given you the " +
//			"confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
//			"Press R to Retreat down the stairs" ;
//		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.corridor_1;}
//	}
//
//	void stairs_2() {
//		text.text = "You feel smug for picking the closet door open, and are still armed with " +
//			"a hairclip (now badly bent). Even these achievements together don't give " +
//			"you the courage to climb up the staris to your death!\n\n" +
//			"Press R to Return to the corridor";
//		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.corridor_2;}
//	}

	void cell () {
		text.text = 
			"Eravel giriş kapısına yaklaşıp etrafına bakındı. " +
			"Robotlar sırayla ilerleyip ana kapıdan içeri giriyorlardı. " +
			"Kapının etrafındaki cihazlar, sıranın en önündeki robotu tarayıp bir tür giriş izni veriyor gibiydi. " +
			"Kapı her seferinde yalnızca bir tane robotun geçebileceği kadar açık kalıyor, ardından kapanıyordu. " +
			"Duvarda üzerinde yazılar ve işaretler olan bir tabela asılıydı. " +
			"Yan tarafta ise tahtadan, eski görünümlü bir kapı vardı. ";
		
		buttonA.text = "TABELAYI İNCELE";
		buttonB.text = "ANA KAPIDAN İÇERİ GİR";
		buttonC.text = "TAHTA KAPIDAN İÇERİ GİR";

		if (CrossPlatformInputManager.GetButtonDown("ButtonA"))
			myState = States.sheets_0;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.lock_0;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonC"))
			myState = States.mirror;
	}

	void mirror() {
		text.text = 
			"Tahta kapının ardında tozlu, ufak bir oda vardı. " +
			"Odada pek çok metal kutu, demir parçaları ve değişik aletler bulunuyordu. " +
			"Fakat Eravel'in dikkatini çeken şey, odanın köşesinde çürümeye terk edilmiş robot parçaları oldu. " +
			"Bu parçaları kullanarak kendine robot süsü verebilirdi. ";

		buttonA.text = "ROBOT KILIĞINA GİR";
		buttonB.text = " ";
		buttonC.text = "GERİ DÖN";

		if (CrossPlatformInputManager.GetButtonDown("ButtonA"))
			myState = States.cell_mirror;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonC"))
			myState = States.cell;
	}

	void cell_mirror() {
		text.text = 
			"Eravel robot parçalarını kullanarak kılık değiştirmiş halde girişe geri döndü. " +
			"Tabela halen duvarda asılıydı. " +
			"Robotlar ise ana kapıdan içeri girmeye devam ediyorlardı. ";

		buttonA.text = "TABELAYI İNCELE";
		buttonB.text = " ";
		buttonC.text = "ANA KAPIYA YÖNEL";

		if (CrossPlatformInputManager.GetButtonDown("ButtonA"))
			myState = States.sheets_1;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonC"))
			myState = States.lock_1;
	}

	void sheets_0 () {
		text.text =
			"Duvarda asılı olan şey, bir tür uyarı levhasıydı. " +
			"Eravel üzerinde yazanları okudu: " +
			"\"Benimle işi olanlar robotlarım vasıtasıyla isteklerini iletebilirler. " +
			"Bu kapı sadece robotlarımın kullanımı içindir ve başkaları tarafından kullanılması yasaktır. " +
			"Kapıdaki güvenlik önlemleri robotlarım haricinde kimseye izin vermezler. " +
			" - ROBO-MEKANiK USTASI BUO\"";

		buttonA.text = " ";
		buttonB.text = "GİRİŞE GERİ DÖN";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.cell;
	}

	void sheets_1() {
		text.text =
			"Duvarda asılı olan şey, bir tür uyarı levhasıydı. " +
			"Eravel üzerinde yazanları okudu: " +
			"\"Benimle işi olanlar robotlarım vasıtasıyla isteklerini iletebilirler. " +
			"Bu kapı sadece robotlarımın kullanımı içindir ve başkaları tarafından kullanılması yasaktır. " +
			"Kapıdaki güvenlik önlemleri robotlarım haricinde kimseye izin vermezler. " +
			" - ROBO-MEKANiK USTASI BUO\"";

		buttonA.text = " ";
		buttonB.text = "GİRİŞE GERİ DÖN";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.cell_mirror;
	}

	void lock_0() {
		text.text =
			"Eravel robotların yanından ilerleyip kapının önüne geldi. " +
			"Şansını deneyip kapıyı iteklese de bunun işe yaramayacağını biliyordu. " +
			"O sırada kapının etrafındaki tarama cihazlarından çıkan ışık demetleri gözünü aldı. " +
			"Kırmızı bir ışık yanıp sönmeye başlarken, mekanik bir ses duyuldu: \"GİRİŞ ONAYLANMADI!\". ";

		buttonA.text = " ";
		buttonB.text = "GİRİŞE GERİ DÖN";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.cell;
	}

	void lock_1() {
		text.text = 
			"Eravel, robotlardan oluşan sıranın en arkasına yanaşıp beklemeye koyuldu. " +
			"Sıranın önündeki robotlar kapıdan girdikçe, diğer robotlarla birlikte o da ilerliyordu. " +
			"Robotların sahibi olan Buo'nun, kendisine nasıl bir tepki vereceğini düşünerek endişelenmekteydi. " +
			"\"GİRİŞ ONAYLANDI!\" sesini duyup kendine geldiğinde, önündeki robot da kapıdan geçmekteydi. " +
			"Sıra Eravel'e gelmişti. İlerlemesi gerekiyordu. " ;
		
		buttonA.text = " ";
		buttonB.text = "BİR ADIM İLERLE";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.corridor_0;

	}

	void corridor_0() {
		text.text =
			"Robot parçalarının altında etrafını bile zar zor görebilen Eravel, kapıya ait tarama cihazlarının hemen önündeydi. " +
			"\"GİRİŞ ONAYLANDI!\" " +
			"Kapı açılır açılmaz içeri fırlayan Eravel, robotların oluşturduğu sıradan ayrılıp üzerindeki parçaları bir kenara bıraktı. " +
			"Metal kaplamalı koridorlarda ilerlemeye başlayıp, Buo'yu aramaya koyuldu. ";

		buttonA.text = " ";
		buttonB.text = "BÖLÜMÜ SONLANDIR";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			SceneManager.LoadScene (levelToLoad);

	}
}