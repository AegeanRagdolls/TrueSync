using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TrueSync
{
    public class TSVehicle : MonoBehaviour
    {
        public TSVector centerOfGravity;
        [SerializeField]
        public AxleInfo[] AxleInfo = new TrueSync.AxleInfo[2];

        TSRigidBody tsRigidBody;

        TSTransform selfTransform;

        public void Awake()
        {
            this.tsRigidBody = this.GetComponent<TSRigidBody>();
            this.selfTransform = this.GetComponent<TSTransform>();
            this.tsRigidBody.centerOfMass = centerOfGravity;
            this.CountSuspensionPosition();

        }

        public void FixedUpdate()
        {
            this.CountSuspensionPosition();
            foreach (var item in AxleInfo)
            {
                Suspension(item, item.wheelL);
                Suspension(item, item.wheelR);
            }
        }


        TSTransform tSTransform;
        public void OnDrawGizmos()
        {
            var tmpColor = Gizmos.color;
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.TransformPoint(this.centerOfGravity.ToVector()), 0.2F);
            foreach (var item in AxleInfo)
            {
                var tmpPosition = transform.TransformPoint(item.offset.ToVector());
                Debug.DrawLine(this.transform.position + this.centerOfGravity.ToVector(), tmpPosition, Color.red);
                TSVector lv = item.offset, rv = item.offset;
                lv.x -= item.Width / 2;
                rv.x += item.Width / 2;
                Debug.DrawLine(transform.TransformPoint(lv.ToVector()), transform.TransformPoint(rv.ToVector()), Color.red);

            }
            Gizmos.color = tmpColor;
        }

        public void CountSuspensionPosition()
        {
            foreach (var item in this.AxleInfo)
            {
                var tmpPosition = this.selfTransform.TransformPoint(item.offset);
                Debug.DrawLine((this.selfTransform.position + this.centerOfGravity).ToVector(), tmpPosition.ToVector(), Color.black);
                TSVector lv = item.offset, rv = item.offset;
                lv.x -= item.Width / 2;
                rv.x += item.Width / 2;
                if (item.wheelL == null)
                    item.wheelL = new WheelData();
                if (item.wheelR == null)
                    item.wheelR = new WheelData();
                item.wheelL.SuspensionPosition = this.selfTransform.TransformPoint(lv);
                item.wheelR.SuspensionPosition = this.selfTransform.TransformPoint(rv);
                //item.wheelL.minLength = item.restLength - item.springTravel;
                //item.wheelR.maxLength = item.restLength + item.springTravel;
                Debug.DrawLine(item.wheelL.SuspensionPosition.ToVector(), item.wheelR.SuspensionPosition.ToVector(), Color.black);

            }
        }



        public void Suspension(AxleInfo axleInfo, WheelData wheel)
        {
            if (Physics.Raycast(wheel.SuspensionPosition.ToVector(), (this.selfTransform.up * -1).ToVector(), out RaycastHit hit, (wheel.maxLength + axleInfo.wheelRadius).AsFloat()))
            {
                Debug.Log(hit.transform.name);

                if (hit.transform.name == this.transform.name)
                {
                    return;
                }
                wheel.lastLength = wheel.springLength;
                wheel.springLength = hit.distance - axleInfo.wheelRadius;
                // wheel.springLength = TSMath.Clamp(wheel.springLength, wheel.minLength, wheel.maxLength);
                wheel.springVelocity = (wheel.lastLength - wheel.springLength) / Time.fixedDeltaTime;
                wheel.springForce = axleInfo.springStiffness * (axleInfo.restLength - wheel.springLength);
                wheel.damperForce = axleInfo.damperStiffness * wheel.springVelocity;

                wheel.suspensionForce = (wheel.springForce + wheel.damperForce) * this.selfTransform.up;

                this.tsRigidBody.AddForceAtPosition(wheel.suspensionForce, hit.point.ToTSVector());
            }
        }
    }
}
