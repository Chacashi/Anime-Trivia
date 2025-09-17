using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void playAudio(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void playAudio(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
    public void PlaySFX(int index)
    {
        audioSource.PlayOneShot(audioClips[index]);
    }
}
