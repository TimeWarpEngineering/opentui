namespace OpenTui.Runtime;

public readonly struct DimensionValue : IEquatable<DimensionValue>
{
    public enum DimensionKind { Pixels, Auto, Percent }

    public DimensionKind Kind { get; }
    public double Value { get; }

    private DimensionValue(DimensionKind kind, double value = 0)
    {
        Kind = kind;
        Value = value;
    }

    public static DimensionValue Pixels(double value) => new(DimensionKind.Pixels, value);
    public static DimensionValue Auto() => new(DimensionKind.Auto);
    public static DimensionValue Percent(double value) => new(DimensionKind.Percent, value);

    public static implicit operator DimensionValue(int pixels) => Pixels(pixels);
    public static implicit operator DimensionValue(double pixels) => Pixels(pixels);

    public static DimensionValue Parse(string value)
    {
        if (value == "auto") return Auto();
        if (value.EndsWith('%') && double.TryParse(value.AsSpan(0, value.Length - 1), out var pct))
            return Percent(pct);
        if (double.TryParse(value, out var px))
            return Pixels(px);
        throw new FormatException($"Cannot parse '{value}' as DimensionValue");
    }

    public bool Equals(DimensionValue other) => Kind == other.Kind && Value.Equals(other.Value);
    public override bool Equals(object? obj) => obj is DimensionValue other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(Kind, Value);
    public static bool operator ==(DimensionValue left, DimensionValue right) => left.Equals(right);
    public static bool operator !=(DimensionValue left, DimensionValue right) => !left.Equals(right);

    public override string ToString() => Kind switch
    {
        DimensionKind.Auto => "auto",
        DimensionKind.Percent => $"{Value}%",
        _ => Value.ToString(),
    };
}
