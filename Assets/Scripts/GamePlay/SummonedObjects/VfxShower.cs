using UnityEngine;

namespace GamePlay.SummonedObjects
{
    public class VfxShower : MonoBehaviour
    {
        [SerializeField] private GameObject _dustVfx;
        [SerializeField] private GameObject _fireworkVfx;
        [SerializeField] private ParticleSystem _dustVfxParticleSystem;
        [SerializeField] private ParticleSystem _fireworkVfxParticleSystem;

        private void OnEnable()
        {
            // _dustVfxParticleSystem.Play();
            // _fireworkVfxParticleSystem.Play();
            _dustVfx.gameObject.SetActive(true);
            _fireworkVfx.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            // _dustVfxParticleSystem.Play();
            // _fireworkVfxParticleSystem.Play();
            _dustVfx.gameObject.SetActive(false);
            _fireworkVfx.gameObject.SetActive(false);
        }
    }
}