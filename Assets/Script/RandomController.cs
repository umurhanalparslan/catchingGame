using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomController : MonoBehaviour
{
    public static RandomController instance;

    public bool isActiveSpawn = true;

    [SerializeField] GameObject[] fruitPrefab;

    public float secondSpawn;

    [SerializeField] float minTras;

    [SerializeField] float maxTras;
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(FruitSpawn());

    }
    IEnumerator FruitSpawn()
    {

        if (isActiveSpawn == true)
        {
            while (true)
            {
                var wanted = Random.Range(minTras, maxTras);
                var position = new Vector3(wanted, transform.position.y);
                GameObject gameObject = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)], position, Quaternion.identity);
                yield return new WaitForSeconds(secondSpawn);
                Destroy(gameObject, 5f);

            }
        }
        
    }


    

    

}
