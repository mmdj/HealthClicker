using UnityEngine;
using TMPro;

[RequireComponent (typeof(Animator))]

public class MonsterAnimator : MonoBehaviour
{
    [SerializeField] TMP_Text _healthText;
    [SerializeField] HealthChanger _healthChanger;

    public enum MonsterAnimatorCondition
    {
        Damaged,
        Healed,
        Dead
    }

    public enum MonsterAnimationName
    {
        MonsterHealed,
        MonsterDamaged,
        MonsterDead,
        Idle
    }

    public bool IsMonsterAnimating { get; set; } = false;

    private Animator _animator = null;
    private Vector3 _healthTextStartPosition = Vector3.zero;
    private const float _textUpSpeed = 1.0f;

    private void Start()
    {
        if (TryGetComponent(out Animator animator))
        {
            _animator = animator;
        }
        _healthText.color = Color.clear;
        _healthTextStartPosition = _healthText.transform.localPosition;
    }

    private void Update()
    {
        if (IsMonsterAnimating)
        {
            _healthText.transform.position = Vector3.MoveTowards(_healthText.transform.position
                , _healthText.transform.position + Vector3.up, _textUpSpeed * Time.deltaTime);
        }
        else if (_healthText.transform.position != _healthTextStartPosition)
        {
            _healthText.transform.localPosition = _healthTextStartPosition;
            _healthText.enabled = false;
        }
    }

    public void OnMonsterDamaged()
    {
        if (_animator != null)
            _animator.SetBool(nameof(MonsterAnimatorCondition.Damaged), true);

        _healthText.SetText(_healthChanger.DamageVal.ToString());
        _healthText.enabled = true;
        IsMonsterAnimating = true;
    }
        
    public void OnMonsterHealed()
    {
        if (_animator != null)
        {
            _animator.SetBool(nameof(MonsterAnimatorCondition.Healed), true);

            if (_animator.GetBool(nameof(MonsterAnimatorCondition.Dead)))
                _animator.SetBool(nameof(MonsterAnimatorCondition.Dead), false);
        }

        _healthText.SetText("+" + _healthChanger.RecoveryVal);
        _healthText.enabled = true;
        IsMonsterAnimating = true;
    }

    public void OnMonsterDead()
    {
        if (_animator != null)
            _animator.SetBool(nameof(MonsterAnimatorCondition.Dead), true);
    }
}
