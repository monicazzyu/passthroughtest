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
public class Pinch : MonoBehaviour
{


    private OVRHand[] m_hands;

    public HandDistance handdistance;

    /// <summary>
    /// True if an index tip is inside the cube, false otherwise.
    /// First item is left hand, second item is right hand
    /// </summary>
  

    void Start()
    {
        handdistance = gameObject.GetComponent<HandDistance>();
    

        m_hands = new OVRHand[]
        {
            GameObject.Find("OVRCameraRig/TrackingSpace/LeftHandAnchor/LeftOVRHand").GetComponent<OVRHand>(),
            GameObject.Find("OVRCameraRig/TrackingSpace/RightHandAnchor/RightOVRHand").GetComponent<OVRHand>()
        };
        

 

    }

    void Update()
    {
        
        if (m_hands[1].GetFingerIsPinching(OVRHand.HandFinger.Index) && m_hands[0].GetFingerIsPinching(OVRHand.HandFinger.Index))
            handdistance.enabled = true;
        else if (handdistance.enabled == true)
            handdistance.enabled = false;
    }

    
}
