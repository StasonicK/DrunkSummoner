using UnityEngine;

namespace GamePlay.Words
{
    public class WordRandomRespawn : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
        }
    }
}