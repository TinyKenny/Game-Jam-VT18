using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController gameControllerInstance;
    public Transform gridTransform;


	// Use this for initialization
	void Start () {
        gameControllerInstance = this;
        if (GameOverSceneScript.currentRun == 0)
        {
            gridTransform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
