using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonPlaneView : MonoBehaviour{

    private bool isMaster;

    private float realVelocity;
    private float realAnglePitch;
    private float realAngleYaw;
    private float realAngleRoll;
    private float realAltitude;
    private float realGyro;
    private float realGyroS;
    private float realAltS;
    private Vector2 realYaw;

	// Use this for initialization
	void Start () {
        if (udpstuff.instance != null)
        {
            isMaster = true;
        }
        else
        {
            isMaster = false;
        }
	}
	
	void FixedUpdate () {
        if (!isMaster)
        {
            aircraft_script.instance.velocity = Mathf.Lerp(aircraft_script.instance.velocity, realVelocity, 0.2f);
            aircraft_script.instance.anglePitch = Mathf.Lerp(aircraft_script.instance.anglePitch, realAnglePitch, 0.2f);
            aircraft_script.instance.angleYaw = Mathf.Lerp(aircraft_script.instance.angleYaw, realAngleYaw, 0.2f);
            aircraft_script.instance.angleRoll = Mathf.Lerp(aircraft_script.instance.angleRoll, realAngleRoll, 0.2f);
            aircraft_script.instance.altitude = Mathf.Lerp(aircraft_script.instance.altitude, realAltitude, 0.2f);
            aircraft_script.instance.gyro = Mathf.Lerp(aircraft_script.instance.gyro, realGyro, 0.2f);
            aircraft_script.instance.gyroS = Mathf.Lerp(aircraft_script.instance.gyroS, realGyroS, 0.2f);
            aircraft_script.instance.altS = Mathf.Lerp(aircraft_script.instance.altS, realAltS, 0.2f);
            aircraft_script.instance.yaw = Vector2.Lerp(aircraft_script.instance.yaw, realYaw, 0.2f);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (isMaster && stream.isWriting)
        {

            stream.SendNext(aircraft_script.instance.velocity);
            stream.SendNext(aircraft_script.instance.anglePitch);
            stream.SendNext(aircraft_script.instance.angleYaw);
            stream.SendNext(aircraft_script.instance.angleRoll);
            stream.SendNext(aircraft_script.instance.altitude);
            stream.SendNext(aircraft_script.instance.gyro);
            stream.SendNext(aircraft_script.instance.gyroS);
            stream.SendNext(aircraft_script.instance.altS);
            stream.SendNext(aircraft_script.instance.yaw);

        }

        if (!isMaster && stream.isReading)
        {

            realVelocity = (float)stream.ReceiveNext();
            realAnglePitch = (float)stream.ReceiveNext();
            realAngleYaw = (float)stream.ReceiveNext();
            realAngleRoll = (float)stream.ReceiveNext();
            realAltitude = (float)stream.ReceiveNext();
            realGyro = (float)stream.ReceiveNext();
            realGyroS = (float)stream.ReceiveNext();
            realAltS = (float)stream.ReceiveNext();
            realYaw = (Vector2)stream.ReceiveNext();

        }
    }

}
