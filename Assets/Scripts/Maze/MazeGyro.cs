using UnityEngine;

public class MazeGyro : MonoBehaviour
{
    Gyroscope gyro;
    [SerializeField]
    float _speed = 3;
    [SerializeField] Quaternion rotationOffset;

    private Quaternion inverseGyroAttitude;

    public bool GyroIsEnabled = true;

    public void SetUpGyroscope()
    {
        gyro = Input.gyro;
        gyro.enabled = true;

        inverseGyroAttitude = Quaternion.Inverse(gyro.attitude);
        rotationOffset = transform.rotation * inverseGyroAttitude;
    }

    public void ResetGyro()
    {
        inverseGyroAttitude = Quaternion.Inverse(gyro.attitude);
        rotationOffset = transform.rotation * inverseGyroAttitude;
    }

    private void Update()
    {
        if (GameManager.Instance.GameIsPasued || GameManager.Instance.RestartGame)
        {
            return;
        }

        if (!GameManager.Instance.BallHasSpawnd)
        {
            SetUpGyroscope();
            return;
        }

        if (gyro != null)
        {
            Quaternion gyroN = gyro.attitude;

            transform.rotation = Quaternion.Lerp(transform.rotation, gyroN * rotationOffset, Time.deltaTime * _speed);
        }
    }

}