using UnityEngine;
using UnityEngine.Playables;

public class WeightScript : MonoBehaviour
{
    public float lifetime = 5f;

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

            // Play animation
            gameObject.GetComponent<PlayableDirector>().Play();

            //Destroy(gameObject, 2f);
        }
    }
}
