using UnityEngine;
using System.Collections;


public class Flipper : MonoBehaviour
{
	public float pressPos = 45f;
	public float power = 10F;
	public KeyCode keyCode;
	
	private bool isFlipup;

	private HingeJoint _hingeJoint;
	
	void Start() {
		isFlipup = false;
		_hingeJoint = GetComponent<HingeJoint> ();
		_hingeJoint.useSpring = true;
		JointSpring js = _hingeJoint.spring;
		js.spring = power;
		js.damper = 0;
		_hingeJoint.spring = js;
	}
	
	void Update () {
		JointSpring js = _hingeJoint.spring;
		if (Input.GetKey(keyCode) || isFlipup) {
			js.targetPosition = pressPos;
		} else {
			js.targetPosition = 0;
		}
		_hingeJoint.spring = js;
	}
		
	public void FlipperUp() {
		isFlipup = true;
	}
	public void FlipperDown() {
		isFlipup = false;
	}
}
