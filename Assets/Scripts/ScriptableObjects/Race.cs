using UnityEngine;

[CreateAssetMenu(fileName = "Race", menuName = "ScriptableObjects/Race")]

public class Race : ScriptableObject
{
    [SerializeField] string raceName;
    [SerializeField] RaceType race;
    public RaceType RaceType { get => race; }

    [SerializeField] Passive passive;


    [SerializeField] Color bodyColor1;
    [SerializeField] Color bodyColor2;
    [SerializeField] Color bodyColor3;

    public Color GetRandomBodyColor()
    {
        switch(Random.Range(0, 3)) {
            case 0:
                return bodyColor1;
            case 1:
                return bodyColor2;
            default:
                return bodyColor3;
        }
    }
}
