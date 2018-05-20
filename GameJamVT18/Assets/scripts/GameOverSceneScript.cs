using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSceneScript : MonoBehaviour {

    public Text promptText;

    public static int currentRun = 0;

    private float timer = 3.0f;

	// Use this for initialization
	void Start () {
        promptText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && timer <= 0.0f)
        {
            Debug.Log(currentRun);
            if (currentRun == 0)
            {
                currentRun = 1;
                Debug.Log("paw!");
                SceneManager.LoadScene(0);
            }
            else if (currentRun == 1)
            {
                currentRun = 2;
                Debug.Log("pew!");
                SceneManager.LoadScene(0);
            }
            else if (currentRun == 2)
            {
                currentRun = 0;
                Debug.Log("pow!");
                SceneManager.LoadScene(0);
                //GameController.gameControllerInstance.gridTransform.Rotate(new Vector3(0.0f, 0.0f, 0.1f));
            }
            /*
            else
            {
                currentRun += 1;
            }
            */
            
            //SceneManager.LoadScene(0);
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
