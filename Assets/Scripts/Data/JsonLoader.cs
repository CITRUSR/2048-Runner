using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonLoader : ILoader
{
    private string _path;

    public JsonLoader(string path)
    {
        _path = path;
    }

    public object Load<T>()
    {
        using (var fileStream = new StreamReader(Application.persistentDataPath + _path + ".json"))
        {
            var json = fileStream.ReadToEnd();
            var data = JsonConvert.DeserializeObject<T>(json);
            return data;
        }
    }
}
