using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Reflection;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public GameObject PitchingMachine;
    public int ballCount;
    public GameObject Canvas;
    public UI ui;
    public Animator pitchanim;

    void Awake()
    {
        if (GameManager.instance == null)
            GameManager.instance = this;
    }
    private void Start()
    {
        ui = Canvas.GetComponent<UI>();
        ballCount = 10;
        OrderThrow(); 
    }
    void Update()
    {
        
    }

    public void CallStrike()
    {
        OrderThrow();
        print("스트라이크");
        ballCount -=1;
        ui.BallCount(ballCount);
        ui.PrintStrike();
    }
    public void CallBall()
    {
        OrderThrow();
        print("볼");
        ui.PrintBall();
    }
    public void CallFoul()
    {
       OrderThrow();
        ballCount -= 1;
        ui.BallCount(ballCount);
        ui.PrintFoul();
    }
    public void CallHit(float distance)
    {
        OrderThrow();
        ui.PrintHit(distance);
    }
    void OrderThrow()
    {
        /*
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
        */
        StartCoroutine(Delay());
        if (ballCount > 0)
        {
            print("피칭");
            pitchanim.SetTrigger("Pitch");
            StartCoroutine(PitchingMachine.GetComponent<PitchingMachine>().Throwdelay());
           
        }

    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
    }
}
