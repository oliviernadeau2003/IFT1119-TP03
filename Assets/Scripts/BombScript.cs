using UnityEngine;
using UnityEngine.Playables;

public class BombScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Start Animation
            gameObject.GetComponent<PlayableDirector>().Play();
            // Destruction
            Destroy(gameObject, 1f);
        }
    }
}
