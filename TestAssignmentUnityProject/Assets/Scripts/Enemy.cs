using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    // скорость перемещения
    [Range(1f, 20f)]
    [SerializeField] private float moveSpeed = 5f; 

    // максимальное расстояние, на которое объект может переместиться
    [SerializeField] private float moveDistance = 10f; 
    

    void Start()
    {
        StartMoving();
    }

    void StartMoving()
    {
        // выбираем случайную позицию внутри радиуса moveDistance
        Vector2 targetPos = (Vector2)transform.position + Random.insideUnitCircle * moveDistance;

        // вычисляем длительность перемещения
        float duration = Vector2.Distance(transform.position, targetPos) / moveSpeed;

        // перемещаем объект к выбранной позиции и затем начинаем снова
        transform.DOMove(targetPos, duration).SetEase(Ease.Linear).OnComplete(StartMoving);            
    }

    void StopMoving()
    {
        // останавливаем все текущие анимации
        transform.DOKill(); 
    }

    void OnDestroy()
    {
        // останавливаем анимации при уничтожении объекта
        StopMoving(); 
    }
}
