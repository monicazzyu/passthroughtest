using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViusalRec3 : MonoBehaviour
{
    public GameObject OrangePrefab;
    public GameObject RedPrefab;

    public RectTransform Center;
    public float IncreaseInterval = 1.0f;
    public float ScaleIncreaseAmount = 0.1f;

    public Quaternion target;

    public int countNumber;

    private GameObject prefab;



    private float timer = 0.0f;
    private List<GameObject> orangexls = new List<GameObject>();
    private List<GameObject> redxls = new List<GameObject>();

    private List<GameObject> orangels = new List<GameObject>();
    private List<GameObject> redls = new List<GameObject>();

    private List<GameObject> oranges = new List<GameObject>();
    private List<GameObject> reds = new List<GameObject>();







    public void TouchRecVisualXL()
    {
        countNumber += 1;

        if (countNumber % 2 == 1)
        {
            prefab = OrangePrefab;
        }
        else
        {
            prefab = RedPrefab;
        }

        //GameObject prefab = (orangexls.Count > redxls.Count) ? RedPrefab : OrangePrefab;

        GameObject rectangle = Instantiate(prefab, Vector3.zero, Quaternion.identity, Center.transform);
        rectangle.transform.rotation = Quaternion.Euler(90f, 0f, 15f);
        rectangle.transform.localPosition = new Vector3(0.155f, -0.07530004f, 0f);
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


    public void TouchRecVisualL()
    {
        countNumber += 1;

        if (countNumber % 2 == 1)
        {
            prefab = OrangePrefab;
        }
        else
        {
            prefab = RedPrefab;
        }

        //GameObject prefab = (orangexls.Count > redxls.Count) ? RedPrefab : OrangePrefab;

        GameObject rectangle2 = Instantiate(prefab, Vector3.zero, Quaternion.identity, Center.transform);
        rectangle2.transform.rotation = Quaternion.Euler(90f, 0f, -30f);
        rectangle2.transform.localPosition = new Vector3(-0.131f, 0.181f, 0f);
        rectangle2.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);

        if (prefab == OrangePrefab)
        {
            orangels.Add(rectangle2);
        }
        else
        {
            redls.Add(rectangle2);
        }
    }


    public void TouchRecVisual()
    {
        countNumber += 1;

        if (countNumber % 2 == 1)
        {
            prefab = OrangePrefab;
        }
        else
        {
            prefab = RedPrefab;
        }

        //GameObject prefab = (orangexls.Count > redxls.Count) ? RedPrefab : OrangePrefab;

        GameObject rectangle3 = Instantiate(prefab, Vector3.zero, Quaternion.identity, Center.transform);
        rectangle3.transform.rotation = Quaternion.Euler(90f, 0f, 41.2f);
        rectangle3.transform.localPosition = new Vector3(0.18f, 0.14f, 0f);
        rectangle3.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);

        if (prefab == OrangePrefab)
        {
            orangels.Add(rectangle3);
        }
        else
        {
            redls.Add(rectangle3);
        }
    }






    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= IncreaseInterval)
        {
            timer -= IncreaseInterval;


            // xl
            foreach (var orangexl in orangexls)
            {
                if (orangexl != null)
                {
                    orangexl.transform.localScale += Vector3.one * ScaleIncreaseAmount ;
                   
                    if (orangexl.transform.localScale.x >= 0.006)
                    {
                        Destroy(orangexl);
                    }
                }
            }

            foreach (var redxl in redxls)
            {
                if (redxl != null)
                {
                    redxl.transform.localScale += Vector3.one * ScaleIncreaseAmount;
              
                    if (redxl.transform.localScale.x >= 0.006)
                    {
                        Destroy(redxl);
                    }
                }
            }

            // l
            foreach (var orangel in orangels)
            {
                if (orangel != null)
                {
                    orangel.transform.localScale += Vector3.one * ScaleIncreaseAmount;

                    if (orangel.transform.localScale.x >= 0.004)
                    {
                        Destroy(orangel);
                    }
                }
            }

            foreach (var redl in redls)
            {
                if (redl != null)
                {
                    redl.transform.localScale += Vector3.one * ScaleIncreaseAmount;

                    if (redl.transform.localScale.x >= 0.004)
                    {
                        Destroy(redl);
                    }
                }
            }


            // m
            foreach (var orange in oranges)
            {
                if (orange != null)
                {
                    orange.transform.localScale += Vector3.one * ScaleIncreaseAmount;

                    if (orange.transform.localScale.x >= 0.0016)
                    {
                        Destroy(orange);
                    }
                }
            }

            foreach (var red in reds)
            {
                if (red != null)
                {
                    red.transform.localScale += Vector3.one * ScaleIncreaseAmount;

                    if (red.transform.localScale.x >= 0.0016)
                    {
                        Destroy(red);
                    }
                }
            }

        }

        orangexls.RemoveAll(item => item == null);
        redxls.RemoveAll(item => item == null);

        oranges.RemoveAll(item => item == null);
        reds.RemoveAll(item => item == null);

        orangels.RemoveAll(item => item == null);
        redls.RemoveAll(item => item == null);
    }
}
