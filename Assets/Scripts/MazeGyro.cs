using UnityEngine;

public class MazeGyro : MonoBehaviour
{
    private Gyroscope _gyro;
    [SerializeField]
    float x = 0;
    [SerializeField]
    float y = 0;
    [SerializeField]
    float z = 0;
    [SerializeField]
    float w = 0;

    public bool GyroIsEnabled = true;
    private Quaternion deviceRotation;

    private void Start()
    {
        SetUpGyroscope();
    }

    void SetUpGyroscope() 
    {
        _gyro = Input.gyro;
        _gyro.enabled = GyroIsEnabled;
    }

    private void Update()
    {
        if (GameManager.Instance.GameIsPasued)
        {
            return;
        }

        deviceRotation = Input.gyro.attitude;
        //הופך מנקודת ציון של הגירוסקופ ליונטי

        deviceRotation = new Quaternion(deviceRotation.x, deviceRotation.y, -deviceRotation.z, -deviceRotation.w);
        deviceRotation *= new Quaternion(x, y, z, w);

        deviceRotation = Quaternion.Inverse(deviceRotation);

        //print(" X:" + deviceRotation.x + " Y:" + deviceRotation.y + " Z:" + deviceRotation.z + " W:" + deviceRotation.w);

        transform.rotation = deviceRotation;
    }

}