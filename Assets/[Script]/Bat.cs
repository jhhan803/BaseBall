using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    // Start is called before the first frame update
    Transform hitspot;
    Vector3 Position1;
    Vector3 Position2;
    Vector3 swingvector;

    public GameObject hitEffect;
    void Start()
    {
        hitspot = transform.GetChild(2);
        Position1 = hitspot.position;
        StartCoroutine(GetDVector());
    }

    // Update is called once per frame
    void Update()
    {  

    }
    IEnumerator GetDVector()
    {
        Position2 = hitspot.position;
        swingvector = Position2 - Position1;
        yield return new WaitForSeconds(0.1f);
        Position1 = hitspot.position;
        StartCoroutine(GetDVector());

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="ball")
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(swingvector);
            GameObject hiteffect=Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(hiteffect, 1f);
        }
    }
}
