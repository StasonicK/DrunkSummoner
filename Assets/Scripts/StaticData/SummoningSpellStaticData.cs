﻿using GamePlay.SummoningSpells;
using GamePlay.Words.Movement;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "SummoningSpellStaticData", menuName = "StaticData/SummoningSpell")]
    public class SummoningSpellStaticData : ScriptableObject
    {
        public SummoningSpellId SummoningSpellId;
        public WordMovement[] WordMovements;
        public float FailThreshold;
    }
}