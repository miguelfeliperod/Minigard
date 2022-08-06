using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterPartySlot 
{
    [SerializeField] Character character;
    public Character Character { get => character; set => character = value; }
    [SerializeField] CharacterPartySlotType slotType;


}
