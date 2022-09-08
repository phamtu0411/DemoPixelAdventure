using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFollow : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    private int currenPointIndex = 0;
    [SerializeField] private float speed = 4f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(points[currenPointIndex].transform.position, transform.position)<.1f)
        {
            currenPointIndex++;
            if(currenPointIndex >= points.Length)
            {
                currenPointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[currenPointIndex].transform.position, Time.deltaTime * speed);
    }
}
