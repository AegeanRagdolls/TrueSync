using System.Collections;
using System.Collections.Generic;
using TrueSync;
using UnityEngine;

public class TestMassMentre : MonoBehaviour
{
    TSBoxCollider TSBoxCollider;
    public Vector3 Vector3;

    Rigidbody Rigidbody;
    private void Awake()
    {
        TSBoxCollider = this.GetComponent<TSBoxCollider>();
       TSBoxCollider.Shape.geomCen =  TSVector.right*2;
        Rigidbody.centerOfMass
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.LogError(TSBoxCollider.Shape.geomCen);
    }
}
