using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectableList", menuName = "ScriptableObjects/Lists/CollectableList")]
public class CollectableList : ScriptableObject
{
    public List<Collectable> collectables;
}
