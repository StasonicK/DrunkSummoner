using GamePlay.SummoningSpells;
using UnityEngine;

namespace GamePlay.SummonedObjects
{
    public class Summoner : MonoBehaviour
    {
        [SerializeField] private GameObject _shovel;
        [SerializeField] private GameObject _chicken;
        [SerializeField] private GameObject _potatoBag;

        private static Summoner _instance;

        private Vector3 _shovelStartPosition = Vector3.zero;
        private Vector3 _chickenStartPosition = Vector3.zero;
        private Vector3 _potatoBagStartPosition = Vector3.zero;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _shovelStartPosition = _shovel.transform.position;
            _chickenStartPosition = _chicken.transform.position;
            _potatoBagStartPosition = _potatoBag.transform.position;
        }

        private void OnEnable() =>
            OffAll();

        public static Summoner Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<Summoner>();

                return _instance;
            }
        }

        public void OffAll()
        {
            _shovel.gameObject.SetActive(false);
            _chicken.gameObject.SetActive(false);
            _potatoBag.gameObject.SetActive(false);
        }

        public void Summon(SummonedObjectsId summonedObjectId)
        {
            switch (summonedObjectId)
            {
                case SummonedObjectsId.PotatoBag:
                    _potatoBag.transform.position = _potatoBagStartPosition;
                    _potatoBag.gameObject.SetActive(true);
                    break;
                case SummonedObjectsId.Chicken:
                    _chicken.transform.position = _chickenStartPosition;
                    _chicken.gameObject.SetActive(true);
                    break;
                case SummonedObjectsId.Shovel:
                    _shovel.transform.position = _shovelStartPosition;
                    _shovel.gameObject.SetActive(true);
                    break;
            }
        }
    }
}