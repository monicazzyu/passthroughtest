using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionOff : MonoBehaviour
{
    public AudioSource Friction;
    public float fadeOutTime = 2f;

    private float initialVolume;

    public AudioMix audiomix;

    void Start()
    {
        // Store the initial volume of the audio source
        initialVolume = Friction.volume;
        audiomix = gameObject.GetComponent<AudioMix>();
    }

    public void TurnOffFriction()
    {

        // Gradually decrease the volume of the audio source over time
        float newVolume = Mathf.MoveTowards(Friction.volume, 0f, initialVolume / fadeOutTime * Time.deltaTime);
        Friction.volume = newVolume;
        if (newVolume == 0f)
        {
            Friction.Stop();
        }
        //Friction.Pause();

        //audiomix.enabled = false;
    }

}
