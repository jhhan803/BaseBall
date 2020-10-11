using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] bases = new Transform[3];
    Vector3 LeftCheck;
    Vector3 RightCheck;

   // public GameObject PitchingMachine;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            bases[i] = transform.GetChild(i);
        }
        LeftCheck = bases[2].position - bases[0].position;
        RightCheck = bases[1].position - bases[0].position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ball")
        {
            Vector3 ballVector = collision.transform.position - bases[0].position;

            float Lsight = Vector3.Dot(bases[0].up, (Vector3.Cross(ballVector, LeftCheck)));
            float Rsight = Vector3.Dot(bases[0].up, (Vector3.Cross(ballVector, RightCheck)));

            float outCheck=Vector3.Dot(new Vector3(0, 0, 1f), ballVector);


            if(Lsight<0&&Rsight<0&&outCheck>0)
            {

                GameManager.instance.CallHit();//안타
            }
            else
            {
                GameManager.instance.CallFoul(); //아웃
            }
            //공을 던져라
            //StartCoroutine(PitchingMachine.GetComponent<PitchingMachine>().throwdelay());
        }
    }
    

}
