using System.Collections;
using System.Collections.Generic;
using TrueSync;
using UnityEngine;

public class TestMassMentre : MonoBehaviour
{
    TSRigidBody  TSRigidBody;
    public Vector3 Vector3;

    private void Awake()
    {
        TSRigidBody = this.GetComponent<TSRigidBody>();
       // TSRigidBody.centerOfMass = TSVector.right * 2;
        TSRigidBody.drag = 1;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(TSRigidBody.centerOfMass);
    }
}
