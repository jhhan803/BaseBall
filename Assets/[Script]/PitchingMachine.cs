using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PitchingMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;
    Transform[] Targets;
    public  GameObject BallPrefab;
    public float speed=5f;
    void Start()
    {
        Targets= new Transform[Target.transform.childCount];
        for (int i = 0; i < Target.transform.childCount; i++)
        {
            Targets[i] = Target.transform.GetChild(i);
        }
        print(Targets.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void ThrowBall()
    {
       int rand = Random.Range(0, 4);
       if(rand/3==0)
        {
            ThrowCurve();
        }
        else
        {
            ThrowStraight();
        }
    }
    void ThrowStraight()
    {
        var Ball = Instantiate(BallPrefab, transform.position, transform.rotation);
        int random = Random.Range(0, Targets.Length);
        //Ball baseball = new Ball(transform.position, Targets[random].position, 5f);
        Ball.GetComponent<Ball>().Throw(transform.position, Targets[random].position, speed,transform.GetComponent<PitchingMachine>());//transform.position, Targets[random].position, 5f);
        Ball.GetComponent<Ball>().ThrowStragiht();

    }
    void ThrowCurve()
    {
        var Ball = Instantiate(BallPrefab, transform.position, transform.rotation);
        Ball.GetComponent<Ball>().Throw(transform.position, Targets[Targets.Length-1].position, speed, transform.GetComponent<PitchingMachine>());
       
        Ball.GetComponent<Ball>().ThrowCurve();
    }
     public IEnumerator Throwdelay()
     {  
        yield return new WaitForSeconds(2f);
        print("볼던짐");
        ThrowBall();    
     }
}
