using UnityEngine;
using DG.Tweening;

public class MoveForwardOnTrigger : MonoBehaviour
{
    public float moveDistance = 5f; // Расстояние, на которое нужно переместить объект

    private bool hasMoved = false; // Флаг, чтобы предотвратить повторное перемещение

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, вошел ли другой объект в триггер и не перемещался ли уже этот объект
        if (other.CompareTag("Player") && !hasMoved)
        {
            // Перемещаем объект вперед с помощью DOTween
            other.transform.DOMove(transform.position + -transform.forward * moveDistance, 1.0f);
            hasMoved = true; // Устанавливаем флаг перемещения
        }
    }
}
