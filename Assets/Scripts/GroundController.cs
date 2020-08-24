using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {
    // Config
    public float rotationSpeed;
    public float rotationAmount;
    public float resetSpeed;

    // References
    public Rigidbody body;

    void FixedUpdate() {
        float rotXTarget = Input.GetAxis("Vertical");
        float rotZTarget = -Input.GetAxis("Horizontal");

        if (rotXTarget > 0) body.AddTorque(new Vector3(rotationSpeed, 0, 0), ForceMode.Acceleration);
        if (rotXTarget < 0) body.AddTorque(new Vector3(-rotationSpeed, 0, 0), ForceMode.Acceleration);
        if (rotZTarget > 0) body.AddTorque(new Vector3(0, 0, rotationSpeed), ForceMode.Acceleration);
        if (rotZTarget < 0) body.AddTorque(new Vector3(0, 0, -rotationSpeed), ForceMode.Acceleration);

        float angleX =  processAngle(transform.localEulerAngles.x);
        float angleZ = processAngle(transform.localEulerAngles.z);

        if (rotXTarget == 0 && (angleX > 0 || angleX < 0)) {
            float torqueScale = (angleX / rotationAmount) * resetSpeed;
            body.AddTorque(new Vector3(-torqueScale, 0, 0), ForceMode.Acceleration);
        }

        if (rotZTarget == 0 && (angleZ > 0 || angleZ < 0)) {
            float torqueScale = (angleZ / rotationAmount) * resetSpeed;
            body.AddTorque(new Vector3(0, 0, -torqueScale), ForceMode.Acceleration);
        }

        float finalAngleX = Mathf.Clamp(angleX, -rotationAmount, rotationAmount);
        float finalAngleZ = Mathf.Clamp(angleZ, -rotationAmount, rotationAmount);
        transform.rotation = Quaternion.Euler(finalAngleX, 0, finalAngleZ);
    }

    private float processAngle(float a) {
        if (a > 180) return -(360 - a);
        return a;
    }
}
