using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsScript : MonoBehaviour {

    public static SoundEffectsScript Instance;

    public AudioClip Attack;
    public AudioClip Death;
    public AudioClip FireCasting;
    public AudioClip Splash;

    public AudioClip Press;

    public AudioClip EnemyAttack;
    public AudioClip EnemyDeath;

    public AudioClip LockingDoor;
    public AudioClip TurningHandle;

    private void Awake()
    {
        Instance = this;
    }

    public void MakeAttackSound()
    {
        MakeSound (Attack);
    }

    public void MakeDeathSound()
    {
        MakeSound(Death);
    }

    public void MakeFireCastingSound()
    {
        MakeSound(FireCasting);
    }
    
    public void MakeSplashSound()
    {
        MakeSound(Splash);
    }

    public void MakePressSound()
    {
        MakeSound(Press);
    }

    public void MakeEnemyAttackSound()
    {
        MakeSound(EnemyAttack);
    }

    public void MakeEnemyDeathSound()
    {
        MakeSound(EnemyDeath);
    }

    public void MakeLockingDoorSound()
    {
        MakeSound(LockingDoor);
    }

    public void MakeTurningHandleSound()
    {
        MakeSound(TurningHandle);
    }

    private void MakeSound (AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }

}
