using UnityEngine;
using System.Collections;

public class SimpleMovePad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var move = Input.GetAxis("Horizontal");
        if (move != 0)
        {
           // rigidbody2D.AddForce(new Vector2(move * 3, 0));
            gameObject.transform.Translate(new Vector3(move * 0.1f, 0, 0));
        }
        var up = Input.GetAxis("Vertical");
        if (up != 0)
        {
            gameObject.transform.Translate(new Vector3(0, up * 0.1f, 0));
        }
	}
}
