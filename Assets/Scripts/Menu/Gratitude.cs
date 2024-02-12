using UnityEngine;

public class Gratitude : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _yPosition;

    private void Start()
    {
        _yPosition = gameObject.transform.position.y;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow)) // It will be necessary to remake it for the phone
        {
            _yPosition += _speed * -2;

            gameObject.transform.position =
                new Vector3(gameObject.transform.position.x, _yPosition, gameObject.transform.position.z);
        }

        if (Input.GetKey(KeyCode.UpArrow)) // It will be necessary to remake it for the phone
        {
            _yPosition += _speed * 2;

            gameObject.transform.position =
                new Vector3(gameObject.transform.position.x, _yPosition, gameObject.transform.position.z);
        }

        else
        {
            _yPosition += _speed;

            gameObject.transform.position =
                new Vector3(gameObject.transform.position.x, _yPosition, gameObject.transform.position.z);
        }
    }
}
