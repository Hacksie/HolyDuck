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

       if(list.Count == 0)
        {
            return default(T);
        }
        //if(p==0)
        //{
        //    return default(T);
        //}

        return list[p];
    }

    public static HashSet<T> PickRandomElements<T>(this List<T> list, int elements)
    {
        HashSet<T> results = new HashSet<T>();

        while(elements > 0)
        {
            var e = list.GetRandomElement();

            if(results.Count >= list.Count)
            {
                break;
            }

            if (results.Contains(e)) continue;

            results.Add(e);
            elements--;
        }

        return results;
    }
}