namespace OpenTui.Runtime;

public class ColorInput
{
    public string? StringValue { get; }
    public RGBA? RgbaValue { get; }

    private ColorInput(string? str, RGBA? rgba)
    {
        StringValue = str;
        RgbaValue = rgba;
    }

    public static implicit operator ColorInput(string color) => new(color, null);
    public static implicit operator ColorInput(RGBA rgba) => new(null, rgba);

    public override string ToString() => StringValue ?? RgbaValue?.ToString() ?? "transparent";
}

public readonly struct RGBA : IEquatable<RGBA>
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }
    public byte A { get; }

    public RGBA(byte r, byte g, byte b, byte a = 255)
    {
        R = r; G = g; B = b; A = a;
    }

    public bool Equals(RGBA other) => R == other.R && G == other.G && B == other.B && A == other.A;
    public override bool Equals(object? obj) => obj is RGBA other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(R, G, B, A);
    public static bool operator ==(RGBA left, RGBA right) => left.Equals(right);
    public static bool operator !=(RGBA left, RGBA right) => !left.Equals(right);
    public override string ToString() => A == 255 ? $"#{R:X2}{G:X2}{B:X2}" : $"#{R:X2}{G:X2}{B:X2}{A:X2}";
}
