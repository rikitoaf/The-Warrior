using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterSoundFX : MonoBehaviour
{
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip attack_Sound_1, attack_Sound_2, die_Sound;
    // Start is called before the first frame update
    void Awake()
    {
        soundFX = GetComponent<AudioSource>();
    }

    public void Attack_1()
    {
        soundFX.clip = attack_Sound_1;
        soundFX.Play();
    }

    public void Attack_2()
    {
        soundFX.clip = attack_Sound_2;
        soundFX.Play();
    }

    public void Die()
    {
        soundFX.clip = die_Sound;
        soundFX.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
