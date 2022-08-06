using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PartyManager 
{
    [SerializeField] List<CharacterPartySlot> partyList = new List<CharacterPartySlot>(5);
    public List<CharacterPartySlot> PartyList { get => partyList; set => partyList = value; }

    public int CountActiveCharacters { get {
            int count = 0;
            count = FrontSlot.Character == null ? count :  count + 1; 
            count = MidFrontSlot.Character == null ? count : count + 1;
            count = MidSlot.Character == null ? count : count + 1;
            count = MidBackSlot.Character == null ? count : count + 1;
            count = BackSlot.Character == null ? count : count + 1;
            return count;
        } 
    }

    public CharacterPartySlot FrontSlot { get => partyList[0]; set => partyList[0] = value; }
    public CharacterPartySlot MidFrontSlot { get => partyList[1]; set => partyList[1] = value; }
    public CharacterPartySlot MidSlot { get => partyList[2]; set => partyList[2] = value; }
    public CharacterPartySlot MidBackSlot { get => partyList[3]; set => partyList[3] = value; }
    public CharacterPartySlot BackSlot { get => partyList[4]; set => partyList[4] = value; }


    [SerializeField] private List<Character> recruitedList = new List<Character>();
    public List<Character> RecruitedList => recruitedList;

    [Range(1, 5)]
    [SerializeField] private int currentPartySizeLimit = 3;
    public int CurrentPartySizeLimit { get => currentPartySizeLimit; set => currentPartySizeLimit = value; }

     public bool IsPartyEmpty
    {
        get => FrontSlot.Character == null && 
            MidFrontSlot.Character == null && 
            MidSlot.Character == null && 
            MidBackSlot.Character == null && 
            BackSlot.Character == null;
    }
}

