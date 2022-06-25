using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetTransform;
    private float movementSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = targetTransform.position;

        targetPosition.z = transform.position.z;

        Vector3 vector = targetPosition - transform.position;
        targetPosition = (Vector3)targetTransform.GetComponent<Rigidbody2D>().velocity * 0.5f;
        targetPosition.y *= 0.5f;
        vector += targetPosition;

        transform.Translate(vector * movementSpeed * Time.deltaTime);

        //transform.position = targetPosition;

    }


}
