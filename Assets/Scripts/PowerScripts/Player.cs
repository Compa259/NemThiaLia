using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private Stat health;


    private void Awake()
    {
        health.Initialize();
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.B))
        {
            health.CurrentVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            health.CurrentVal += 10;
        }
    }


}
