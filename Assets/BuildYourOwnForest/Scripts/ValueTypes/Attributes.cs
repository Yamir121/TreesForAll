using UnityEngine;

//As the ecosystem values are core of the gameplay, this is a valuetype storing all three. Reduces chance of mistakes.
public class Attributes
{
    public int biodiversity;
    public int soilQuality;
    public int carbonStorage;
    
    public Attributes(int b, int s, int c)
    {
        this.biodiversity = b;
        this.soilQuality = s;
        this.carbonStorage = c;
    }
    

    /// <summary>
    /// Set all attributes
    /// </summary>
    /// <param name="b">biodiversity</param>
    /// <param name="s">soilquality</param>
    /// <param name="c">carbonstorage</param>
    public void SetAttributes(int b, int s, int c)
    {
        biodiversity = b;
        soilQuality = s;
        carbonStorage = c;
    }
}
