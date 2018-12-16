using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWithRaycast : MonoBehaviour {

	[SerializeField] private Transform parent;
	[SerializeField] private float radii = 4f;

	
	// Update is called once per frame
	void Update() {
		var x =  Physics.OverlapSphere(parent.position,radii,Physics.AllLayers);
		if(x != null && x.Length > 0){
			Debug.Log(" <Color=Red> Found!</Color>");
		}
	}
}
