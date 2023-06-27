using UnityEngine;

public class MazeGyro : MonoBehaviour
{
    public bool GyroIsEnabled = true;

    [SerializeField] float speed = 3;
    [SerializeField] Quaternion rotationOffset;

    private Quaternion inverseGyroAttitude;

    Gyroscope gyro;


    public void SetUpGyroscope()
    {
        
        gyro = Input.gyro;
        gyro.enabled = true;

        ResetGyro();
    }

    public void ResetGyro()
    {
        inverseGyroAttitude = gyro.attitude;
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
            Quaternion gyroN = Quaternion.Inverse(gyro.attitude);
            

            transform.rotation = Quaternion.Lerp(transform.rotation, gyroN * rotationOffset, Time.deltaTime * speed);
        }
    }

}