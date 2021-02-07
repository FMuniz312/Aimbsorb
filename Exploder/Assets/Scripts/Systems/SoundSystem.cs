using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MunizCodeKit.Systems
{
    public class SoundSystem : MonoBehaviour
    {
        [SerializeField] private AudioClipData[] audioClipData;


        static public SoundSystem instance;
      

        private void Awake()
        {
            if (instance == null) instance = this;
        }

        public enum Sound
        {
           EnergyAbsorbed,
           PlayerHit
                 
        }

        public void PlaySound(Sound soundType)
        {
            GameObject gameObject = new GameObject("SoundEffect_", typeof(AudioSource));
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            AudioClip audioClip = GetAudioClip(soundType);
            
            audioSource.PlayOneShot(audioClip);
            Destroy(gameObject, audioClip.length);

        }

        
        AudioClip GetAudioClip(Sound sound)
        {
            foreach (AudioClipData ClipData in audioClipData)
            {
                if (ClipData.Sound == sound)
                {
                    return ClipData.AudioClip;
                }
            }
            return null;
        }





        [System.Serializable]
        public class AudioClipData
        {
            public AudioClip AudioClip;
            public Sound Sound;
        }

        private void OnDestroy()
        {
            // instance = null;
        }
    }


}