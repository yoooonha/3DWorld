using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }


    void Move()
    {
        float vX = Input.GetAxisRaw("Horizontal");
        float vZ = Input.GetAxisRaw("Vertical");
        float vY = GetComponent<Rigidbody>().velocity.y; //현재속도.y축=0

        Vector3 v3 = new Vector3(vX,0,vZ);
        Vector3 vYz = v3 * 4.5f;
        vYz.y += vY;
        GetComponent<Rigidbody>().velocity = vYz;
        if (v3 != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(v3); //
        }

    }
}
