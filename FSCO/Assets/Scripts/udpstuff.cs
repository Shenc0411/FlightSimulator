using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using Photon;

public class udpstuff : PunBehaviour{

    public static udpstuff instance;

    public float roll, pitch, heading, speed, altitude, yaw;
    private int clientPort = 55555;
	UdpClient udpServer;

	// Use this for initialization
	void Start () {
		try{
			udpServer = new UdpClient(clientPort);
		}
		catch (System.Exception e){
			print ("Couldnt do it foo");
		}

        if (instance != null)
        {
            Debug.LogError("There should only be one instance of udp script!");
            Destroy(gameObject);
        }

        instance = this;

    }

	// Update is called once per frame
	void Update () {

		//OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

		if (udpServer.Available > 0) {
			IPEndPoint dataServer = new IPEndPoint (IPAddress.Any, clientPort);
			byte[] udpInput = udpServer.Receive (ref dataServer);
			int index = 9;
			speed = System.BitConverter.ToSingle(udpInput, index);
			pitch = System.BitConverter.ToSingle (udpInput, index + 36);
			roll = -System.BitConverter.ToSingle (udpInput, index + 40);
			heading = System.BitConverter.ToSingle (udpInput, index + 44);
			altitude = System.BitConverter.ToSingle (udpInput, index + 80);
            //yaw = System.BitConverter.ToSingle (udpInput, index + 108);

            //OlD

            if (heading != 0 && aircraft_script.instance.firstTime == 0)
            {
                aircraft_script.instance.gyroS = heading; // Get initial heading in X-Plane
                aircraft_script.instance.altS = altitude;
                aircraft_script.instance.firstTime++;
            }

            aircraft_script.instance.velocity = speed;
            aircraft_script.instance.anglePitch = pitch;
            aircraft_script.instance.angleRoll = roll;
            aircraft_script.instance.gyro = heading;
            aircraft_script.instance.altitude = altitude;

        }
	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

}
