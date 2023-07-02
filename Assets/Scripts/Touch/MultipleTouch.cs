using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MultipleTouch : MonoBehaviour
{
    [FormerlySerializedAs("BallPrefab")]
    [SerializeField] GameObject particlePrefab;
    public List<TouchLocation> touches = new List<TouchLocation>();

    private void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                BeganLogic(t);
            }
            else if (t.phase == TouchPhase.Moved)
            {
                MovedLogic(t);
            }
            else if (t.phase == TouchPhase.Ended)
            {
                EndedLogic(t);
            }
            ++i;
        }
    }

    private void EndedLogic(Touch t)
    {
        Debug.Log("ended");
        TouchLocation thisTouch = touches.Find(TouchLocation => TouchLocation.touchId == t.fingerId);

        if (thisTouch != null)
        {
            Destroy(thisTouch.Ball);
            touches.Remove(thisTouch);
        }
        else
        {
            Debug.LogWarning("Touch ID not found in list: " + t.fingerId);
        }
    }

    private void MovedLogic(Touch t)
    {
        Debug.Log("moved");
        TouchLocation thisTouch = touches.Find(TouchLocation => TouchLocation.touchId == t.fingerId);

        if (thisTouch != null)
        {
            thisTouch.Ball.transform.position = GetTouchPosition(t.position);
        }
        else
        {
            Debug.LogWarning("Touch ID not found in list: " + t.fingerId);
        }
    }

    private void BeganLogic(Touch t)
    {
        Debug.Log("touch began");
        touches.Add(new TouchLocation(t.fingerId, CreateParticles(t)));
    }

    Vector3 GetTouchPosition(Vector3 touchPosition)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 10));
    }

    GameObject CreateParticles(Touch t)
    {
        if (particlePrefab)
        {
            GameObject particle = Instantiate(particlePrefab);
            particle.name = "Touch" + t.fingerId;
            particle.transform.position = GetTouchPosition(t.position);

            return particle;
        }

        return null;
    }
}
