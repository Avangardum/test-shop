using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [Serializable] private struct StateNameSet
    {
        public string StandLeft;
        public string StandRight;
        public string StandUp;
        public string StandDown;
        public string WalkLeft;
        public string WalkRight;
        public string WalkUp;
        public string WalkDown;
    }

    [SerializeField] private StateNameSet blueSuitStates;
    [SerializeField] private StateNameSet greenSuitStates;
    [SerializeField] private StateNameSet redSuitStates;
    [SerializeField] private float animationSpeed = 1;

    private Animator _animator;
    private Player _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
        
        _animator.speed = animationSpeed;
        ChangeAnimation();
    }

    private void OnEnable()
    {
        _player.DirectionChanged += OnDirectionChanged;
        _player.IsWalkingChanged += OnIsWalkingChanged;
        _player.ClothingChanged += OnClothingChanged;
    }

    private void OnDisable()
    {
        _player.DirectionChanged -= OnDirectionChanged;
        _player.IsWalkingChanged -= OnIsWalkingChanged;
        _player.ClothingChanged -= OnClothingChanged;
    }

    private void OnDirectionChanged(Direction direction)
    {
        ChangeAnimation();
    }

    private void OnIsWalkingChanged(bool isWalking)
    {
        ChangeAnimation();
    }

    private void OnClothingChanged(Clothing clothing)
    {
        ChangeAnimation();
    }

    private void ChangeAnimation()
    {
        StateNameSet set = new StateNameSet();
        switch (_player.Clothing.Type)
        {
            case Clothing.ClothingType.BlueSuit:
                set = blueSuitStates;
                break;
            case Clothing.ClothingType.GreenSuit:
                set = greenSuitStates;
                break;
            case Clothing.ClothingType.RedSuit:
                set = redSuitStates;
                break;
        }
        string stateName = string.Empty;
        if (_player.IsWalking)
        {
            switch (_player.Direction)
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
            switch (_player.Direction)
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
