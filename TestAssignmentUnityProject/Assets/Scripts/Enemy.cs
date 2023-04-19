using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    // скорость перемещения
    [Range(1f, 20f)]
    [SerializeField] private float moveSpeed = 5f; 

    // максимальное расстояние, на которое объект может переместиться
    [SerializeField] private float moveDistance = 10f; 

    [Tooltip("Предельные значения координат области перемещения врагов")]
    [Range(1f, 30f)]
    [SerializeField] private float maxX = 28f;

    [Range(1f, 30f)]
    [SerializeField] private float maxY = 28f;

    [Range(-1f, -30f)]
    [SerializeField] private float minX = -28f;

    [Range(-1f, -30f)]
    [SerializeField] private float minY = -28f;

    

    void Start()
    {
        StartMoving();
    }

    void StartMoving()
    {
        // выбираем случайную позицию внутри радиуса moveDistance
        Vector2 targetPos = (Vector2)transform.position + Random.insideUnitCircle * moveDistance;

        // ограничиваем координаты x и y в заданном диапазоне
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

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
