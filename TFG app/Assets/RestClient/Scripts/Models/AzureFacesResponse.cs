using System;

[Serializable]
public class AzureFacesResponse
{
    public string faceId;

    //public decimal textAngle;

    //public string recognitionModel;

    public AzureFacesRectangle[] faceRectangle;
}

[Serializable]
public class AzureFacesRectangle
{
    public int width;
    public int height;
    public int left;
    public int top;
}
/*
 [
  {
    "faceId": "1a14f740-2974-45e5-ab08-66687fa46ad9",
    "faceRectangle": {
      "top": 171,
      "left": 222,
      "width": 192,
      "height": 192
    }
  }
] */