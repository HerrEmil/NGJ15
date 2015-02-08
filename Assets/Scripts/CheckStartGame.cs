using UnityEngine;
using System.Collections;

public class CheckStartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetButton("P1_Fire") || Input.GetKey("up")) &&
            (Input.GetButton("P2_Fire") || Input.GetKey("w")) &&
            (Input.GetButton("P3_Fire") || Input.GetKey("b")) &&
            (Input.GetButton("P4_Fire") || Input.GetKey("o")))
        {
            Application.LoadLevel("Level 1");
        }
	}
}
