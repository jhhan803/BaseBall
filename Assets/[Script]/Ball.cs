using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Ball(Vector3 _start, Vector3 _end, float _speed)
    {
       start = _start;
       end = _end;
       speed = _speed;
    }
    public Vector3 start;
    public Vector3 end;
    public float speed=0.5f;

    public Transform[] p;
    int random;
    Rigidbody rg;

    Vector3 Position1;
    Vector3 Position2;
   public Vector3 swingvector;

    PitchingMachine pitchingMachine;

    void Start()
    {
        random = Random.Range(0, 3);
        rg = GetComponent<Rigidbody>();
      //  if (random == 0)
     //   {
            transform.name = "straight";
            rg.AddForce((end - transform.position) * 10f);
        //  }
        //else
        //{
        //    transform.name = "curve";

        //    ThrowBallAtTargetLocation(end, 15f);
        //}
        Position2 = transform.position;
        StartCoroutine(GetDVector());
    }
    IEnumerator GetDVector()
    {
        Position2 = transform.position;
        swingvector = Position2 - Position1;
        yield return new WaitForSeconds(0.1f);
        Position1 = transform.position;
        StartCoroutine(GetDVector());
    }


    void Update()
    {
      //  ThrowUpdate();
    }

    IEnumerator ForceStraight()
    {
        rg.AddForce(end - transform.position);
        yield return new WaitForEndOfFrame();
    }




    private void OnCollisionEnter(Collision collision)
    {
        transform.GetComponent<Rigidbody>().useGravity = true;
        if(collision.transform.tag=="Target")
        {
            Destroy(gameObject);
            StartCoroutine(pitchingMachine.throwdelay());
        }       
    }

    public void Throw(Vector3 _start, Vector3 _end, float _speed,PitchingMachine pitchingMachine1)
    {
        start = _start;
        end = _end;
        speed = _speed;
        pitchingMachine = pitchingMachine1;

    }



    /*

    // Throws ball at location with regards to gravity (assuming no obstacles in path) and initialVelocity (how hard to throw the ball)
    public void ThrowBallAtTargetLocation(Vector3 targetLocation, float initialVelocity)
    {
        Vector3 direction = (targetLocation - transform.position).normalized;
        print($"방향{direction}");
        float distance = Vector3.Distance(targetLocation, transform.position);
        print($"거리{distance}");
        float firingElevationAngle = FiringElevationAngle(Physics.gravity.magnitude, distance, initialVelocity);

        Vector3 elevation = Quaternion.AngleAxis(firingElevationAngle, transform.right) * transform.up;
        float directionAngle = AngleBetweenAboutAxis(transform.forward, direction, transform.up);
        Vector3 velocity = Quaternion.AngleAxis(directionAngle, transform.up) * elevation * initialVelocity;
        //  print($"{velocity}{elevation}{firingElevationAngle}");
        // ballGameObject is object to be thrown
        GetComponent<Rigidbody>().AddForce(velocity, ForceMode.VelocityChange);
    }

    // Helper method to find angle between two points (v1 & v2) with respect to axis n
    public static float AngleBetweenAboutAxis(Vector3 v1, Vector3 v2, Vector3 n)
    {
        return Mathf.Atan2(
            Vector3.Dot(n, Vector3.Cross(v1, v2)),
            Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
    }

    // Helper method to find angle of elevation (ballistic trajectory) required to reach distance with initialVelocity
    // Does not take wind resistance into consideration.
    private float FiringElevationAngle(float gravity, float distance, float initialVelocity)
    {
        print($"{gravity}&{distance}&{initialVelocity}");
        print($"아신{Mathf.Asin(gravity * distance) / (initialVelocity * initialVelocity)}라드2{ Mathf.Rad2Deg }");
        float angle = 0.5f * Mathf.Asin((gravity * distance) / (initialVelocity * initialVelocity)) * Mathf.Rad2Deg;
        print($"앵글{angle}");
        return angle;
    }
        void ThrowUpdate()
    {
   
        if (isStart)
        {

            if (random == 0)
            {
            //    StartCoroutine(ForceStraight());
                // StartCoroutine(BezierStraight());
              //  print("straight");
            }

            else
            {
                // StartCoroutine(BezierCurveStart());
                StartCoroutine(BezierCurveStart());
                print("curve");
            }
            

        }
    }
    
    /*
IEnumerator ForceCurve()
{
    t += Time.deltaTime * speed;

    while (t < 1)
    {

        bezierPosition = Mathf.Pow(1 - t, 2) * start
                + 3 * t * Mathf.Pow(1 - t, 1) * curve1
                // + 3 * t * (1 - t) * curve2
                + Mathf.Pow(t, 2) * end;

        rg.AddForce(bezierPosition - transform.position);

        yield return new WaitForEndOfFrame();
    }
}
    private IEnumerator BezierStraight()
    {
        t += Time.deltaTime * speed*1.5f;
        while (t < 1)
        {
            
            bezierPosition =
                (1 - t) * start + t * end;
            transform.position = bezierPosition;
            transform.Rotate(Vector3.forward * speed * 10f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        t = 0f;
    }
        private IEnumerator BezierCurveStart() {        
        t += Time.deltaTime * speed;

        while(t < 1) {

            bezierPosition = Mathf.Pow(1 - t, 2) * start
                    + 3 * t * Mathf.Pow(1 - t, 1) * curve1
                   // + 3 * t * (1 - t) * curve2
                    + Mathf.Pow(t, 2) * end;

            transform.position = bezierPosition;
            transform.Rotate(Vector3.forward*speed*10f*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        t = 0f;
    }
    */
}
