using UnityEngine;

public class RandoPositionScript : MonoBehaviour
{
    void Start()
    {
        var randoPositionVector = new Vector3(Random.Range(15.0f, 92.0f), Random.Range(-4.5f, 2.0f), 0.0f);
        gameObject.transform.position = randoPositionVector;
    }
}
