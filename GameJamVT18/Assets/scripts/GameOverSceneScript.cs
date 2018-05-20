using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSceneScript : MonoBehaviour {

    public Text promptText;

    private float timer = 3.0f;

	// Use this for initialization
	void Start () {
        promptText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && timer <= 0.0f)
        {
            SceneManager.LoadScene(0);
        }
        if (!(timer <= 0.0f))
        {
            timer -= Time.deltaTime;
        }
        else if (!promptText.enabled)
        {
            promptText.enabled = true;
        }
	}
}
