using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransfform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransfform.position, Quaternion.identity);

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        float clipLenghth = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLenghth);
    }

}
