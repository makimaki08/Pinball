using UnityEngine;
using System.Collections;

public class BallSpeed : MonoBehaviour {
	
	public float maxVelocity = 30f;

	private float maxSqrVelocity;

	private Rigidbody _rigidbody;
	
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
		maxSqrVelocity = maxVelocity * maxVelocity;
	}
	
	void FixedUpdate () {
		if (_rigidbody.velocity.sqrMagnitude > maxSqrVelocity) {
			_rigidbody.velocity = _rigidbody.velocity.normalized * maxVelocity;
		}
	}
}
