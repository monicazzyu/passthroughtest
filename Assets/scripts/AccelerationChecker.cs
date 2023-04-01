using UnityEngine;
using UnityEngine.Events;

public class AccelerationChecker : MonoBehaviour
{
    public UnityEvent onNegativeAcceleration;

    public Rigidbody rb;
    public float currentVelocity;
    public float lastVelocity;
    public float acceleration;
    public Vector3 myVector;
    public int A;
    public AudioSource audioSource;
    public AudioClip soundEffect;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        myVector = rb.velocity;
        currentVelocity = rb.velocity.magnitude;
        acceleration = (currentVelocity - lastVelocity) / Time.fixedDeltaTime;
        lastVelocity = currentVelocity;

        if (acceleration < -2f && !audioSource.isPlaying)
        {
            onNegativeAcceleration.Invoke();
            A = 1;
            //capsule.PlayOneShot(soundEffect);
        } 
        else
        { 
            A = 0;
        }
    }
}

