//using UnityEngine;

//public class TouchInput : MonoBehaviour
//{
//    [SerializeField]
//    private ParticleSystem particlePrefab; // Reference to the particle system prefab

//    private ParticleSystem[] particleSystems; // Array to hold the instantiated particle systems

//    private void Start()
//    {
//        particleSystems = new ParticleSystem[10]; // Initialize with a maximum of 10 touches
//    }

//    private void Update()
//    {
//        // Check for touch input
//        for (int i = 0; i < Input.touchCount; i++)
//        {
//            Touch touch = Input.GetTouch(i);

//            // Check touch phase
//            switch (touch.phase)
//            {
//                case TouchPhase.Began:
//                    Debug.Log("touch" + i + "began");
//                    // Touch started, instantiate particle system prefab
//                    ParticleSystem particleObj = Instantiate(particlePrefab, touch.position, Quaternion.identity);
//                    particleSystems[touch.fingerId] = particleObj;

//                    // Adjust array size if necessary
//                    if (touch.fingerId >= particleSystems.Length)
//                    {
//                        System.Array.Resize(ref particleSystems, touch.fingerId + 1);
//                    }

//                    // Activate the particle system
//                    particleObj.Play();
//                    break;
//                case TouchPhase.Moved:
//                    Debug.Log("touch" + i + "moved");
//                    // Touch moved, update particle system position
//                    if (particleSystems[touch.fingerId] != null)
//                    {
//                        particleSystems[touch.fingerId].transform.position = touch.position;
//                    }
//                    break;
//                case TouchPhase.Ended:
//                case TouchPhase.Canceled:
//                    Debug.Log("touch" + i + "ended or canceled");
//                    // Touch ended or canceled, destroy particle system prefab
//                    if (particleSystems[touch.fingerId] != null)
//                    {
//                        Destroy(particleSystems[touch.fingerId].gameObject);
//                        particleSystems[touch.fingerId] = null;
//                    }
//                    break;
//            }
//        }
//    }
//}


using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField]
    private GameObject objectPrefab; // Reference to the game object prefab

    private GameObject[] spawnedObjects; // Array to hold the instantiated game objects

    private void Start()
    {
        spawnedObjects = new GameObject[10]; // Initialize with a maximum of 10 touches
    }

    private void Update()
    {
        // Check for touch input
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Check touch phase
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Touch started, instantiate game object prefab
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0f; // Ensure the object is at the same z position as the camera
                    GameObject newObject = Instantiate(objectPrefab, touchPosition, Quaternion.identity);
                    spawnedObjects[touch.fingerId] = newObject;

                    // Adjust array size if necessary
                    if (touch.fingerId >= spawnedObjects.Length)
                    {
                        System.Array.Resize(ref spawnedObjects, touch.fingerId + 1);
                    }
                    break;
                case TouchPhase.Moved:
                    // Touch moved, update game object position
                    if (spawnedObjects[touch.fingerId] != null)
                    {
                        Vector3 newPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        newPosition.z = 0f; // Ensure the object is at the same z position as the camera
                        spawnedObjects[touch.fingerId].transform.position = newPosition;
                    }
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    // Touch ended or canceled, destroy game object
                    if (spawnedObjects[touch.fingerId] != null)
                    {
                        Destroy(spawnedObjects[touch.fingerId]);
                        spawnedObjects[touch.fingerId] = null;
                    }
                    break;
            }
        }
    }
}




