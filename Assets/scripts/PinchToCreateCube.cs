using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Oculus;

[RequireComponent(typeof(Collider))]

public class PinchToCreateCube : MonoBehaviour
{
    private OVRHand[] m_hands;
    private Vector3 pinchPosition;
    private GameObject newObject;
    public Transform indexFingerTip;
    
    

    // Start is called before the first frame update
    void Start()
    {
        m_hands = new OVRHand[]
        {
            GameObject.Find("OVRCameraRig/TrackingSpace/LeftHandAnchor/LeftOVRHand").GetComponent<OVRHand>(),
            GameObject.Find("OVRCameraRig/TrackingSpace/RightHandAnchor/RightOVRHand").GetComponent<OVRHand>()
        };

    }

    // Update is called once per frame
    void Update()
    {
        if (m_hands[0].GetFingerIsPinching(OVRHand.HandFinger.Index))
            indexFingerTip = GameObject.Find("hands:b_l_index_ignore").transform;
            GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newObject.transform.position = indexFingerTip.position;
        

            
    }
}
