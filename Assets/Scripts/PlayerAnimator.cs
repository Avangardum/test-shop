using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [Serializable] private struct StateNameSet
    {
        [SerializeField] public string StandLeft;
        [SerializeField] public string StandRight;
        [SerializeField] public string StandUp;
        [SerializeField] public string StandDown;
        [SerializeField] public string WalkLeft;
        [SerializeField] public string WalkRight;
        [SerializeField] public string WalkUp;
        [SerializeField] public string WalkDown;
    }

    [SerializeField] private StateNameSet blueSuitStates;
    [SerializeField] private StateNameSet greenSuitStates;
    [SerializeField] private StateNameSet redSuitStates;
    [SerializeField] private float animationSpeed = 1;

    private Animator _animator;
    private Player _player;
    private Direction _direction;
    private bool _isWalking;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
        
        _animator.speed = animationSpeed;
        _direction = _player.Direction;
        _isWalking = _player.IsWalking;
        ChangeAnimation();
    }

    private void OnEnable()
    {
        _player.DirectionChanged += OnDirectionChanged;
        _player.IsWalkingChanged += OnIsWalkingChanged;
    }

    private void OnDisable()
    {
        _player.DirectionChanged -= OnDirectionChanged;
        _player.IsWalkingChanged -= OnIsWalkingChanged;
    }

    private void OnDirectionChanged(Direction direction)
    {
        _direction = direction;
        ChangeAnimation();
    }

    private void OnIsWalkingChanged(bool isWalking)
    {
        _isWalking = isWalking;
        ChangeAnimation();
    }

    private void ChangeAnimation()
    {
        StateNameSet set = blueSuitStates;
        string stateName = string.Empty;
        if (_isWalking)
        {
            switch (_direction)
            {
                case Direction.Left:
                    stateName = set.WalkLeft;
                    break;
                case Direction.Right:
                    stateName = set.WalkRight;
                    break;
                case Direction.Up:
                    stateName = set.WalkUp;
                    break;
                case Direction.Down:
                    stateName = set.WalkDown;
                    break;
            }
        }
        else
        {
            switch (_direction)
            {
                case Direction.Left:
                    stateName = set.StandLeft;
                    break;
                case Direction.Right:
                    stateName = set.StandRight;
                    break;
                case Direction.Up:
                    stateName = set.StandUp;
                    break;
                case Direction.Down:
                    stateName = set.StandDown;
                    break;
            }
        }
        
        _animator.Play(stateName);
    }
}
