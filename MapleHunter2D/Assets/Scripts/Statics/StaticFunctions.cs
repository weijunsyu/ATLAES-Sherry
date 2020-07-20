/*
 * Class containing  static helper functions
 */
public static class StaticFunctions
{
    // Vector functions:
    // Do scalar multiplication on some vector vectorArray by value scalar
    public static float[] ScalarMultiplication(float scalar, params float[] vectorArray)
    {
        float[] scaledVector = new float[vectorArray.Length];
        for (int i = 0; i < vectorArray.Length; i++)
        {
            scaledVector[i] = scalar * vectorArray[i];
        }
        return scaledVector;
    }
    // Find the unit vector of VectorArray
    public static float[] UnitVector(params float[] vectorArray)
    {
        float magnitude = VectorMagnitude(vectorArray);
        magnitude = 1 / magnitude;

        return ScalarMultiplication(magnitude, vectorArray);
    }
    // Scale the ND vector given as list of components or as 
    // array such that direction is preserved but magnitude is scaled to that of targetSpeed
    public static float[] ScaleVectorMagnitude(float targetSpeed, params float[] currentVelocityVectorArray)
    {
        //find unit vector of current velocity
        float[] newVelocityVectorArray = UnitVector(currentVelocityVectorArray);
        //scale unit vector to the target magnitude
        newVelocityVectorArray = ScalarMultiplication(targetSpeed, newVelocityVectorArray);

        return newVelocityVectorArray;
    }
    // Compute the magnitude of the vector given its components in array form or as list of params i, j, k, ...
    public static float VectorMagnitude(params float[] vectorArray)
    {
        float squaredCompSum = 0;
        for (int i = 0; i < vectorArray.Length; i++)
        {
            squaredCompSum += (vectorArray[i] * vectorArray[i]);
        }
        return (float)System.Math.Sqrt(squaredCompSum);
    }


    // Random number generator:
    // Return some random double value between min and max such that min is inclusive and max is exclusive
    public static double RandomRealNumber(double min, double max)
    {
        return StaticObjects.RANDOM.NextDouble() * (max - min) + min;
    }
}
