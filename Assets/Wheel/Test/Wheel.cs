using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrueSync;
using UnityEngine;

public enum WheelPosition
{
    FrontLeft,
    FrontRigth,
    RearLeft,
    RearRigth
}

public class Wheel : MonoBehaviour
{
    //    public WheelPosition WheelPosition;

    //    public float speed;

    //    public Vector3 position;

    //    [Header("Suspension")]
    //    /// <summary>
    //    /// 悬挂长度
    //    /// </summary>
    //    public float restLength;
    //    /// <summary>
    //    /// 弹簧动程
    //    /// </summary>
    //    public float springTravel;
    //    /// <summary>
    //    /// 弹簧强度
    //    /// </summary>
    //    public float springStiffness;
    //    /// <summary>
    //    /// 弹簧阻尼
    //    /// </summary>
    //    public float damperStiffness;

    //    [Header("Wheer")]
    //    /// <summary>
    //    /// 车轮半径
    //    /// </summary>
    //    public float wheelRadius;

    //    public float steerTime = 8;

    //    /// <summary>
    //    /// 转角
    //    /// </summary>
    //    public FP steerAngle;

    //    private FP minLength;
    //    private FP maxLength;
    //    private FP lastLength;
    //    private FP springLength;
    //    private FP springVelocity;
    //    private FP springForce;
    //    private FP damperForce;
    //    private FP wheelAngle;

    //    private FP Fx;
    //    private FP Fy;

    //    private TSVector suspensionForce;
    //    /// <summary>
    //    /// 局部空间
    //    /// </summary>
    //    private TSVector wheelVelocityLS;


    //    private TSRigidBody trb;

    //    private TSTransform tsTransform;

    //    private TSTransform selfTransform;

    //    public void Awake()
    //    {
    //        trb = this.transform.parent.GetComponent<TSRigidBody>();
    //        tsTransform = this.transform.parent.GetComponent<TSTransform>();
    //        tsTransform.tsChildren.Add(selfTransform);
    //        minLength = restLength - springTravel;
    //        maxLength = restLength + springTravel;
    //    }

    //    private void Update()
    //    {
    //        transform.localRotation = TSQuaternion.Euler(TSVector.up * this.wheelAngle).ToQuaternion();
    //        // tsTransform.localRotation = TSQuaternion.Euler(TSVector.up * this.wheelAngle);


    //    }
    //    int i;
    //    TSVector tsVector;
    //    public void FixedUpdate()
    //    {
    //        //i++;
    //        //if (i == 500) TrueSyncManager.PauseSimulation();
    //        this.wheelAngle = TSMath.Lerp(this.wheelAngle, this.steerAngle, Time.fixedDeltaTime * this.steerTime);
    //        if (TSPhysics.Raycast(tsTransform.position + position.ToTSVector(), (tsTransform.up * -1), out TSRaycastHit hit, maxLength + wheelRadius))
    //        {
    //            if (hit.transform.gameObject == tsTransform.gameObject)
    //            {
    //                return;
    //            }
    //            lastLength = springLength;
    //            springLength = hit.distance.AsFloat() - wheelRadius;
    //            springLength = TSMath.Clamp(springLength, minLength, maxLength).AsFloat();
    //            springVelocity = (lastLength - springLength) / Time.fixedDeltaTime;
    //            springForce = springStiffness * (restLength - springLength);
    //            damperForce = damperStiffness * springVelocity;

    //            suspensionForce = (springForce + damperForce) * tsTransform.up;

    //            this.wheelVelocityLS = this.transform.InverseTransformDirection(this.trb.GetPointVelocity(hit.point).ToVector()).ToTSVector();

    //            //  this.Fx = Input.GetAxis("Vertical") * springForce * speed;
    //            this.Fx = Input.GetAxis("Vertical") * speed;
    //            this.Fy = wheelVelocityLS.x * springForce;

    //            // this.trb.AddForceAtPosition(suspensionForce + (Fx * transform.forward.ToTSVector()) + (Fy * (transform.right.ToTSVector() * -1)), hit.point);
    //            this.trb.AddForceAtPosition(suspensionForce + (Fx * tsTransform.forward), hit.point);
    //            // this.trb.AddForceAtPosition(suspensionForce, hit.point);

    //            tsVector.y = wheelAngle;

    //            // trb.AddTorque(tsVector);
    //            Debug.Log(hit.point.ToVector());
    //            Debug.DrawRay((tsTransform.position + position.ToTSVector()).ToVector(), hit.point.ToVector(), Color.red);

    //        }
    //    }

}


