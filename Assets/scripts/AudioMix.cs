using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMix : MonoBehaviour
{
    public AudioSource audioSource;




    private Vector3 lastPosition;
    public float speed;
    public float roundedSpeed;
    public float Smooth;


    public Transform TriggerPlay;




    // Start is called before the first frame update
    void Start()
    {
        //lastPosition = TriggerPlay.position;




    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //speed = (((TriggerPlay.position - lastPosition).magnitude) / Time.deltaTime * Smooth);
        //roundedSpeed = Mathf.Round(speed * 100) / 100f;
        //audioSource.volume = Mathf.Lerp(0.05f,1f,roundedSpeed);
        //lastPosition = TriggerPlay.position;
        //Debug.Log(audioSource.volume);
    }

    public void SetVolume()
    {
        speed = (((TriggerPlay.position - lastPosition).magnitude) / Time.deltaTime * Smooth);
        roundedSpeed = Mathf.Round(speed * 100) / 100f;
        audioSource.volume = Mathf.Lerp(0.05f, 1f, roundedSpeed);
        lastPosition = TriggerPlay.position;
        //Debug.Log(audioSource.volume);
    }


}