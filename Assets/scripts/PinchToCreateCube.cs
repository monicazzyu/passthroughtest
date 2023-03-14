using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PinchToCreateCube : MonoBehaviour
{
    private OVRHand[] m_hands;
    private float x1, y1, z1;

    public GameObject ballPrefab;
    public GameObject IndexBall;
    public int maxBalls = 3;
    
    private List<GameObject> balls = new List<GameObject>();
    private int IndexBallMoveCount = 0;
    private Vector3 prevIndexBallPos;

    
    

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
        {
            if (IndexBall.transform.position != prevIndexBallPos)
            {
                IndexBallMoveCount++;
                prevIndexBallPos = IndexBall.transform.position;

                // If IndexBall moved less than 4 times, create new ball
                if (IndexBallMoveCount < 4)
                {
                    CreateBall(prevIndexBallPos);
                }
                else // Otherwise, delete all balls and create new one
                {
                    DestroyBalls();
                    CreateBall(prevIndexBallPos);
                    IndexBallMoveCount = 0;
                }
            }
        }



        

            
    }

    void CreateBall(Vector3 pos)
    {
        if (balls.Count >= maxBalls)
        {
            Destroy(balls[0]); // Delete oldest ball
            balls.RemoveAt(0);
        }

        GameObject ball = Instantiate(ballPrefab, pos, Quaternion.identity);
        balls.Add(ball);
    }

    void DestroyBalls()
    {
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
        balls.Clear();
    }
}
