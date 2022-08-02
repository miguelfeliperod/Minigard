using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClassesList", menuName = "ScriptableObjects/Lists/ClassesList")]
public class ClassesList : ScriptableObject
{
    public List<FirstClass> firstClassList;
    public List<SecondClass> secondClassList;
    public List<ThirdClass> thirdClassList;
}
