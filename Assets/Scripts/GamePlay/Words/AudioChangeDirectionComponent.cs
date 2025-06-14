using System;
using SonicBloom.Koreo;
using UnityEngine;

namespace GamePlay.Words
{
    public class AudioChangeDirectionComponent : MonoBehaviour
    {
        [EventID] [SerializeField] private string _bit1;
        [EventID] [SerializeField] private string _bit2;

        public event Action OnChangeDirectionEvent;

        private void Awake()
        {
            Koreographer.Instance.RegisterForEvents(_bit1, ChangeDirectionEvent);
            Koreographer.Instance.RegisterForEvents(_bit2, ChangeDirectionEvent);
        }

        private void ChangeDirectionEvent(KoreographyEvent koreoevent) => 
            OnChangeDirectionEvent?.Invoke();
    }
}