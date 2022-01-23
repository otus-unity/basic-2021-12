using UnityEngine;

public class MathExample : MonoBehaviour
{
    private Vector3 v1, v2, v1v2;
    
    /*private float curr;
    private float max = 10;
    private float speed = 2f;*/
    
    void Start()
    {
        Debug.Log("Rotation Quaternion " + transform.rotation);
        Debug.Log("Rotation  " + transform.rotation.eulerAngles);

        //transform.rotation = Quaternion.Euler(90, 0, 0);

        // Mathf свойства
        /*Debug.Log("PI " + Mathf.PI);
        Debug.Log("Epsilon " + Mathf.Epsilon);
        Debug.Log("Rad2Deg " + Mathf.Rad2Deg * 1);
        Debug.Log("Deg2Rad " + Mathf.Deg2Rad * 30);
        Debug.Log("Infinity " + Mathf.Infinity);
        Debug.Log("NegativeInfinity " + Mathf.NegativeInfinity);*/

        // Mathf методы
        /*Debug.Log("Approximately " + Mathf.Approximately(2.0f, 8.0f/4.0f));
        Debug.Log("Round " + Mathf.Round(1.5f) + " Round " + Mathf.Round(1.9f));
        Debug.Log("Floor " + Mathf.Floor(1.8f));
        Debug.Log("Ceil " + Mathf.Ceil(1.2f));*/

        /*Debug.Log("Sign " + Mathf.Sign(-1.4f));
        Debug.Log("Max " + Mathf.Max(5, 6, 10, 55, 19));*/

        /*Debug.Log("Abs " + Mathf.Abs(-6));
        Debug.Log("Sqrt " + Mathf.Sqrt(121));
        Debug.Log("Pow " + Mathf.Pow(2, 5));
        Debug.Log("Pow2 " + Mathf.NextPowerOfTwo(27));*/

        /*v1 = new Vector3(5, 1, -2);
        v2 = new Vector3(1, 7, 5);*/

        /*v1v2 = v1 + v2;
        Debug.Log("Length " + Vector3.Magnitude(v1));
        Debug.Log("LengthSqr " + Vector3.SqrMagnitude(v1));*/

        /*Debug.Log("Dot " + Vector3.Dot(v1, v2));
        Debug.Log("Angle " + Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(v1, v2) * Mathf.Deg2Rad));*/

        //v1v2 = Vector3.Cross(v1, v2);
    }

    void Update()
    {
        /*Debug.DrawLine(Vector3.zero, v1, Color.red);
        Debug.DrawLine(Vector3.zero, v2, Color.blue);
        Debug.DrawLine(Vector3.zero, v1v2, Color.yellow);*/

        //Debug.Log("Lerp " + Mathf.Lerp(5, 10, Time.time));
        
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            float rnd = Random.Range(4.0f, 10.0f);
            Debug.Log( "Rnd " + rnd + " Clamp " + Mathf.Clamp(rnd, 6.0f, 8.0f));
        }*/
        
        //Debug.Log("PingPong " + Mathf.PingPong(Time.time, 3));

        /*curr = Mathf.MoveTowards(curr, max, speed * Time.deltaTime);
        Debug.Log("Curr " + curr);*/
    }
}
