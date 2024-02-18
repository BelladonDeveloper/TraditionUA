using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    [SerializeField]

    float distance = 2f;

    [SerializeField]

    float speed = 1f; 

    Vector3 startPos;

    public static bool IsDone;

    void Start()
    {
        ChangeStartPos();
    }

    void Update()
    {
        if (IsDone == false)
        {
            Vector3 newPosition = startPos + Vector3.up * Mathf.PingPong(Time.time * speed, distance);

            transform.position = newPosition;
        }

    }

    public void ChangeStartPos()
    {
        startPos = transform.position;
    }
}