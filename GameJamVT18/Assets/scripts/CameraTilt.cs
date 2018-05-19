using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTilt : MonoBehaviour {

    public CinemachineVirtualCamera cm;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            cm.m_Lens.Dutch = -90.0f;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            cm.m_Lens.Dutch = 0.0f;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            cm.m_Lens.Dutch = 90.0f;
        }
    }
}
