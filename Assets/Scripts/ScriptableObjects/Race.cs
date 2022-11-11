using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Race", menuName = "ScriptableObjects/Race")]

public class Race : ScriptableObject
{
    [SerializeField] string raceName;
    [SerializeField] RaceType race;
    public RaceType RaceType { get => race; }

    [SerializeField] Passive passive;

    [SerializeField] List<Color> bodyColorList;
    [SerializeField] List<Color> eyeColorList;
    [SerializeField] List<Color> hairColorList;
    [SerializeField] Color eyeBackColor;

    [SerializeField] List<Sprite> maleBodyList;
    [SerializeField] List<Sprite> maleHairList;
    [SerializeField] List<Sprite> maleEyesList;
    [SerializeField] List<Sprite> femaleBodyList;
    [SerializeField] List<Sprite> femaleHairList;
    [SerializeField] List<Sprite> femaleEyesList;
    [SerializeField] List<Sprite> bottonDressList;
    [SerializeField] List<Sprite> underDressListairList;
    [SerializeField] List<Sprite> topDressList;
    [SerializeField] List<Sprite> footDressList;


    public Color GetRandomBodyColor() => bodyColorList[Random.Range(0,bodyColorList.Count)];
    public Color GetRandomEyeColor() => eyeColorList[Random.Range(0, eyeColorList.Count)];
    public Color GetRandomHairColor() => hairColorList[Random.Range(0, hairColorList.Count)];
    public Color GetEyeBackColor() => eyeBackColor;



    public Texture2D GetRandomMaleBody() => maleBodyList[Random.Range(0, maleBodyList.Count)].texture;
    public Texture2D GetRandomMaleHair() => maleHairList[Random.Range(0, maleHairList.Count)].texture;
    public Texture2D GetRandomMaleEyes() => maleEyesList[Random.Range(0, maleEyesList.Count)].texture;
    public Texture2D GetRandomFemaleBody() => femaleBodyList[Random.Range(0, femaleBodyList.Count)].texture;
    public Texture2D GetRandomFemaleHair() => femaleHairList[Random.Range(0, femaleHairList.Count)].texture;
    public Texture2D GetRandomFemaleEyes() => femaleEyesList[Random.Range(0, femaleEyesList.Count)].texture;
    public Texture2D GetRandomBottomDress() => bottonDressList[Random.Range(0, bottonDressList.Count)].texture;
    public Texture2D GetRandomUnderDress() => underDressListairList[Random.Range(0, underDressListairList.Count)].texture;
    public Texture2D GetRandomTopDress() => topDressList[Random.Range(0, topDressList.Count)].texture;
    public Texture2D GetRandomFootDress() => footDressList[Random.Range(0, footDressList.Count)].texture;

}
