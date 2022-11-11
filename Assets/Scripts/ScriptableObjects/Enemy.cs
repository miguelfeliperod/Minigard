using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Battle/Enemy")]
public class Enemy : Battler
{
    public override Battler GetRandomTarget()
    {
        return BattleManager.Instance.GetRandomCharacter();
    }
    [SerializeField] TargetPattern pattern;
    [SerializeField] TargetTeam targetTeam;
    [SerializeField] int range;
    [SerializeField] int maxQuantity;
    [SerializeField] Element element;
    [SerializeField] StatusAilment statusAilment;

    public override bool HasSubWeapon() => false;

    public override void ExecuteBasicAttack(List<Battler> charactersList, List<Battler> enemyList, bool isSubWeapon = false)
    {
        Action damage = new();

        List<Battler> targets = DetermineActionTargets(charactersList, enemyList, pattern, targetTeam, range, maxQuantity);
        damage.isCritical = SetDamageIsCritical();
        damage.type = DamageType.Physical;
        damage.element = element;
        damage.statusAilment = statusAilment;
        damage.statusAilmentChance = GetStatusAilmentAffinityModifier(statusAilment);

        damage.value = SetBasicAttackDamage(damage);

        if (damage.isCritical)
        {
            damage.value *= GetCriticalDamageMultiplier();
        }
        foreach (Battler battler in targets)
        {
            battler.ReceiveAction(damage);
        }
    }

    public override void ExecuteFirstSkill(List<Battler> charactersList, List<Battler> monstersList)
    {
        throw new System.NotImplementedException();
    }

    public override void ExecuteSecondSkill(List<Battler> charactersList, List<Battler> monstersList)
    {
        throw new System.NotImplementedException();
    }

    public override int SetBasicAttackDamage(Action damage, HandEquipment weapon = null)
    {
        int totalDamage = GetBaseDamageValue(DamageType.Physical);
        return (int)(totalDamage * totalDamage
        * (1 + GetElementAffinityModifier(damage.element)));
    }
}
