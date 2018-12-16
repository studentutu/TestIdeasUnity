using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Unity;
using BeardedManStudios.Forge.Networking.Generated;
using System.Collections.Generic;
using UnityEngine;

public class Mover : CubeCustomMoveBehavior
{

    [SerializeField] private Transform objectToMove;
    // Update is called once per frame
    void Update()
    {
        if (NetworkManager.Instance == null)
			return;

        if (networkObject == null)
            return;

        if (!networkObject.IsServer)
        {
            objectToMove.position = networkObject.position;
            objectToMove.rotation = networkObject.rotation;
            return;
        }

        

        objectToMove.position += new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),
            0
         ) * Time.deltaTime * 5f;
        objectToMove.Rotate(Vector3.up, 90*Time.deltaTime);

        networkObject.position = objectToMove.position;
        networkObject.rotation = objectToMove.rotation;

    }
}
