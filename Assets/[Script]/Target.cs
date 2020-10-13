using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update


    public bool Strikezone=false;

    void Start()
    {
     if(transform.name.Contains("Strike"))
        {
            Strikezone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="ball")
        {
            Destroy(collision.gameObject);
            if(Strikezone)
            {
                GameManager.instance.CallStrike();
            }
            else
            {
                GameManager.instance.CallBall();
            }
        }
    }
}
