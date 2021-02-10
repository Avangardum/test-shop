using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Button _left;
    private Button _up;
    private Button _right;
    private Button _down;
    private Button _use;
    private Button _inventory;

    public struct Button
    {
        public bool IsPressed;
        public bool IsDown;
        public bool IsUp;
    }

    public Button Left => _left;

    public Button Right => _right;

    public Button Up => _up;

    public Button Down => _down;

    public Button Use => _use;

    public Button Inventory => _inventory;

    private void Update()
    {
        SetButtonData(ref _left, KeyCode.LeftArrow);
        SetButtonData(ref _right, KeyCode.RightArrow);
        SetButtonData(ref _down, KeyCode.DownArrow);
        SetButtonData(ref _up, KeyCode.UpArrow);
        SetButtonData(ref _use, KeyCode.Space);
        SetButtonData(ref _inventory, KeyCode.I);
    }

    private void SetButtonData(ref Button button, KeyCode keyCode)
    {
        button.IsPressed = Input.GetKey(keyCode);
        button.IsDown = Input.GetKeyDown(keyCode);
        button.IsUp = Input.GetKeyUp(keyCode);
    }
}
