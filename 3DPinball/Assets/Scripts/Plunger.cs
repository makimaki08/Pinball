using UnityEngine;
using System.Collections;

public class Plunger : MonoBehaviour {
	
	public float pullPower;
	public KeyCode keyCode = KeyCode.Slash;
	
	private Vector3 startPos;
	private Vector3 pullPosMax;
	private Vector3 touchPos;

	private Rigidbody _rigidbody;
	
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
		startPos = transform.position;
		pullPosMax = transform.position + new Vector3(0, 0, -pullPower);
	}
	
	void Update () {
		if (Application.platform == RuntimePlatform.IPhonePlayer
			|| Application.platform == RuntimePlatform.Android ) {

			// smart phone
			float z = 0;
			if (Input.GetMouseButtonDown(0)) {
				_rigidbody.isKinematic = true;
				touchPos = Input.mousePosition;
			} else if (Input.GetMouseButton(0)) {
				z = (touchPos.y - Input.mousePosition.y) * 0.1f;
				z = Mathf.Max(z, 0);
				z = Mathf.Min(z, pullPower);
				_rigidbody.MovePosition(startPos + new Vector3(0, 0, -z));
			} else {
				touchPos = Vector3.zero;
				_rigidbody.isKinematic = false;
			}
		} else {
			
			// othre
			if (Input.GetKey(keyCode)) {
				_rigidbody.isKinematic = true;
				_rigidbody.MovePosition(pullPosMax);
			} else {
				_rigidbody.isKinematic = false;
			}
		}
	}
}
