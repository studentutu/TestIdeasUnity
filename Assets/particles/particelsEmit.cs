using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particelsEmit : MonoBehaviour
{

    [SerializeField] private Transform[] allPoint;
    [SerializeField] private ParticleSystem myPartSystem;
	[SerializeField] private Transform pointToGo;

	[SerializeField] private float VelocityStart = 5f;
	int numParticles = 0;
	
	// need to get the equation for remeining lifetime based on the :
	//	- initial position,
	//  - velocity given,
	//  - need to calculate time
	// Event
    public void GenerateFromThere()
    {
		myPartSystem.Stop();
		myPartSystem.Clear();
		myPartSystem.Play();
		numParticles = allPoint.Length;
        myPartSystem.Emit(numParticles);
		ParticleSystem.Particle[] arrayOfPart = new ParticleSystem.Particle[numParticles];
		numParticles = myPartSystem.GetParticles(arrayOfPart);

		Vector3 toGo = pointToGo.position;
		float distance = 0;
		float remTime = 0;

		for (int i = 0; i < arrayOfPart.Length; i++)
		{
			arrayOfPart[i].position = allPoint[i].position;
			arrayOfPart[i].velocity = toGo - arrayOfPart[i].position;

			distance = arrayOfPart[i].velocity.magnitude;

			arrayOfPart[i].velocity = arrayOfPart[i].velocity.normalized * VelocityStart;

			remTime = distance/arrayOfPart[i].velocity.magnitude;

			arrayOfPart[i].remainingLifetime = remTime;
		}
		myPartSystem.SetParticles(arrayOfPart,numParticles);
		Debug.Log(" On Positions");
    }
}
