using UnityEngine;

public class FollowObjectRotation : MonoBehaviour
{
    public Transform TargetObject;
    public float MoveSpeed = 1.0f;
    public float RotationSpeed = 1.0f;
    public bool ShouldFollowRotation = true;
    public GameObject cube;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetObject.position, MoveSpeed * Time.deltaTime);
        Vector3 cubeRotation = cube.transform.rotation.eulerAngles;
        float xRotation = cubeRotation.x;
        float yRotation = cubeRotation.y;
        float zRotation = cubeRotation.z;

        Quaternion target = Quaternion.Euler(xRotation, yRotation, zRotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime*100);

        Debug.Log("Cube rotation values: x=" + xRotation + ", y=" + yRotation + ", z=" + zRotation);
    }
}
