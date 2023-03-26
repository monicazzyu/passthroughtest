using UnityEngine;

public class HandDistanceSquare : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject quad;

    private float handDistanceX;
    private float handDistanceY;

    void Update()
    {
        // Calculate the distance between the left and right hand
        handDistanceX = Mathf.Abs(leftHand.transform.position.x - rightHand.transform.position.x);
        handDistanceY = Mathf.Abs(leftHand.transform.position.y - rightHand.transform.position.y);

        // Set the size of the quad based on the hand distance
        quad.transform.localScale = new Vector3(handDistanceX, handDistanceY, quad.transform.localScale.z);
    }
}
