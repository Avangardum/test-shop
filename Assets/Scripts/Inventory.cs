using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IEnumerable<Item>
{
    public int Size { get; set; } = 3;
    public bool Full => _items.Count >= Size;

    private List<Item> _items;

    public IEnumerator<Item> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    public Item this[int i] => _items[i];
    
    private void Awake()
    {
        _items = new List<Item>();
    }

    public bool Remove(Item item) => _items.Remove(item);

    public void Add(Item item)
    {
        if (Full)
        {
            throw new Exception($"Tried to add {item.Name} to the inventory of {gameObject.name}, while it's full");
        }
        _items.Add(item);
    }
}
