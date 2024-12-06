using UnityEngine;

public class AccessoriesManagerScript : MonoBehaviour
{

    // Heart
    public GameObject heart;
    public int nbHeart;
    public float intervalHeartSpawn;

    //Bomb
    public GameObject bomb;
    public int nbBomb;

    // Weight
    public GameObject weight;
    public int nbWeight;
    public float intervalWeightSpawn;

    // Limits
    public Transform MapLimiterTopLeft;
    public Transform MapLimiterBottomRight;

    void Start()
    {
        // Bomb
        for (int i = 0; i < nbBomb; i++)
        {
            // Random Position
            float x = Random.Range(MapLimiterTopLeft.position.x, MapLimiterBottomRight.position.x);
            float y = Random.Range(MapLimiterTopLeft.position.y, MapLimiterBottomRight.position.y);
            // Object Creation
            Instantiate(
                    bomb,
                    new Vector2(x, y),
                    Quaternion.identity,
                    gameObject.transform
                );
        }
        // Weight
        InvokeRepeating(nameof(CreateWeight), intervalWeightSpawn, intervalWeightSpawn);

        // Heart
        InvokeRepeating(nameof(CreateHeart), intervalHeartSpawn, intervalHeartSpawn);

    }

    void CreateWeight()
    {
        for (int i = 0; i < nbWeight; i++)
        {
            // Random Position
            float x = Random.Range(MapLimiterTopLeft.position.x, MapLimiterBottomRight.position.x);
            float y = MapLimiterTopLeft.position.y;
            // Object Creation
            Instantiate(
                    weight,
                    new Vector2(x, y),
                    Quaternion.identity,
                    gameObject.transform
                );
        }
    }

    void CreateHeart()
    {
        for (int i = 0; i < nbHeart; i++)
        {
            // Random Position
            float x = Random.Range(MapLimiterTopLeft.position.x, MapLimiterBottomRight.position.x);
            float y = MapLimiterTopLeft.position.y;
            // Object Creation
            Instantiate(
                    heart,
                    new Vector2(x, y),
                    Quaternion.identity,
                    gameObject.transform
                );
        }
    }
}
