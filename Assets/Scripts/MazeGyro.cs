using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGyro : MonoBehaviour
{


    private void Start()
    {
        Input.gyro.enabled = true;//������ ������ �� ���������
    }

    private void Update()
    {
        Quaternion gyroAttitude = Input.gyro.attitude;//������ �� ������ ������ �� ���������

        gyroAttitude = InvertAxis(gyroAttitude);//���� �� ������ �����
        transform.localRotation = gyroAttitude;//����� �� ������ ������� �� �������� ������ �� ���������
    }

    private static Quaternion InvertAxis(Quaternion gyroAttitude)//���� �� ������ �� �� ��������
    {
        gyroAttitude.x *= -1;
        gyroAttitude.y *= -1;

        Vector3 rotationInEuler = gyroAttitude.eulerAngles;
        //����� �� ������ �� ���������
        float clampedX = Mathf.Clamp(rotationInEuler.x, -UIManager.Instance.clampX, UIManager.Instance.clampX);
        float clampedY = Mathf.Clamp(rotationInEuler.y, -UIManager.Instance.clampY, UIManager.Instance.clampY);
        float clampedZ = Mathf.Clamp(rotationInEuler.z, -UIManager.Instance.clampZ, UIManager.Instance.clampZ);

        return Quaternion.Euler(clampedX, clampedY, clampedZ);
    }
}