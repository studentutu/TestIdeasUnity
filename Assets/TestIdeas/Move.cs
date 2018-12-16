using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedRotation = 10f;

    [SerializeField] private Rigidbody muRb;


    // Update is called once per frame
    void Update()
    {
        float forwardBackward = Input.GetAxis("Vertical") * speed;
        float leftRigth = Input.GetAxis("Horizontal") * speed;

        if (Input.GetMouseButton(1))
        {

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
			muRb.MoveRotation(Quaternion.Euler(new Vector3(0, mousePos.x, 0)));
		}

        Vector3 newPos = transform.position;

        newPos += transform.forward * forwardBackward;
        newPos += transform.right * leftRigth;
        newPos = new Vector3(newPos.x, 5, newPos.z);

        muRb.MovePosition(newPos);

        if (Input.GetKey(KeyCode.E))
        {
            Quaternion some = transform.rotation;
            // Rotate Right
            some = transform.rotation;
            some *= Quaternion.AngleAxis(speedRotation * Time.deltaTime, transform.up);
            muRb.MoveRotation(some);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Quaternion some = transform.rotation;
            // Rotate Left
            some = transform.rotation;
            some *= Quaternion.AngleAxis(-speedRotation * Time.deltaTime, transform.up);
            muRb.MoveRotation(some);
        }


    }
}
