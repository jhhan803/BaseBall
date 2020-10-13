using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    float maxDistance;
    void Start()
    {
        maxDistance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BallCount(int count)
    {
        transform.GetChild(1).GetComponent<Text>().text = "x" + count;
    }
    public void PrintStrike()
    {
        StartCoroutine(FandOut(transform.GetChild(2)));
    }
    public void PrintBall ()
    {
        StartCoroutine(FandOut(transform.GetChild(3)));
    }
    public void PrintHit(float distance)
    {
        StartCoroutine(FandOut(transform.GetChild(4)));
        transform.GetChild(7).GetComponent<Text>().text = "현재비거리:" + (Mathf.Round(distance * 10) * 0.1f).ToString()+"m";
        if(distance>maxDistance)
        {
            maxDistance = distance;
            transform.GetChild(8).GetComponent<Text>().text = "최대비거리:" + (Mathf.Round(distance * 10) * 0.1f).ToString() + "m";
        }
    }
    public void PrintFoul()
    {
        StartCoroutine(FandOut(transform.GetChild(5)));
    }

    IEnumerator FandOut(Transform fade)
    {
        fade.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        float t=1;
        yield return new WaitForSeconds(1f);
        while (t >= 0)
        {
            t -= Time.deltaTime*0.1f;
           // print(t);
           fade.transform.GetComponent<Image>().color = new Color(255, 255, 255, t);
         //   yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }
}
