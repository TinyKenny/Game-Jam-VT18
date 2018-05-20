using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController gameControllerInstance;
    private static float rotation = 0.0f;
    public Transform gridTransform;


	// Use this for initialization
	void Start () {
        gameControllerInstance = this;
        if (GameOverSceneScript.currentRun == 2)
        {
            rotation += 90.0f;
            GameOverSceneScript.currentRun = 0;
        }
        gridTransform.Rotate(new Vector3(0.0f, 0.0f, rotation));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
