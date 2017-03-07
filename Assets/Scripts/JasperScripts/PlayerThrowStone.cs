using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowStone : MonoBehaviour
{

    public float firingAngle = 45.0f;
    public float gravity = 9.82f;
	//public float dis = 10f;
    public Transform Projectile;
    //public Transform Target;
    private Transform myTransform;
    //public Transform prefabStone;

    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        print("Stone Start !!");
        //prefabStone = Resources.Load("Stone One") as Transform;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
			StartCoroutine(SimulateProjectile(30));
        }
    }

	IEnumerator SimulateProjectile(float dis)
    {
        yield return new WaitForSeconds(1.5f);

        //Transform stoneNew = Instantiate(prefabStone) as Transform;

       Projectile.position = new Vector3(23f, 1.0f, -16f);
       //print("Stone Position: " + Projectile.position);

       //float target_Distance = Vector3.Distance(Projectile.position, Target.position);

        //print("Target Position: " + Target.position);
        //print("Target Distance: " + dis);

        float stoneNew_Velocity = dis / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
        print("Velocity Stone" + stoneNew_Velocity);

        float Vz = Mathf.Sqrt(stoneNew_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(stoneNew_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
		Debug.Log ("VAn toc Vy ban dau: " + Vy);

		float flightDuration = dis / Vz;

        //Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vz * Time.deltaTime);
			if ((Vy - (gravity * elapse_time)) <= 0){
				Debug.Log ("NMDNMDNMDNMDNDDDASDFASFSDFSAF: " + Projectile.position);

			}
            elapse_time += Time.deltaTime;

			//print("Projectile: " + Projectile.position);

            yield return null;
        }
        print("Stone Position Finish: " + Projectile.position);

        //if (Projectile.position.z >= Target.position.z)
        //{
        //    Destroy(Projectile);
        //    print("Stone Destroy !!");
        //}
    }
}
