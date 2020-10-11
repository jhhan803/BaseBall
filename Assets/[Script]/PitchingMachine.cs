using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PitchingMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;
    public Transform[] Targets = new Transform[25];
    public  GameObject BallPrefab;
    public float speed=5f;
    void Start()
    {
        for(int i=0;i<Target.transform.childCount;i++)
        Targets[i] = Target.transform.GetChild(i);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void ThrowBall()
    {
        var Ball = Instantiate(BallPrefab, transform.position, transform.rotation);
        int random = Random.Range(0, 25);
     //   Ball baseball = new Ball(transform.position, Targets[random].position, 5f);
        Ball.GetComponent<Ball>().Throw(transform.position, Targets[random].position, speed,transform.GetComponent<PitchingMachine>());//transform.position, Targets[random].position, 5f);
    }
     public IEnumerator throwdelay()
     {  
        yield return new WaitForSeconds(2f);
        ThrowBall();    
     }
}
