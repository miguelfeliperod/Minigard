using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
