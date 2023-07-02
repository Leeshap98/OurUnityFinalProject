using UnityEngine;

public class MazeGyro : MonoBehaviour
{
    Gyroscope gyro;
    [SerializeField] float _speed = 3;
    Quaternion rotationOffset = Quaternion.identity;

    private Quaternion GyroAttitude;

    public bool GyroIsEnabled = true;

    public void SetUpGyroscope()
    {
        
        gyro = Input.gyro;
        gyro.enabled = true;

        ResetGyro();
    }

    public void ResetGyro()
    {
        GyroAttitude = gyro.attitude;
        rotationOffset = transform.rotation * GyroAttitude;
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
            Quaternion gyroN = Quaternion.Inverse(gyro.attitude);
            

            transform.rotation = Quaternion.Lerp(transform.rotation, gyroN * rotationOffset, Time.deltaTime * _speed);
        }
    }

}