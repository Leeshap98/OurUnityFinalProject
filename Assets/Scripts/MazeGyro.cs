using UnityEngine;

public class MazeGyro : MonoBehaviour
{
    Gyroscope gyro;

    [SerializeField] Quaternion rotationOffset;

    private Quaternion inverseGyroAttitude;

    public bool GyroIsEnabled = true;


    private void Start()
    {
        SetUpGyroscope();
    }

    public void SetUpGyroscope()
    {
        gyro = Input.gyro;
        gyro.enabled = GyroIsEnabled;

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

        print("Attitude" + gyro.attitude);
        print("Inversed Attitude" + Quaternion.Inverse(gyro.attitude));

        Quaternion gyroN = gyro.attitude;

        transform.rotation = gyroN * rotationOffset;

    }

}