using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{

    [SerializeField] Transform _cam;
    Animator _ani;
    float _moveValue = 0;
    void Start()
    {
        _ani = GetComponent<Animator>();   
    }

    void Update()
    {
        Move();

      

        if (Input.GetMouseButton(0))
        {
            _ani.SetTrigger("Attack");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _ani.SetTrigger("Jump");
        }

    }


    void Move()
    {
        //Debug.Log("카메라가 보는 방향을 월드축 기준으로 변경하면"+_cam.transform.forward);
        transform.rotation = Quaternion.LookRotation(new Vector3(_cam.transform.forward.x, 0, _cam.transform.forward.z)); // Vector의 y축을 고정시킴
        float vX = Input.GetAxisRaw("Horizontal");
        float vZ = Input.GetAxisRaw("Vertical");
        float isSprint = 1;

        float vY = GetComponent<Rigidbody>().velocity.y; //현재속도.y축=0
        Vector3 forward = transform.forward; //내가 현재 보는 방향
        Vector3 right = transform.right;
        Vector3 v3 = forward * vZ + right * vX;
        Vector3 vYz = v3 * 4.5f;
        vYz.y += vY;
        GetComponent<Rigidbody>().velocity = vYz;

        _ani.SetFloat("AxisX", vX);
        _ani.SetFloat("AxisZ", vZ);
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isSprint = 2;
            _ani.SetFloat("AxisX", vX);
            _ani.SetFloat("AxisZ", vZ * isSprint);

        }
        //if (v3 != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.LookRotation(v3);
        //}

    }
}
