using System.Collections.Generic;

public static class ListExtensions
{
    // Maybe make this get a random element instead?
    public static void Randomize<T>(this List<T> list)
    {
        T temp;

        for (int i = 0; i < list.Count; i++)
        {
            int r = UnityEngine.Random.Range(i, list.Count);
            temp = list[r];
            list[r] = list[i];
            list[i] = temp;
        }
    }

    public static T GetRandomElement<T>(this List<T> list)
    {
        int p = UnityEngine.Random.Range(0, list.Count);

        return list[p];
    }

}