using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Calls functionality when a trigger occurs
/// </summary>

//[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Pinch2 : MonoBehaviour
{


    private OVRHand[] m_hands;

    public HandDistanceCapsule handdistance3;

    /// <summary>
    /// True if an index tip is inside the cube, false otherwise.
    /// First item is left hand, second item is right hand
    /// </summary>


    void Start()
    {
        handdistance3 = gameObject.GetComponent<HandDistanceCapsule>();


        m_hands = new OVRHand[]
        {
            GameObject.Find("OVRCameraRig/TrackingSpace/LeftHandAnchor/LeftOVRHand").GetComponent<OVRHand>(),
            GameObject.Find("OVRCameraRig/TrackingSpace/RightHandAnchor/RightOVRHand").GetComponent<OVRHand>()
        };
        

 

    }

    void Update()
    {

        if (m_hands[1].GetFingerIsPinching(OVRHand.HandFinger.Index) && m_hands[0].GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            handdistance3.enabled = true;
        }

        else if (handdistance3.enabled == true)
            handdistance3.enabled = false;

    }

    
}
