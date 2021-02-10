using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryUI : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private Player player;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Image[] images;
    [SerializeField] private Button[] buttons;

    private bool _isUIActive;
    
    private void OnEnable()
    {
        playerInventory.InventoryChanged += Refresh;
    }

    private void OnDisable()
    {
        playerInventory.InventoryChanged -= Refresh;
    }

    private void OnInventoryButtonDown()
    {
        _isUIActive = !_isUIActive;
        canvas.SetActive(_isUIActive);
        Refresh();
    }

    private void Refresh()
    {
        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }
        for (int i = 0; i < playerInventory.Count(); i++)
        {
            images[i].sprite = playerInventory[i].Icon;
            images[i].gameObject.SetActive(true);
            buttons[i].gameObject.SetActive(playerInventory[i] is Clothing);
        }
    }

    private void Update()
    {
        if (inputManager.Inventory.IsDown)
        {
            OnInventoryButtonDown();
        }
    }

    public void EquipItem(int index)
    {
        player.EquipClothing((Clothing)playerInventory[index]);
    }

    public void Close()
    {
        _isUIActive = false;
        canvas.SetActive(false);
    }
}
