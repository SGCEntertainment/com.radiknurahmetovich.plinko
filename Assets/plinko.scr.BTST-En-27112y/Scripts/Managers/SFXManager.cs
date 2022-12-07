using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxSource;

    [Space(10)]
    [SerializeField] AudioClip clickClip;
    [SerializeField] AudioClip colidedClip;

    private void Awake()
    {
        Ball.OnCollided += (collider, _) =>
        {
            if (collider.CompareTag("Player") || collider.CompareTag("point"))
            {
                return;
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
