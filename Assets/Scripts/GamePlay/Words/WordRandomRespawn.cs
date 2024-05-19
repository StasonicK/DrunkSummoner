using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay.Words
{
    public class WordRandomRespawn : MonoBehaviour
    {
        private const float Z_POSITION = 0.0f;
        private const float X_EDGE = 0.47f;
        private const float Y_EDGE = 0.25f;

        private float _xPosition;
        private float _yPosition;

        public void SetNewPosition()
        {
            _xPosition = Random.Range(-X_EDGE, X_EDGE);
            _yPosition = Random.Range(-Y_EDGE, Y_EDGE);
            transform.localPosition = new Vector3(_xPosition, _yPosition, Z_POSITION);
            gameObject.SetActive(true);
        }
    }
}