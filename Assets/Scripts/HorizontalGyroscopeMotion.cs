using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalGyroscopeMotion : MonoBehaviour
{
    [Header("Logic")]
    private Gyroscope gyroscope;
    private Quaternion phoneRotation;
    private Vector3 gyroscopeRrotationRate;
    private bool gyroscopeActive;
    private Rigidbody2D rigidBody;
    private void EnableGyroscope(bool activate)
    {
        if(gyroscopeActive == activate)
            return;
        
        if(SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = activate;
            gyroscopeActive = activate;
        }
        else
        {
            gyroscopeActive = false;
        }
    }
    private Vector3 GetCurrentRotationRate()
    {
        if(gyroscopeActive)
        {
            return gyroscope.rotationRate;
        }
        return new Vector3();
    }
    private Quaternion GetCurrentOrientation()
    {
        if(gyroscopeActive)
        {
            return gyroscope.attitude;
        }
        return new Quaternion();
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        EnableGyroscope(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidBody)
        {
            Vector3 tilt = Input.acceleration;
            tilt = Quaternion.Euler(0, 90, 0) * tilt;
            rigidBody.AddForce(tilt);
        }

        if(gyroscopeActive)
        {
           /* Input.acceleration
            Vector3 CurrentRotationRate = GetCurrentRotationRate();
            Vector3 CurrentPosition = transform.position;
            CurrentPosition.x = CurrentRotationRate.x;
           // transform.position = CurrentPosition;

            Quaternion CurrentOrientation = GetCurrentOrientation();
            Vector3 EulerOrientation = CurrentOrientation.eulerAngles;

            Quaternion referenceRotation = Quaternion.identity;
            Quaternion deviceRotation = new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * GetCurrentOrientation() * new Quaternion(0, 0, 1, 0);
            Quaternion eliminationOfXY = Quaternion.Inverse(
            Quaternion.FromToRotation(referenceRotation * Vector3.forward, deviceRotation * Vector3.forward));

            Quaternion rotationZ = eliminationOfXY * deviceRotation;
            float roll = rotationZ.eulerAngles.z;*/
        }

    }
}
