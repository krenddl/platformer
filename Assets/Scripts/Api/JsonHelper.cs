using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class JsonHelper
{
    [Serializable]
    private class Wrapper<T>
    {
        public T[] items;
    }

    public static T[] FromJsonArray<T>(string json)
    {
        string wrappedJson = "{ \"items\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(wrappedJson);
        return wrapper.items;
    }
}
