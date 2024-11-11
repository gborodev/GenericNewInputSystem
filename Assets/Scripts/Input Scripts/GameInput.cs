using System;
using System.Collections.Generic;

public static class GameInput
{
    private static InputManager input;

    static GameInput()
    {
        if (input == null)
        {
            input = InputManager.Instance;
            keys = new List<Keys>();
        }
    }

    private static float _vertical;
    private static float _horizontal;

    private static List<Keys> keys;

    public static void SetAxis(AxisType axisType, float value)
    {
        switch (axisType)
        {
            case AxisType.Vertical:
                _vertical = value;
                break;
            case AxisType.Horizontal:
                _horizontal = value;
                break;
            default:
                _vertical = 0;
                _horizontal = 0;
                break;
        }
    }
    public static float GetAxis(AxisType axisType)
    {
        switch (axisType)
        {
            case AxisType.Vertical:
                return _vertical;
            case AxisType.Horizontal:
                return _horizontal;
            default:
                return 0;
        }
    }

    public static void AddKey(string key)
    {
        KeyType? currentKey = HasKey(key);

        if (currentKey != null)
        {
            keys.Add(new Keys(currentKey.Value));
            keys[^1].Pressed = true;
        }
    }
    public static void RemoveKey(string key)
    {
        KeyType? currentKey = HasKey(key);

        for (int i = 0; i < keys.Count; i++)
        {
            if (keys[i].Key == currentKey)
            {
                keys[i].Pressed = false;
            }
        }
    }

    public static bool GetKeyDown(KeyType key)
    {
        foreach (Keys k in keys)
        {
            if (k.Key == key)
            {
                if (k.Pressed is false)
                {
                    k.Pressed = true;

                    return true;
                }
            }
        }

        return false;
    }
    public static bool GetKey(KeyType key)
    {
        foreach (Keys k in keys)
        {
            if (k.Key == key)
            {
                return true;
            }
        }

        return false;
    }
    public static bool GetKeyUp(KeyType key)
    {
        for (int i = 0; i < keys.Count; i++)
        {
            if (keys[i].Key == key)
            {
                keys.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    private static KeyType? HasKey(string key)
    {
        Array keys = Enum.GetValues(typeof(KeyType));

        foreach (var k in keys)
        {
            if (k.ToString().ToUpper() == key)
            {
                return (KeyType)k;
            }
        }

        return null;
    }
}

public enum AxisType
{
    Vertical, Horizontal
}

