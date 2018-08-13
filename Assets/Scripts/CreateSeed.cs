using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSeed : MonoBehaviour {

	public GameObject Seed;
	public Button CreateSeedButton;
	// Use this for initialization
	void Start () {
		Canvas myCanvas;
		GameObject myGo;
		myGo = new GameObject();
		myGo.name = "TestCanvas";
		myGo.AddComponent<Canvas>();
		myCanvas = myGo.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        myGo.AddComponent<CanvasScaler>();
        myGo.AddComponent<GraphicRaycaster>();

		Button button1 = Instantiate(CreateSeedButton, new Vector3(300, 0, 200), Quaternion.identity);
		button1.transform.SetParent(myCanvas.transform, false);
		button1.onClick.AddListener(TaskOnClick);

		myGo.AddComponent<InputField>();
		InputField inputField = myGo.GetComponent<InputField>();
		inputField.text = "Enter Seed Here";

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TaskOnClick() {
		Instantiate(Seed, new Vector3(300, 0, 200), Quaternion.identity);

	}
}
 