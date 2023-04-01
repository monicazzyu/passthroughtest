using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViusalRec : MonoBehaviour
{
    public GameObject OrangePrefab;
    public GameObject RedPrefab;
    public Transform RightHand;

    public RectTransform Center;
    public float IncreaseInterval = 1.0f;
    public float ScaleIncreaseAmount = 0.1f;

    public int MoveCount;
    private int preCount;

    private float timer = 0.0f;
    private List<GameObject> orangexls = new List<GameObject>();
    private List<GameObject> redxls = new List<GameObject>();

    public float currentSpeed;
    public float currentDelay;

    public float MinDelay = 0.1f;
    public float MaxDelay = 2f;
    private float lastSpawnTime = 0f;
    private Vector3 lastPosition;

    public float orangeredDelayScale = 0.2f; // factor to adjust delay based on acceleration
    public float orangeredScaleDifference = 5f; // difference in scale between orange and red rectangles

    private float orangeSpawnTime = 0f;
    private float redSpawnTime = 0f;
    private bool orangeSpawned = false;
    private bool redSpawned = false;




    public void TouchRecVisualXL()
    {
        GameObject prefab = (orangexls.Count > redxls.Count) ? RedPrefab : OrangePrefab;

        GameObject rectangle = Instantiate(prefab, Vector3.zero, Quaternion.identity, Center.transform);
        rectangle.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        rectangle.transform.localPosition = Vector3.zero;
        rectangle.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);

        if (prefab == OrangePrefab)
        {
            orangexls.Add(rectangle);
        }
        else
        {
            redxls.Add(rectangle);
        }
    }






    private void Update()
    {






        // patonly
        timer += Time.deltaTime;

        if (timer >= IncreaseInterval)
        {
            timer -= IncreaseInterval;

            foreach (var orangexl in orangexls)
            {
                if (orangexl != null)
                {
                    orangexl.transform.localScale += Vector3.one * ScaleIncreaseAmount ;

                    if(orangexl.transform.localScale.x >= 0.004)
                    {
                        Destroy(orangexl);
                    }
                }
            }

            foreach (var red in reds)
            {
                if (red != null)
                {
                    red.transform.localScale += Vector3.one * ScaleIncreaseAmount ;
                    if(red.transform.localScale.x >= 0.005)
                    {
                        Destroy(red);
                    }
                }
            }
        }

        oranges.RemoveAll(item => item == null);
        reds.RemoveAll(item => item == null);
    }
}
