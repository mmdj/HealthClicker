using UnityEngine;

public class AnimationEnder : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName(nameof(MonsterAnimator.MonsterAnimationName.MonsterHealed)))
        {
            animator.SetBool(nameof(MonsterAnimator.MonsterAnimatorCondition.Healed), false);
        }
        else if (stateInfo.IsName(nameof(MonsterAnimator.MonsterAnimationName.MonsterDamaged)))
        {
            animator.SetBool(nameof(MonsterAnimator.MonsterAnimatorCondition.Damaged), false);
        }

        if (animator.gameObject.TryGetComponent(out MonsterAnimator monsterAnimator))
        {
            monsterAnimator.IsMonsterAnimating = false;
        }

    }  
}
