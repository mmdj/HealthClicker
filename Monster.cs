using UnityEngine;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    public UnityEvent MonsterDeadEvent;
    public int CurrentHitPoints { get; private set; } = 100;
    public int MaxHitPoints { get; } = 100;

    public void CurrentHitPointsChange(int value)
    {
        if ((CurrentHitPoints <= 0 && value < 0) || (CurrentHitPoints >= MaxHitPoints && value > 0))
            return;

        CurrentHitPoints += value;

        if (CurrentHitPoints == 0)
            MonsterDeadEvent.Invoke();
    }

}
