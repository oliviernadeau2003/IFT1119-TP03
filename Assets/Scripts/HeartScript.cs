using UnityEngine;
using UnityEngine.Playables;

public class HeartScript : MonoBehaviour
{
    public float lifetime = 5f;
    public PlayableAsset timeline2;

    void Start()
    {
        // Lifetime
        Destroy(gameObject, lifetime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Rigidbody2D>().simulated = false;

            // Play second animation
            gameObject.GetComponent<PlayableDirector>().Play(timeline2,DirectorWrapMode.Hold);

            Destroy(gameObject, 2f);
        }
    }

}
