using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleInfo", menuName = "ScriptableObjects/Battle/BattleInfo")]
public class BattleInfo : ScriptableObject
{
    public List<Enemy> enemiesList;
    public Sprite background;
}
