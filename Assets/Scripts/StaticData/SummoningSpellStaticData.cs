using GamePlay.SummoningSpells;
using GamePlay.Words.Movement;
using UnityEngine;
using UnityEngine.Serialization;

namespace StaticData
{
    [CreateAssetMenu(fileName = "SummoningSpellStaticData", menuName = "StaticData/SummoningSpell")]
    public class SummoningSpellStaticData : ScriptableObject
    {
        [FormerlySerializedAs("SummoningSpellId")]
        public SummonedObjectsId SummonedObjectsId;

        public WordMovement[] WordMovements;
        public int MoneyReward;
        public float FailThreshold;
        public Sprite[] Signs;
        public AudioClip[] AudioClips;
    }
}