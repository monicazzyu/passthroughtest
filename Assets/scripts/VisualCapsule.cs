using UnityEngine;
using UnityEngine.Events;

public class VisualCapsule : MonoBehaviour
{
    public GameObject objectB;
    public GameObject CapsuleShape;
    public UnityEvent PlayAnimation;
    public UnityEvent StopAnimation;
    private AccelerationChecker acceleration;
    private Animation animationComponent;
    
    private void Start()
    {
        acceleration = objectB.GetComponent<AccelerationChecker>();
        animationComponent = CapsuleShape.GetComponent<Animation>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (acceleration.acceleration < 0f )
        {
            PlayAnimation.Invoke();
            //if (animationComponent.time = 0.0f)
            //{
           //     Debug.Log("Animation is playing");
            //    StopAnimation.Invoke();
           // }
            //else{
                //Debug.Log("1");
                //StopAnimation.Invoke();
           // }
            
        } 

    }
}
