using UnityEngine;

public class HandDistance : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject quad;

    private float handDistance;

    void Update()
    {
        // Calculate the distance between the left and right hand
        handDistance = Vector3.Distance(leftHand.transform.position, rightHand.transform.position);

        // Set the size of the quad based on the hand distance
        quad.transform.localScale = new Vector3(handDistance, quad.transform.localScale.y, handDistance);
    }
}
