using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TrueSync
{
    /// <summary>
    /// 车轴信息
    /// </summary>
    [Serializable]
    public class AxleInfo
    {
        [Header("Wheer")]
        /// <summary>
        /// 车轮半径
        /// </summary>
        public FP wheelRadius = 0.3f;

        public FP steerTime = 8;

        /// <summary>
        /// 转角
        /// </summary>
        public FP steerAngle;

        public FP Width = 0;

        public TSVector offset = TSVector.zero;
        /// <summary>
        /// 是否是转向
        /// </summary>
        public bool isSwerve;

        [Header("Suspension")]
        /// <summary>
        /// 悬挂长度
        /// </summary>
        public FP restLength;
        /// <summary>
        /// 弹簧动程
        /// </summary>
        public FP springTravel;
        /// <summary>
        /// 弹簧强度
        /// </summary>
        public FP springStiffness;
        /// <summary>
        /// 弹簧阻尼
        /// </summary>
        public FP damperStiffness;

        [HideInInspector]
        public WheelData wheelL;


        [HideInInspector]
        public WheelData wheelR;
    }


    public class WheelData
    {
        /// <summary>
        /// 车轮是否在地面
        /// </summary>
        // is wheel touched ground or not ?
        [HideInInspector]
        public bool isOnGround = false;

        /// <summary>
        /// 车轮接触点
        /// </summary>
        // wheel ground touch point
        [HideInInspector]
        public TSRaycastHit touchPoint = new TSRaycastHit();

        /// <summary>
        /// 阿克曼转向校正
        /// </summary>
        // real yaw, after Ackermann steering correction
        [HideInInspector]
        public FP yawRad = 0.0f;

        /// <summary>
        /// 视图旋转角度
        /// </summary>
        // visual rotation
        [HideInInspector]
        public FP visualRotationRad = 0.0f;

        /// <summary>
        /// 悬挂压力
        /// </summary>
        // suspension compression
        [HideInInspector]
        public FP compression = 0.0f;

        /// <summary>
        /// 更新之前的悬挂压力
        /// </summary>
        // suspension compression on previous update
        [HideInInspector]
        public FP compressionPrev = 0.0f;

        /// <summary>
        /// 悬挂开始的位置
        /// </summary>
        public TSVector SuspensionPosition;




        public FP minLength;
        public FP maxLength;
        public FP lastLength;
        public FP springLength;
        public FP springVelocity;
        public FP springForce;
        public FP damperForce;
        public FP wheelAngle;
        public TSVector suspensionForce;
    }

}
