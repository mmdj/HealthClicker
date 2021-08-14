using UnityEngine;
using UnityEngine.Events;


public class HealthChanger : MonoBehaviour
{
    [SerializeField] Monster _monster;

    public int DamageVal { get; } = -10;
    public int RecoveryVal { get; } = 10;

    public UnityEvent IncreaseHealthEvent;
    public UnityEvent DecreaseHealthEvent;

    public void OnIncreaseBtnClicked()
    {
        if (_monster.CurrentHitPoints < _monster.MaxHitPoints)
        {
            IncreaseHealthEvent?.Invoke();
            _monster.CurrentHitPointsChange(RecoveryVal);
        }
    }

    public void OnDecreaseBtnClicked()
    {
        if (_monster.CurrentHitPoints > 0)
        {
            DecreaseHealthEvent.Invoke();
            _monster.CurrentHitPointsChange(DamageVal);
        }
    }
}
