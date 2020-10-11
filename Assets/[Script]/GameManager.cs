using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public GameObject PitchingMachine;
    public int ballCount;
    public GameObject Canvas;
    public UI ui;

    void Awake()
    {
        if (GameManager.instance == null)
            GameManager.instance = this;
    }
    private void Start()
    {
        OrderThrow();
        ballCount = 10;
        ui = Canvas.GetComponent<UI>();
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
        ui.PrintFoul();
    }
    public void CallHit()
    {
        OrderThrow();
        ui.PrintHit();
    }
    void OrderThrow()
    {
        StartCoroutine(PitchingMachine.GetComponent<PitchingMachine>().throwdelay());
    }
    IEnumerator FadeUI()
    {
        yield return null;
    }
}
