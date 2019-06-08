using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pagination
{
}

public class User
{
    public string id;
    public string full_name;
    public string profile_picture;
    public string username;
}

public class Thumbnail
{
    public int width;
    public int height;
    public string url;
}

public class LowResolution
{
    public int width;
    public int height;
    public string url;
}

public class StandardResolution
{
    public int width;
    public int height;
    public string url;
}

public class Images
{
    public Thumbnail thumbnail;
    public LowResolution low_resolution;
    public StandardResolution standard_resolution;
}

public class From
{
    public string id;
    public string full_name;
    public string profile_picture;
    public string username;
}

public class Caption
{
    public string id;
    public string text;
    public string created_time;
    public From from;
}

[System.Serializable]
public class Likes
{
    public int count;
}

public class Comments
{
    public int count;
}

[System.Serializable]
public class Datum
{
    public string id;
    public User user;
    public Images images;
    public string created_time;
    public Caption caption;
    public bool user_has_liked;
    public Likes likes;
    public List<object> tags;
    public string filter;
    public Comments comments;
    public string type;
    public string link;
    public object location;
    public object attribution;
    public List<object> users_in_photo;
}

public class Meta
{
    public int code;
}

[System.Serializable]
public class RootObject
{
    public Pagination pagination;
    public List<Datum> data;
    public Meta meta;

    public static RootObject CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<RootObject>(jsonString);
    }
}

