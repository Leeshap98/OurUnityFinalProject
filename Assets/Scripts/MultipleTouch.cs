using System.Collections.Generic;
using UnityEngine;

public class MultipleTouch : MonoBehaviour
{
    [SerializeField] GameObject BallPrefab;
    public List<TouchLocation> touches = new List<TouchLocation>();

    private void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("touch began");
                touches.Add(new TouchLocation(t.fingerId, CreateBall(t)));
            }
            else if (t.phase == TouchPhase.Moved)
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
            else if (t.phase == TouchPhase.Ended)
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
            ++i;
        }
    }

    Vector3 GetTouchPosition(Vector3 touchPosition)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 10));
    }

    GameObject CreateBall(Touch t)
    {
        GameObject ball = Instantiate(BallPrefab);
        ball.name = "Touch" + t.fingerId;
        ball.transform.position = GetTouchPosition(t.position);
      
        return ball;
    }
}
