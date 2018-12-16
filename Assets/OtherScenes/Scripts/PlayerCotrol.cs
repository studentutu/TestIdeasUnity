using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCotrol : MonoBehaviour {

	// [SerializeField] private Transform child;
	[SerializeField] private Transform wholeObject;
	private Vector3 ForwasDirection;
	[SerializeField] private Camera attackedCma;
	
	void LateUpdate(){

		// this.transform.rotation = attackedCma.transform.rotation;
		var original = transform.position - wholeObject.position ;
		ForwasDirection = wholeObject.position - transform.position;
		attackedCma.transform.position = ForwasDirection.normalized*-60;
		attackedCma.transform.LookAt(this.transform.position);

		ForwasDirection = ForwasDirection.normalized;
		ForwasDirection = Vector3.Cross(ForwasDirection,transform.right);
		Vector3 toForward = transform.position + ForwasDirection;
		// var toTarget = Quaternion.FromToRotation(transform.forward,toPoint);
		// transform.LookAt(toPoint );
		// transform.rotation = Quaternion.Slerp( transform.rotation,transform.rotation*toTarget,Time.deltaTime);
		transform.rotation = Quaternion.FromToRotation(transform.transform.up,original) * transform.transform.rotation;

		float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
		bool crouch = Input.GetKey(KeyCode.C);
		bool jump = Input.GetKeyDown(KeyCode.Space);
		if(Mathf.Abs(ver) < 0.2f && Mathf.Abs(hor) < 0.2f){
			return;
		}

		var vectMove = transform.forward * ver + transform.right * hor;
		// transform.GetComponent<Rigidbody>().AddForce(vectMove);
		transform.position += vectMove * Time.deltaTime *5;
	}

	// [ExecuteInEditMode]
	// void OnDrawGizmos(){
		
	// 	Gizmos.color = Color.red;
		
	// 	ForwasDirection = wholeObject.position - transform.position;
	// 	ForwasDirection = ForwasDirection.normalized;
	// 	ForwasDirection = Vector3.Cross(ForwasDirection,transform.right);
	// 	Vector3 toPoint = transform.position + ForwasDirection*100;
	// 	Gizmos.DrawLine( transform.position, toPoint );

	// 	Gizmos.color = Color.blue;
	// 	Gizmos.DrawLine(transform.position, transform.position + transform.forward*100);

		
		
	// 	transform.LookAt(toPoint );
		
	// 	Gizmos.color = Color.black;
	// 	Gizmos.DrawLine(transform.position, transform.position + transform.forward);
		
	// }

	// void OnValidate(){
	// 	transform.position = CirclePos(wholeObject.position,wholeObject.localScale.x/2,Towards); //wholeObject.position - transform.position
	// 	currRotation = transform.rotation.eulerAngles;
	// }


	private static Vector3 CirclePos(Vector3 center, float radius, int indexer)
    {
        float ang = (360f / 360) * indexer;
        Vector3 pos = new Vector3(0, 0,0);
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
	}
}
