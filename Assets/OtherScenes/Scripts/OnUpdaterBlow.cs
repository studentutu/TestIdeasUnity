using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUpdaterBlow : MonoBehaviour {
	
	[SerializeField] private Transform parent;
	private Rigidbody[] allRigBdoies;
	private BoxCollider[] allBoxes;
	public bool blowUpf = false;
	public bool blowed = false;
	void Awake(){
		Rigidbody temp;
		allRigBdoies = new Rigidbody[parent.childCount];
		allBoxes = new BoxCollider[parent.childCount];
		for (int i = 0; i < parent.childCount; i++)
		{
			temp = parent.GetChild(i).GetComponent<Rigidbody>();
			
			allBoxes[i] = parent.GetChild(i).GetComponent<BoxCollider>();
			allRigBdoies[i] = temp;

		}
		
	}
	void Update(){

		if(!blowUpf)
			return;
		blowUpf = false;
		for (int i = 0; i < allRigBdoies.Length; i++)
		{
			allBoxes[i].enabled = true;
			allRigBdoies[i].constraints = RigidbodyConstraints.None;
		}

	}



	
}
