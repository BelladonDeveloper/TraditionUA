using UnityEngine;
using UnityEngine.UI;

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
        _yPosition += _speed;

        gameObject.transform.position =
            new Vector3(gameObject.transform.position.x, _yPosition, gameObject.transform.position.z);
    }

    //public void ScrollUp()
    //{
    //    _yPosition += _speed * -2;

    //    gameObject.transform.position =
    //        new Vector3(gameObject.transform.position.x, _yPosition, gameObject.transform.position.z);
    //}

    //public void ScrollDown()
    //{
    //    _yPosition += _speed * 2;

    //    gameObject.transform.position =
    //        new Vector3(gameObject.transform.position.x, _yPosition, gameObject.transform.position.z);
    //}
}
