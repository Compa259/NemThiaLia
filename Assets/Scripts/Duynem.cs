using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duynem : MonoBehaviour
{

    public GameObject prefab;
    public float maxDist = 30f; // dich
    Vector3 playerAngle;
    Vector3 cameraAngle;
    //Transform target;
    //
    //float rotationSpeed = 10f;
    float jumpHeight;
    float jumpWidth = 10f;
    float down = 0;
    bool isFalling = false;
    //

    public Image power;

    public float Power()
    {
        float dis = (1.0f - power.fillAmount) * maxDist;
        Debug.Log(dis);
        return dis;
    }


    void Start()
    {
        prefab = Resources.Load("duy") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject duy = Instantiate(prefab) as GameObject;

            playerAngle = new Vector3(0.0f, duy.transform.forward.y, duy.transform.forward.z);
            cameraAngle = new Vector3(0.0f, Camera.main.transform.forward.y, Camera.main.transform.forward.z);
            float horizDiffAngle = Vector3.Angle(playerAngle, cameraAngle) * Mathf.Deg2Rad;


            float Vi = Mathf.Sqrt(Power() * 9.82f / (Mathf.Sin(2 * horizDiffAngle)));
            float Vy = Vi * Mathf.Sin(horizDiffAngle);
            float Vz = Vi * Mathf.Cos(horizDiffAngle);

            duy.transform.Translate(0, Vy * Time.deltaTime, Vz * Time.deltaTime);



            //= transform.position + Camera.main.transform.forward * 2;
            Rigidbody rb = duy.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * 20;



            //rb.velocity = new Vector3(0.0f, 10, 10);


            //Debug.Log(rb.velocity);


            //Debug.Log(horizDiffAngle);

            Rigidbody rb1 = duy.GetComponent<Rigidbody>();
            Debug.Log(rb1.velocity);
            if (isFalling == true)
            {
                print("Duy dep trai");

                jumpHeight = Mathf.Pow((10 * Mathf.Sin(2 * horizDiffAngle)), 2);
                //isFalling = true;
                Vector3 v = rb1.velocity;
                v.x = jumpWidth - down;
                v.y = jumpHeight - down;
                rb1.velocity = v;
                down += 5f;
                Debug.Log(v.x);

                if (v.x <= 0)
                {
                    Destroy(duy.gameObject, 3);
                }
            }

            //Destroy(duy.gameObject, 3);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isFalling = true;
        Debug.Log("DatVIT: " + collision.gameObject.name);
    }
}
