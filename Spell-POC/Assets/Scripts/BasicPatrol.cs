using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPatrol : Mind
{
    public Vector3[] points;
    human human;

    // Start is called before the first frame update
    void Start()
    {
        human=GetComponent<human>();
        StartCoroutine(Patrol());
    }
    IEnumerator Patrol()
    {
        while (true)
        {
            foreach (Vector3 point in points)
            {
                yield return human.Reach(point);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
