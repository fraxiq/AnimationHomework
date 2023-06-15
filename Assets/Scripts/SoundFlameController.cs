using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFlameController : MonoBehaviour
{
    private ParticleSystem flame;
    private AudioSource Burn;
    private float maxVolume = 0.5f;
    private void Start()
    {
        flame = GetComponent<ParticleSystem>();
        Burn = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (flame.emission.enabled)
        {
            if (!Burn.isPlaying)
            {
                Burn.Play();
            }
            Burn.volume = Mathf.MoveTowards(Burn.volume, maxVolume, Burn.volume * Time.deltaTime);
        }
        else
        {
            Burn.volume -= Burn.volume * Time.deltaTime;
            if (Burn.volume<=0)
            {
                Burn.Stop();
            }
        }
    }
}
