// This is an Example Script on how to manage the distances between fingers
using UnityEngine;

public class FingerDistanceManager : MonoBehaviour
{
    // This is just an example and can be done in lot of different way
    // And also you can add all the cases you want inside here
    public enum WhichFingerToCalculate
    {
        ThumbAndIndex,
        IndexAndMiddle,
        IndexAndRing,
        ThumbAndPinky
    }

    // This will appear in the inspector so you can choose whic fingers to calculate the distance
    public WhichFingerToCalculate whichFingerToCalculate;

    [Header("Tip Thumb Finger")]
    [SerializeField]
    // Put the tip of the thumb finger here
    Transform thumbTipFinger = null;

    [Header("Tip Index Finger")]
    [SerializeField]
    // Put the tip of the index finger here
    Transform indexTipFinger = null;

    [Header("Tip Middle Finger")]
    [SerializeField]
    // Put the tip of the middle finger here
    Transform middleTipFinger = null;

    [Header("Tip Ring Finger")]
    [SerializeField]
    // Put the tip of the ring finger here
    Transform ringTipFinger = null;

    [Header("Tip Pinky Finger")]
    [SerializeField]
    // Put the tip of the pinky finger here
    Transform pinkyTipFinger = null;

    // This is a random value i put, you should adjust it
    public float threshold = 0.3f;

    // This bool can be also public, and you can use it to make some event happen
    bool tipsAreNear = false;

    private void Update()
    {
        // With this switch case, in base at the selection i set in the inspector i will choose
        // the case where i want to calculate the distance
        switch (whichFingerToCalculate)
        {
            case WhichFingerToCalculate.IndexAndMiddle:
                if (indexTipFinger != null)
                {
                    // This is how i calculate the distance between two "gameObject.transform.position"  and it will return a float value
                    float distance = Vector3.Distance(indexTipFinger.position, middleTipFinger.position);
                    Debug.Log($"This is the distance between index and middle fingers: {distance}");

                    // Instead here i set an example on how to use that distance you return;
                    if (distance <= threshold)
                    {
                        tipsAreNear = true;
                        Debug.Log("Finger are near each other! Congratulation!");
                    }
                }
                break;

            case WhichFingerToCalculate.IndexAndRing:
                if (indexTipFinger != null)
                {
                    float distance = Vector3.Distance(indexTipFinger.position, ringTipFinger.position);
                    Debug.Log($"This is the distance between index and ring fingers: {distance}");

                    if (distance <= threshold)
                    {
                        tipsAreNear = true;
                        Debug.Log("Finger are near each other! Congratulation!");
                    }
                }
                break;

            case WhichFingerToCalculate.ThumbAndIndex:
                if (thumbTipFinger != null)
                {
                    float distance = Vector3.Distance(thumbTipFinger.position, indexTipFinger.position);
                    Debug.Log($"This is the distance between thumb and finger fingers: {distance}");

                    if (distance <= threshold)
                    {
                        tipsAreNear = true;
                        Debug.Log("Finger are near each other! Congratulation!");
                    }
                }
                break;

            case WhichFingerToCalculate.ThumbAndPinky:
                if (thumbTipFinger != null)
                {
                    float distance = Vector3.Distance(thumbTipFinger.position, pinkyTipFinger.position);
                    Debug.Log($"This is the distance between thumb and pinky fingers: {distance}");

                    if (distance <= threshold)
                    {
                        tipsAreNear = true;
                        Debug.Log("Finger are near each other! Congratulation!");
                    }
                }
                break;
        }
    }
}