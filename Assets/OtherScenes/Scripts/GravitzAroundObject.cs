using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class GravitzAroundObject : MonoBehaviour {

	[SerializeField] private List<Rigidbody> Attractors;
	
	const float G = 10f;


	public Rigidbody mainSphere;
	private static GravitzAroundObject _instance;
	void Awake(){
		_instance = this;
		
	}

	void Update ()
	{
		foreach (Rigidbody attractor in Attractors)
		{
			if(attractor.transform.childCount >0){
				var blowScript = attractor.GetComponent<OnUpdaterBlow>();
				if(blowScript != null  && blowScript.blowed){
					var listOfRigChild = attractor.GetComponentsInChildren<Rigidbody>();
					foreach (var item in listOfRigChild)
					{
						Attract(item);
					}
				}
			}
			if (attractor != this)
				Attract(attractor);
		}
	}

	// void OnEnable ()
	// {
	// 	if (Attractors == null)
	// 		Attractors = new List<Attractor>();

	// 	Attractors.Add(this);
	// }

	// void OnDisable ()
	// {
	// 	Attractors.Remove(this);
	// }

	private static void Attract (Rigidbody rbToAttract)
	{
		if(rbToAttract.name.Contains("Cube")){

		}

		Vector3 direction = _instance.mainSphere.position - rbToAttract.position;
		float distance = direction.magnitude;
		// float distance2 = distance - _instance.mainSphere.transform.localScale.x/2;
		
		// distance2 -= rbToAttract.transform.localScale.x/2;
		// distance2 = Mathf.Clamp(distance2,1,30000 );
		
		// if(distance2 <=0.1f ){
		// 	// if(rbToAttract.angularVelocity.magnitude < 0.2f){
		// 		// rbToAttract.angularVelocity = Vector3.Lerp(rbToAttract.angularVelocity,Vector3.zero,1- rbToAttract.angularVelocity.magnitude);
		// 		//  rbToAttract.angularVelocity = Vector3.zero;
		// 	// }
		// 	// if(rbToAttract.velocity.magnitude < 0.2f){
		// 		// rbToAttract.velocity = Vector3.Lerp(rbToAttract.velocity,Vector3.zero,1- rbToAttract.velocity.magnitude);

		// 		// rbToAttract.velocity = Vector3.zero;
		// 	// }
			
		// 	return;
		// }
		Vector3 force = direction.normalized*10 *distance;
		
		// Add stability
		rbToAttract.AddForce(force);
		// rbToAttract.rotation = Quaternion.FromToRotation(rbToAttract.transform.up,direction) * rbToAttract.transform.rotation;
	}

	[ExecuteInEditMode]
	void OnDrawGizmos(){
		_instance = this;
		Gizmos.color = Color.black;
		List<Transform> allPoints = new List<Transform>();
		foreach (Rigidbody attractor in Attractors)
		{
			if(attractor.transform.childCount >0){
				var blowScript = attractor.GetComponent<OnUpdaterBlow>();
				if(blowScript != null  && blowScript.blowed){
					var listOfRigChild = attractor.GetComponentsInChildren<Rigidbody>();
					foreach (var item in listOfRigChild)
					{
						allPoints.Add(item.transform);
						// Gizmos.DrawLine( _instance.mainSphere.position , item.position);

					}
				}
			}
						allPoints.Add(attractor.transform);
			
			// Gizmos.DrawLine( _instance.mainSphere.position , attractor.position);
		}

		for (int i = 0; i < allPoints.Count; i++)
		{
			
			Gizmos.DrawLine( _instance.mainSphere.position, allPoints[i].position );
			
		}
		// Debug.Log("draw");
	}
}
