using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonSaver : ISaver
{
    private string _savePath;

    public JsonSaver(string Path)
    {
        _savePath = Path;
    }

    public void Save(object data)
    {
        string Json = JsonConvert.SerializeObject(data);
        
        using (var fileStream = new StreamWriter(Application.persistentDataPath + _savePath + ".json"))
        {
            fileStream.Write(Json);
        }
    }
}
