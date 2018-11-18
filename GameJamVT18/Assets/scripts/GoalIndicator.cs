using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalIndicator : MonoBehaviour {

    public Transform player;
    public Transform goal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null && goal != null)
        {
            transform.position = Vector3.MoveTowards(player.position, goal.position, 3.0f);

            /*
            Debug.Log(Vector2.Angle(player.position, goal.position));
            Debug.DrawLine(player.position, goal.position);
            */

            Vector3 targ = new Vector3(goal.position.x, goal.position.y, 0.0f);

            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
	}
}
