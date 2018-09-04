﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour {

	[HideInInspector] public Seed seed;
	[HideInInspector] public Canvas myCanvas;
	public Button CreateSeedButton;
	public InputField SeedInputField;

	// Use this for initialization
	void Start () {
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
		button1.onClick.AddListener(CreateSeed);

		GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
		var groundCollider = ground.AddComponent<BoxCollider>();
		groundCollider.isTrigger = true;
		//groundCollider.center = new Vector3(400, -90, 35);
		ground.transform.position = new Vector3(400, -90, 35);
		ground.transform.localScale = new Vector3(80, 80, 80);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void CreateSeed(){
		seed = ScriptableObject.CreateInstance<Seed>();
		seed.seedSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		seed.seedSphere.AddComponent(Type.GetType("SeedActions"));
		var seedSphereCollider = seed.seedSphere.AddComponent<BoxCollider>();
		var seedSphereRigidBody = seed.seedSphere.AddComponent<Rigidbody>();
		seedSphereRigidBody.useGravity = false;
		//seedSphereCollider.center = new Vector3(0, 0, 200);
		seed.seedSphere.transform.position = new Vector3(300, 0, 200);
		seed.seedSphere.transform.localScale = new Vector3(20F, 20F, 20F);
		seed.ideaInputField = Instantiate(SeedInputField, new Vector3(100, 0, 200), Quaternion.identity);
		seed.ideaInputField.transform.SetParent(myCanvas.transform, false);
		seed.ideaInputField.onEndEdit.AddListener(delegate {PrintInput(seed.ideaInputField);});

		
	}

	void PrintInput(InputField input){
		
		seed.idea = input.text;
		Debug.Log(seed.idea);
		GameObject ObjFind = GameObject.Find ("SeedInputField(Clone)");
		ObjFind.SetActive(false);
	}

}
 