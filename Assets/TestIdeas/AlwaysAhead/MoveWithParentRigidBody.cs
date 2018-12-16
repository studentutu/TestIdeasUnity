using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithParentRigidBody : MonoBehaviour
{
    [SerializeField] private Transform fromParentForwrd;
	[SerializeField] private float initialRadius;  // 4
	
	
    
    // Update is called once per frame
    void Update()
    {

		if( Vector3.Dot(fromParentForwrd.forward,  transform.position -fromParentForwrd.position ) < 0 ||
		    Vector3.Distance(fromParentForwrd.position, transform.position) > (initialRadius+ 0.5f) ){

			transform.position = fromParentForwrd.position;
			transform.rotation = fromParentForwrd.rotation;
		}

		
    }
}
