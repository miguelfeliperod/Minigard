using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Battle/Enemy")]
public class Enemy : Battler
{
    protected override Battler GetRandomTarget()
    {
        return BattleManager.Instance.GetRandomCharacter();
    }

    void Start()
    {
        InitStats();
    }
}
