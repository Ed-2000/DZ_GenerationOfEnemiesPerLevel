using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private float _maxDistance = 15f;

    public void MoveStarter(Vector3 direction)
    {
        StartCoroutine(Move(direction.normalized));
    }

    private IEnumerator Move(Vector3 direction)
    {
        var wait = new WaitForEndOfFrame();

        while (transform.position.magnitude <= _maxDistance)
        {
            transform.Translate(direction * _speed * Time.deltaTime);
            yield return wait;
        }
    }
}