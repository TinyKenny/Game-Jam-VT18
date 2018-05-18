using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController gameControllerInstance;

    private float score;

	// Use this for initialization
	void Start () {
        gameControllerInstance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
