using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSript : MonoBehaviour {

	
	void OnCollisionEnter(Collision collision)
    {
        // if(once){
            var obj = collision.gameObject.GetComponent<OnUpdaterBlow>();
            if(collision.gameObject.GetComponent<OnUpdaterBlow>() != null){
                if(!obj.blowed ){

                    foreach (ContactPoint contact in collision.contacts)
                    {
                        Debug.DrawRay(contact.point, contact.normal, Color.white);
                    }
                    Debug.Log("Triggered!");

                    obj.blowUpf = true;
                    obj.blowed = true;
                }
            }
        // }
    }
}
