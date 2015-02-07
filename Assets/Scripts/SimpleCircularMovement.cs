using UnityEngine;
using System.Collections;

public class SimpleCircularMovement : MonoBehaviour {

    public Vector2 CenterPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 towards = (CenterPoint - new Vector2(transform.position.x, transform.position.y)).normalized;

        print("Towards: " + towards);
        var move = Input.GetAxis("P1_" + "Horizontal");
        if (move != 0)
        {
            transform.Translate(new Vector3(move *  0.1f, 0));
        }
        var angle = Mathf.Atan2(towards.y, towards.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        var distVector = CenterPoint - new Vector2(transform.position.x, transform.position.y);
        if (distVector.magnitude != 4)
        {
            var vect = distVector.normalized * 4;
            transform.Translate(new Vector3(distVector.x - vect.x, distVector.y - vect.y));
        }
	}
}
