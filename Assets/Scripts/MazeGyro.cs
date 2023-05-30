using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGyro : MonoBehaviour
{


    private void Start()
    {
        Input.gyro.enabled = true;//חייבים להפעיל את הגירוסקופ
    }

    private void Update()
    {
        Quaternion gyroAttitude = Input.gyro.attitude;//להשוות את הסיבוב לסיבוב של הגירוסקופ

        gyroAttitude = InvertAxis(gyroAttitude);//הופך את הצירים בפועל
        transform.localRotation = gyroAttitude;//משווה את הסיבוב הלוקאלי של האובייקט לסיבוב של הגירוסקופ
    }

    private static Quaternion InvertAxis(Quaternion gyroAttitude)//הופך את הצירים כי זה במינוסים
    {
        gyroAttitude.x *= -1;
        gyroAttitude.y *= -1;

        Vector3 rotationInEuler = gyroAttitude.eulerAngles;
        //מגביל את הסיבוב של הגירוסקופ
        float clampedX = Mathf.Clamp(rotationInEuler.x, -UIManager.Instance.clampX, UIManager.Instance.clampX);
        float clampedY = Mathf.Clamp(rotationInEuler.y, -UIManager.Instance.clampY, UIManager.Instance.clampY);
        float clampedZ = Mathf.Clamp(rotationInEuler.z, -UIManager.Instance.clampZ, UIManager.Instance.clampZ);

        return Quaternion.Euler(clampedX, clampedY, clampedZ);
    }
}