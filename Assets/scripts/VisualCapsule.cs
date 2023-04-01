using UnityEngine;
using UnityEngine.Events;

public class VisualCapsule : MonoBehaviour
{
    public GameObject objectB;
    public UnityEvent PlayAnimation;
    public UnityEvent StopAnimation;
    private AccelerationChecker acceleration;
    private Animation animationComponent;
    
    private void Start()
    {
        acceleration = objectB.GetComponent<AccelerationChecker>();
        animationComponent = objectB.GetComponent<Animation>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (acceleration.acceleration < -2f && !animationComponent.isPlaying )
        {
            PlayAnimation.Invoke();
        } 

        else
        { 
            StopAnimation.Invoke();
        }
    }
}
