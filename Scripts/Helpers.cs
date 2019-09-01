// helper class
// public static classes for various methods to use
public static class Helpers
{
    // helper function to test if adding increment will move value out of bounds
    // if so, reverse direction
    public static float IncrementRanger(float increment, float value, float min, float max)
    {
        float newValue = value + increment;
        if (newValue > min && newValue < max) return increment; // continue in same direction
    
        return increment *= -1.0f; // going outside range so flip direction
    }
}