 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
    public void PrintHit()
    {
        StartCoroutine(FandOut(transform.GetChild(4)));
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
            print(t);
           fade.transform.GetComponent<Image>().color = new Color(255, 255, 255, t);
        }
        yield return null;
    }
}
