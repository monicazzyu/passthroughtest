using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viusal : MonoBehaviour
{
    public GameObject PinkPrefab;
    public GameObject BluePrefab;
    public Transform RightHand;

    public RectTransform Center;
    public float IncreaseInterval = 1.0f;
    public float ScaleIncreaseAmount = 0.1f;

    public int MoveCount;
    private int preCount;

    private float timer = 0.0f;
    private List<GameObject> pinks = new List<GameObject>();
    private List<GameObject> blues = new List<GameObject>();

    public float currentSpeed;
    public float currentDelay;

    public float MinDelay = 0.1f;
    public float MaxDelay = 2f;
    private float lastSpawnTime = 0f;
    private Vector3 lastPosition;

    public float PinkBlueDelayScale = 0.2f; // factor to adjust delay based on acceleration
    public float PinkBlueScaleDifference = 5f; // difference in scale between pink and blue spheres

    private float pinkSpawnTime = 0f;
    private float blueSpawnTime = 0f;
    private bool pinkSpawned = false;
    private bool blueSpawned = false;




    public void TouchCircleVisual()
    {
        GameObject prefab = (pinks.Count > blues.Count) ? BluePrefab : PinkPrefab;

        GameObject sphere = Instantiate(prefab, Vector3.zero, Quaternion.identity, Center.transform);
        sphere.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        sphere.transform.localPosition = Vector3.zero;
        sphere.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);

        if (prefab == PinkPrefab)
        {
            pinks.Add(sphere);
        }
        else
        {
            blues.Add(sphere);
        }
    }





    public void FrictionCircleVisual()
    {
        if (Time.time - lastSpawnTime > currentDelay)
        {
            preCount = MoveCount;

            GameObject prefab = (pinks.Count > blues.Count) ? BluePrefab : PinkPrefab;

            GameObject sphere = Instantiate(prefab, Vector3.zero, Quaternion.identity, Center.transform);
            sphere.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            sphere.transform.localPosition = Vector3.zero;
            sphere.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);

            if (currentSpeed >= 0)
            {
                MoveCount++;
            }

            

            if (prefab == PinkPrefab && MoveCount != preCount)
            {
                pinks.Add(sphere);
            }
            else if(MoveCount != preCount)
            {
                blues.Add(sphere);
            }

            lastSpawnTime = Time.time;

        }
        
    }

    private void Update()
    {

        // frictiononly

        currentSpeed = (RightHand.position - lastPosition).magnitude;

        currentDelay = Mathf.Lerp(MaxDelay, MinDelay, currentSpeed / 50f);

        lastPosition = RightHand.position;




        // patonly
        timer += Time.deltaTime;

        if (timer >= IncreaseInterval)
        {
            timer -= IncreaseInterval;

            foreach (var pink in pinks)
            {
                if (pink != null)
                {
                    pink.transform.localScale += Vector3.one * ScaleIncreaseAmount ;

                    if(pink.transform.localScale.x >= 0.016)
                    {
                        Destroy(pink);
                    }
                }
            }

            foreach (var blue in blues)
            {
                if (blue != null)
                {
                    blue.transform.localScale += Vector3.one * ScaleIncreaseAmount ;
                    if(blue.transform.localScale.x >= 0.016)
                    {
                        Destroy(blue);
                    }
                }
            }
        }

        pinks.RemoveAll(item => item == null);
        blues.RemoveAll(item => item == null);
    }
}
