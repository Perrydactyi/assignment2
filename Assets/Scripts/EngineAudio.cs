using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EngineAudio : MonoBehaviour
{
    public AudioClip mainEngine;

    private float pitchIncrease = 0.5f;
    private float pitchDecrease = 0.6f;
    private float maxPitch = 1.8f;
    private float minPitch = 0.7f;
    private float accelerationInputThreshold = 0.1f;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = mainEngine;
        audio.loop = true;
        audio.pitch = minPitch;
        audio.Play();
        audio.volume = .15f;
    }

    void Update()
    {
        float accelInput = Input.GetAxis("Vertical");

        if (accelInput > accelerationInputThreshold)
        {
            audio.pitch += pitchIncrease * Time.deltaTime;
        }
        else
        {
            audio.pitch -= pitchDecrease * Time.deltaTime;
        }

        audio.pitch = Mathf.Clamp(audio.pitch, minPitch, maxPitch);
    }
}
