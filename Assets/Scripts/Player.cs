using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public event Action<Direction> DirectionChanged; 
    
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed = 1;

    private Rigidbody2D _rigidbody2D;
    private Direction _direction = Direction.Right;

    public Direction Direction
    {
        get => _direction;
        private set
        {
            _direction = value;
            DirectionChanged?.Invoke(value);
        }
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 velocity = Vector2.zero;
        if (inputManager.Left.IsPressed) velocity.x--;
        if (inputManager.Right.IsPressed) velocity.x++;
        if (inputManager.Up.IsPressed) velocity.y++;
        if (inputManager.Down.IsPressed) velocity.y--;
        velocity = velocity.normalized * speed;
        _rigidbody2D.velocity = velocity;
        if (velocity.x != 0)
        {
            Direction = velocity.x > 0 ? Direction.Right : Direction.Left;
        }
        else if (velocity.y != 0)
        {
            Direction = velocity.y > 0 ? Direction.Up : Direction.Down;
        }
    }
}
