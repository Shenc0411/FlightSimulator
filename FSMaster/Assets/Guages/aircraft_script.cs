using UnityEngine;
using System.Collections;

public class aircraft_script : MonoBehaviour {

    public static aircraft_script instance;

	public float velocity;
	public float anglePitch;
	public float angleYaw;
	public float angleRoll;
	public float altitude;
	public float gyro;
	public float gyroS; 
	public float altS;
	public float threshold = 0f;
	public int firstTime = 0;
	public Vector2 yaw;

    public GameObject terrain;

    private Vector3 realPos;
    private Quaternion realRot;

	// Use this for initialization
	void Start () {

        if (instance != null)
        {
            Debug.LogError("There should only be one instance of plane script!");
            Destroy(gameObject);
        }

        instance = this;

	}
		

	// Update is called once per frame
	void FixedUpdate () {

		angleYaw = yaw.x;

		Vector3 pil	= realRot.eulerAngles;
	    pil.z = anglePitch;
		pil.x = angleRoll;
		pil.y = gyro - gyroS- 90f;

        Quaternion rot = Quaternion.Euler(pil);

        realRot = rot;

        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 0.2f);

		
		Vector3 terrainPos = realPos;
		terrainPos -= 6.67f*(transform.right * Time.fixedDeltaTime * velocity);
		terrainPos.y = -(6.67f)*(altitude - altS);

        realPos = terrainPos;

		terrain.transform.position = Vector3.Lerp(terrain.transform.position, terrainPos, 0.2f);


	}


}