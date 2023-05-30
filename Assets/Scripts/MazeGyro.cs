using UnityEngine;

public class MazeGyro : MonoBehaviour
{
    private Gyroscope gyro;
    private Quaternion rotationFix;
    [SerializeField] Transform worldObject;
    private float maxAngle = 30f; // this value should be adjusted based on your maze and ball
    private float smooth = 0.5f;

    public bool GyroIsEnabled = true;

    private void Start()
    {
        SetUpGyroscope();
    }

    private void SetUpGyroscope()
    {

        gyro = Input.gyro;
        gyro.enabled = GyroIsEnabled;

        GameObject camContainer = new GameObject("camContainer");
        camContainer.transform.position = transform.position;
        transform.SetParent(camContainer.transform);

        camContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        rotationFix = new Quaternion(0, 0, 1, 0);


    }

    private void Update()
    {
        RotateWorldObject();
    }

    private void RotateWorldObject()
    {
        if (worldObject != null)
        {
            Quaternion newRot = gyro.attitude * rotationFix;
            if (IsRotationAllowed(newRot))
            {
                worldObject.rotation = Quaternion.Slerp(worldObject.rotation, newRot, Time.deltaTime * smooth);
            }
        }
    }

    private bool IsRotationAllowed(Quaternion proposedRotation)
    {
        float angle = Vector3.Angle(Vector3.up, proposedRotation * Vector3.up);
        return angle < maxAngle;
    }

    public void SetWorldObject(Transform obj)
    {
        worldObject = obj;
    }
}