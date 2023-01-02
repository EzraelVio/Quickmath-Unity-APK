using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveScore
{
    public static void SaveBoard (Score score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.kl";
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreData data = new ScoreData(score);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static ScoreData LoadScore ()
    {
        string path = Application.persistentDataPath + "/score.kl";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(stream) as ScoreData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Filenya gak ada");
            return null;
        }
    }
}
