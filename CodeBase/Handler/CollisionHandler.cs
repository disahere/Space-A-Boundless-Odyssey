using System;
using System.Collections.Generic;
using CodeBase.Manager;
using UnityEngine;

namespace CodeBase.Handler
{
    [RequireComponent(typeof(AudioSource))]
    public class CollisionHandler : MonoBehaviour
    {
        [Serializable]
        public class CollisionSound
        {
            public List<string> targetTags = new List<string>();
            public AudioClip collisionSound;
        }

        public List<CollisionSound> collisionSounds = new List<CollisionSound>();
        public bool destroySelf;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            foreach (CollisionSound sound in collisionSounds)
            {
                if (sound.targetTags.Contains(other.tag))
                {
                    if (sound.collisionSound != null)
                    {
                        _audioSource.PlayOneShot(sound.collisionSound);
                    }

                    if (destroySelf)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        CoinManager.Instance.CollectCoin();
                        Destroy(other.gameObject);
                    }
                    
                    break;
                }
            }
        }
    }
}