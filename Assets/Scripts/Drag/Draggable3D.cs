using UnityEngine;

public class Draggable3D : MonoBehaviour
{
    private Vector3 offset;
    private bool dragging;
    private Camera cam;
    [SerializeField] Rigidbody rb;
    private float zCoordinate;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            UnityEngine.Touch touch = Input.GetTouch(0);

            Ray ray = cam.ScreenPointToRay(touch.position);
            RaycastHit hit;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                    {
                        dragging = true;
                        rb.isKinematic = true;
                        zCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                        // Store offset = gameobject world pos - mouse world pos
                        offset = gameObject.transform.position - GetMouseWorldPos();
                    }
                    break;

                case TouchPhase.Moved:
                    if (dragging)
                    {
                        // Update object position based on mouse position + offset
                        transform.position = GetMouseWorldPos() + offset;
                    }
                    break;

                case TouchPhase.Ended:
                    if (dragging)
                    {
                        dragging = false;
                        rb.isKinematic = false;
                    }
                    break;
            }
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        // Pixel coordinates (x,y)
        Vector3 mousePoint = Input.GetTouch(0).position;

        // z coordinate of game object on screen
        mousePoint.z = zCoordinate;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}