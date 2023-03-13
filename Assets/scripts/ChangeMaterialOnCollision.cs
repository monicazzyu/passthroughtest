using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterialOnCollision : MonoBehaviour
{
    public Material SelectedMaterial;
    public Material UnselectedMaterial;
    private OVRHand[] m_hands;
    private Renderer objectRenderer;
    private bool[] m_isIndexStaying;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        m_hands = new OVRHand[]
       {
            GameObject.Find("OVRCameraRig/TrackingSpace/LeftHandAnchor/LeftOVRHand").GetComponent<OVRHand>(),
            GameObject.Find("OVRCameraRig/TrackingSpace/RightHandAnchor/RightOVRHand").GetComponent<OVRHand>()
       };
        m_isIndexStaying = new bool[2] { false, false };

        //we don't want the cube to move over collision, so let's just use a trigger
        GetComponent<Collider>().isTrigger = true;
    }



    private void OnTriggerEnter(Collider collider)
    {
        //get hand associated with trigger
        int handIdx = GetIndexFingerHandId(collider);

        //if there is an associated hand, it means that an index of one of two hands is entering the cube
        //change the color of the cube accordingly (blue for left hand, green for right one)
        if (handIdx != -1)
        {
            objectRenderer.material = SelectedMaterial;
        }
    }

    /// <summary>
    /// Trigger Exit.
    /// Notice that this gameobject must have a trigger collider
    /// </summary>
    /// <param name="collider">Collider of interest</param>
    private void OnTriggerExit(Collider collider)
    {
        //get hand associated with trigger
        int handIdx = GetIndexFingerHandId(collider);

        //if there is an associated hand, it means that an index of one of two hands is levaing the cube,
        //so set the color of the cube back to white, or to the one of the other hand, if it is in
        if (handIdx != -1)
        {
            objectRenderer.material = UnselectedMaterial;
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
