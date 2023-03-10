using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Calls functionality when a trigger occurs
/// </summary>

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class OnTriggerFriction : MonoBehaviour
{
    [Tooltip("Only the objects with this tag name can trigger this. Can be left blank.")]
    [Serializable] public class TriggerEvent : UnityEvent<Collider> { }


    // When the object enters a collision
    public TriggerEvent OnEnter = new TriggerEvent();
    
    // When the object stays a collision
    public TriggerEvent OnStay = new TriggerEvent();

    // When the object exits a collision
    public TriggerEvent OnExit = new TriggerEvent();

    private OVRHand[] m_hands;

    private Renderer m_renderer;

    /// <summary>
    /// True if an index tip is inside the cube, false otherwise.
    /// First item is left hand, second item is right hand
    /// </summary>
    private bool[] m_isIndexStaying;

    void Start()
    {
        m_renderer = GetComponent<Renderer>();

        m_hands = new OVRHand[]
        {
            GameObject.Find("OVRCameraRig/TrackingSpace/LeftHandAnchor/LeftOVRHand").GetComponent<OVRHand>(),
            GameObject.Find("OVRCameraRig/TrackingSpace/RightHandAnchor/RightOVRHand").GetComponent<OVRHand>()
        };
        m_isIndexStaying = new bool[2] { false, false };

        //we don't want the cube to move over collision, so let's just use a trigger
        GetComponent<Collider>().isTrigger = true;

    }

    void Update()
    {
        //check for middle finger pinch on the left hand, and make che cube red in this case
        if (m_hands[1].GetFingerIsPinching(OVRHand.HandFinger.Middle))
            m_renderer.material.color = Color.red;
        //if no pinch, and the cube was red, make it white again
        else if (m_renderer.material.color == Color.red)
            m_renderer.material.color = Color.white;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name + " has entered the trigger zone");
        int handIdx = GetIndexFingerHandId(collider);

        //if there is an associated hand, it means that an index of one of two hands is entering the cube
        //change the color of the cube accordingly (blue for left hand, green for right one)
        if (handIdx != -1)
        {
            //m_renderer.material.color = handIdx == 0 ? m_renderer.material.color = Color.blue : m_renderer.material.color = Color.green;
            m_isIndexStaying[handIdx] = true;
            OnEnter?.Invoke(collider);
        }

    }

    private void OnTriggerStay(Collider collider)
    {
        Debug.Log(collider.gameObject.name + " has stay the trigger zone");

        int handIdx = GetIndexFingerHandId(collider);

        //if there is an associated hand, it means that an index of one of two hands is entering the cube
        //change the color of the cube accordingly (blue for left hand, green for right one)
        if (handIdx != -1)
        {
            m_renderer.material.color = handIdx == 0 ? m_renderer.material.color = Color.blue : m_renderer.material.color = Color.green;
            OnStay?.Invoke(collider);
        }

    }
    private void OnTriggerExit(Collider collider)
    {
        Debug.Log(collider.gameObject.name + " has exited the trigger zone");

        int handIdx = GetIndexFingerHandId(collider);
 
        //if there is an associated hand, it means that an index of one of two hands is levaing the cube,
        //so set the color of the cube back to white, or to the one of the other hand, if it is in
        if (handIdx != -1)
        {
            m_isIndexStaying[handIdx] = false;
            m_renderer.material.color = m_isIndexStaying[0] ? m_renderer.material.color = Color.blue :
                                        (m_isIndexStaying[1] ? m_renderer.material.color = Color.green : Color.white);
            OnExit?.Invoke(collider);
        }
            
    }

    

    

    private int GetIndexFingerHandId(Collider collider)
    {
        //Checking Oculus code, it is possible to see that physics capsules gameobjects always end with _CapsuleCollider
        if (collider.gameObject.name.Contains("_CapsuleCollider"))
        {
            //get the name of the bone from the name of the gameobject, and convert it to an enum value
            string boneName = collider.gameObject.name.Substring(0, collider.gameObject.name.Length - 16);
            OVRPlugin.BoneId boneId = (OVRPlugin.BoneId)Enum.Parse(typeof(OVRPlugin.BoneId), boneName);

            //if it is the tip of the Index
            if (boneId == OVRPlugin.BoneId.Hand_Index3)
                //check if it is left or right hand, and change color accordingly.
                //Notice that absurdly, we don't have a way to detect the type of the hand
                //so we have to use the hierarchy to detect current hand
                if (collider.transform.IsChildOf(m_hands[0].transform))
                {
                    return 0;
                }
                else if (collider.transform.IsChildOf(m_hands[1].transform))
                {
                    return 1;
                }
        }

        return -1;
    }
}
