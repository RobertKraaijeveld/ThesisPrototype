using System;
using System.Collections.Generic;
using System.Dynamic;

public static class Extensions
{
    public static List<List<T>> Split<T>(this IEnumerable<T> collection, int size)
    {
        var chunks = new List<List<T>>();
        var count = 0;
        var temp = new List<T>();

        foreach (var element in collection)
        {
            if (count++ == size)
            {
                chunks.Add(temp);
                temp = new List<T>();
                count = 1;
            }
            temp.Add(element);
        }
        chunks.Add(temp);

        return chunks;
    }

    public static T ToObject<T>(this IDictionary<String, Object> dictionary) where T: class
    {  
        var expandoObj = new ExpandoObject();  
        var expandoObjCollection = (ICollection<KeyValuePair<String, Object>>)expandoObj;  
  
        foreach (var keyValuePair in dictionary)  
        {  
            expandoObjCollection.Add(keyValuePair);  
        }  
        dynamic eoDynamic = expandoObj;  
        return eoDynamic as T;  
    }  
}