using System.Collections;
using System.Collections.Generic;
using TrueSync;
using UnityEngine;

public class VehicleControl : MonoBehaviour
{
    public Vector3 centerOfGravity;

    [Header("Wheels")]
    public Wheel[] wheels;

    /// <summary>
    /// 轴距(1/m)
    /// </summary>
    [Header("Vehicle Specs")]
    public float wheelBase = 2.550F;
    /// <summary>
    /// 后轮距
    /// </summary>
    public float rearTrack = 1.525F;
    /// <summary>
    /// 转弯半径
    /// </summary>
    public float turnRadius = 10.8F;

    [Header("Inputs")]
    public float steerInput;

    [Header("AckermannAngle")]
    [SerializeField]
    private FP ackermannAngleLeft;
    [SerializeField]
    private FP ackermannAngleRight;

    private void Awake()
    {
        return;
        this.GetComponent<TSRigidBody>().centerOfMass = centerOfGravity.ToTSVector();


    }
    private void Start()
    {
        var l = TSPhysics.RaycastAll(TSVector.up * 10, (TSVector.one), out TSRaycastHit[] hit, 2);
        Debug.DrawLine(Vector3.up * 10, Vector3.up * 10 + Vector3.one * 2, Color.red, 100);
        //Debug.Log(l);
        foreach (var item in hit)
        {
            //Debug.DrawLine(Vector3.up * 10, item.point.ToVector(), Color.red, 100);
            Debug.LogError(item.point + " || " + item.transform.name);
        }

        //var tmp = TSPhysics.Raycast(TSVector.up * 15, (TSVector.down), out TSRaycastHit hit, 100);
        //if (tmp)
        //{
        //    Debug.DrawLine(Vector3.up * 15, hit.point.ToVector(), Color.red, 100);
        //    Debug.Log(hit.transform.name);
        //}

    }
    void Update()
    {
        return;
        this.steerInput = Input.GetAxis("Horizontal");

        if (this.steerInput > 0)
        {
            this.ackermannAngleLeft = TSMath.Rad2Deg * TSMath.Atan(this.wheelBase / (this.turnRadius + (this.rearTrack / 2))) * this.steerInput;
            this.ackermannAngleRight = TSMath.Rad2Deg * TSMath.Atan(this.wheelBase / (this.turnRadius - (this.rearTrack / 2))) * this.steerInput;
        }
        else if (this.steerInput < 0)
        {
            this.ackermannAngleLeft = TSMath.Rad2Deg * TSMath.Atan(this.wheelBase / (this.turnRadius - (this.rearTrack / 2))) * this.steerInput;
            this.ackermannAngleRight = TSMath.Rad2Deg * TSMath.Atan(this.wheelBase / (this.turnRadius + (this.rearTrack / 2))) * this.steerInput;
        }
        else
        {
            this.ackermannAngleLeft = 0;
            this.ackermannAngleRight = 0;
        }

        foreach (var item in this.wheels)
        {
            switch (item.WheelPosition)
            {
                case WheelPosition.FrontLeft:
                    item.steerAngle = this.ackermannAngleLeft;
                    break;
                case WheelPosition.FrontRigth:
                    item.steerAngle = this.ackermannAngleRight;
                    break;
                case WheelPosition.RearLeft:
                    break;
                case WheelPosition.RearRigth:
                    break;
                default:
                    break;
            }
        }
    }
}
