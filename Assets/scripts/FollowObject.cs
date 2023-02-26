using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow; // reference to the object to follow
    public Vector3 offset; // the offset between the two objects
    public float multiplier = 10.0f; // the multiplier to apply to the distance that Object A moves

    private Vector3 lastPosition; // remember last position of the objectToFollow

    void Start()
    {
        lastPosition = objectToFollow.transform.position;
    }

    void Update()
    {
        Vector3 displacement = objectToFollow.transform.position - lastPosition;
        lastPosition = objectToFollow.transform.position;
        transform.position += (displacement * multiplier) + offset; // update position to match the object to follow, with an offset and multiplier
    }
}
