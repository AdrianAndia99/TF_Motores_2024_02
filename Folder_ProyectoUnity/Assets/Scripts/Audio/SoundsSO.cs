using UnityEngine;

[CreateAssetMenu(fileName = "SoundsSO", menuName = "Sounds/SoundsSO", order = 1)]

public class SoundsSO : ScriptableObject
{
    [SerializeField] private AudioClipSO[] SoundEffects;
    public AudioClipSO[] soundEffectsAccess => SoundEffects;

    public void PlaySoundAt(int index)
    {
        if (index >= 0 && index < SoundEffects.Length)
        {
            SoundEffects[index].PlayOneShoot();
        }
        else
        {
            Debug.Log("Indice fuera de rango del arreglo de efectos de sonido.");
        }
    }
    public float GetClipLengthAt(int index)
    {
        if (index >= 0 && index < SoundEffects.Length)
        {
            return SoundEffects[index].AudioClip.length;
        }
        Debug.Log("�ndice fuera de rango al obtener la duraci�n del clip.");
        return 0f;
    }

    public void PlaySound0() 
    { 
        PlaySoundAt(0); 
    }
    public void PlaySound1() 
    { 
        PlaySoundAt(1); 
    }
    public void PlaySound2() 
    { 
        PlaySoundAt(2); 
    }
    public void PlaySound3() 
    { 
        PlaySoundAt(3); 
    }
    public void PlaySound4() 
    { 
        PlaySoundAt(4); 
    }
}