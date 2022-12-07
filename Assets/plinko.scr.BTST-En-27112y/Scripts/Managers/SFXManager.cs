using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxSource;

    [Space(10)]
    [SerializeField] AudioClip clickClip;
    [SerializeField] AudioClip hitClip;
    [SerializeField] AudioClip colidedClip;

    private void Awake()
    {
        Ball.OnCollided += (collider, _) =>
        {
            if (collider.CompareTag("Player"))
            {
                return;
            }
            else if(collider.CompareTag("point"))
            {
                if (sfxSource.isPlaying)
                {
                    sfxSource.Stop();
                }

                sfxSource.PlayOneShot(hitClip);
            }
            else
            {
                if (sfxSource.isPlaying)
                {
                    sfxSource.Stop();
                }

                sfxSource.PlayOneShot(colidedClip);
            }
        };
    }
}
