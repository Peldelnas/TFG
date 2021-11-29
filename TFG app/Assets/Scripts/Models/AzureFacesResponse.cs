using System;
//using UnityEngine;

//public static class JsonHelper
//{
//    public static T[] FromJson<T>(string json)
//    {
//        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
//        return wrapper.Items;
//    }

//    public static string ToJson<T>(T[] array)
//    {
//        Wrapper<T> wrapper = new Wrapper<T>();
//        wrapper.Items = array;
//        return JsonUtility.ToJson(wrapper);
//    }

//    public static string ToJson<T>(T[] array, bool prettyPrint)
//    {
//        Wrapper<T> wrapper = new Wrapper<T>();
//        wrapper.Items = array;
//        return JsonUtility.ToJson(wrapper, prettyPrint);
//    }

//    [Serializable]
//    private class Wrapper<T>
//    {
//        public T[] Items;
//    }
//}

[Serializable]
public class AzureFacesResponse
{
    public AzureFacesResponseArray[] result;
}

[Serializable]
public class AzureFacesResponseArray
{
    public string faceId;

    public AzureFacesRectangle faceRectangle;

    public AzureFacesAttributes faceAttributes;

}
[Serializable]
public class AzureFacesRectangle
{
    public int top;
    public int left;
    public int width;
    public int height;    
}

[Serializable]
public class AzureFacesAttributes
{
    public double smile;
    public AzureEmotion emotion;
}

[Serializable]
public class AzureEmotion
{
    public double anger;
    public double contempt;
    public double disgust;
    public double fear;
    public double happiness;
    public double neutral;
    public double sadness;
    public double surprise;
}
/*
[
    {
        "faceId": "76de8fe0-adb5-4239-9236-03d28f389b77",
        "faceRectangle": {
            "top": 302,
            "left": 448,
            "width": 336,
            "height": 336
        },
        "faceAttributes": {
            "smile": 0,
            "emotion": {
                "anger": 0,
                "contempt": 0,
                "disgust": 0,
                "fear": 0,
                "happiness": 0,
                "neutral": 0.382,
                "sadness": 0.618,
                "surprise": 0
            }
        }
    }
]
*/