public class Trial
{
    private bool vibration;
    private float direction;
    private float gain;

    public Trial(bool vib, float dir, float g)
    {
        vibration = vib;
        direction = dir;
        gain = g;
    }

    public bool GetVib()
    {
        return vibration;
    }

    public float GetDir()
    {
        return direction;
    }

    public float GetG()
    {
        return gain;
    }
}
