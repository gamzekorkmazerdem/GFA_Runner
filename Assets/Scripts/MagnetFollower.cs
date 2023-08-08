using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetFollower : MonoBehaviour
{
    [SerializeField]
    public Transform _target;

    public Transform Target
    {
        get => _target;
        set => _target = value;
    }

    [SerializeField]
    private float _speed = 8;

    private void FixedUpdate()
    {
        Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime); // ilk verilen parametreden ikinci parametreye üçüncü parametredeki hýzla ilerlemeye yarayan metot
    }

}
