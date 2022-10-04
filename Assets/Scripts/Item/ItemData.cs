using UnityEngine;

public enum EItemSize
{
    BIG,
    MEDIUM,
    SMALL,
    MAX
}

public class ItemData
{
    public int Price;
    public float Weight;
    public EItemSize Size;
    public Transform OriginalPosition;
    public bool IsTarget;

    public string Name;
    public string Description;
}
