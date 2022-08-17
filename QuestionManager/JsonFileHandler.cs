using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public static class JsonFileHandler
{

    public static void saveFile<T> (List<T> objects)
    {
        string content = JsonHelper.ToJson<T>(objects.ToArray());
        writeFile(getPath(), content);
    }

    public static List<T> loadFile<T>()
    {
        string content = readFile(getPath());

        if(String.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();
        }

        List<T> objects = JsonHelper.FromJson<T>(content).ToList();

        return objects;
    }

    public static void writeFile(string path, string content)
    {
        FileStream fileS = new FileStream(path, FileMode.Create);

        using(StreamWriter writer = new StreamWriter(fileS))
        {
            writer.Write(content);
        }
    }

    public static string readFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string data = reader.ReadToEnd();
                return data;
            }
        }
        return "";
    }

    public static bool checkFile()
    {
        if (File.Exists(getPath()))
            return true;

        return false;
    }

    private static string getPath()
    {
        return Application.dataPath + Path.AltDirectorySeparatorChar + "Data/" + "Questions.json";
    }
}
