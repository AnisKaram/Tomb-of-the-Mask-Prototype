using System;

public static class BinaryUtil
{
    /// <summary>
    /// Returns the attribute added it to it the flag.
    /// </summary>
    /// <param name="attribute">Value to change.</param>
    /// <param name="flag">Value to set to the attribute.</param>
    public static int SetFlag(int attribute, int flag)
    {
        return attribute |= flag;
    }

    /// <summary>
    /// Returns the attribute removed from it the flag.
    /// </summary>
    /// <param name="attribute">Value to change.</param>
    /// <param name="flag">Value to remove from the attribute.</param>
    public static int RemoveFlag(int attribute, int flag)
    {
        return attribute &= ~flag;
    }

    /// <summary>
    /// Returns if the attribute or(ed) to the value is not equal to zero.
    /// It uses the bitwise (OR) operator.
    /// </summary>
    /// <param name="attribute">Value to check on.</param>
    /// <param name="value">Value to compare to.</param>
    public static bool BitmaskOR(int attribute, int value)
    {
        return (attribute & value) != 0;
    }

    /// <summary>
    /// Returns if the attribute and(ed) to the value is equal to it.
    /// It uses the bitwise (AND) operator.
    /// </summary>
    /// <param name="attribute">Value to check on.</param>
    /// <param name="value">Value to compare to.</param>
    public static bool BitmaskAND(int attribute, int value)
    {
        return (attribute & value) == value;
    }

    /// <summary>
    /// Returns the integer shifted to the left.
    /// </summary>
    /// <param name="value">Value to shift.</param>
    /// <param name="shift">How much to shift.</param>
    public static int LeftShift(int value, int shift)
    {
        return value << shift;
    }

    /// <summary>
    /// Returns the integer shifted to the right.
    /// </summary>
    /// <param name="value">Value to shift.</param>
    /// <param name="shift">How much to shift.</param>
    public static int RightShift(int value, int shift)
    {
        return value >> shift;
    }

    /// <summary>
    /// Returns the attribute toggled.
    /// </summary>
    /// <param name="attribute">Value to toggle.</param>
    /// <param name="bit">Used to toggle.</param>
    public static int BitToggle(int attribute, int bit)
    {
        return attribute ^= bit;
    }

    /// <summary>
    /// Returns the attribute in a 32 bit format.
    /// </summary>
    /// <param name="attribute">Value to display.</param>
    public static string PrintBinary(int attribute)
    {
        return Convert.ToString(attribute, 2).PadLeft(32, '0');
    }
}