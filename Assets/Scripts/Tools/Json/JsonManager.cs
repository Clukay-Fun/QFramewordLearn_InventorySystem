using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace QFramework.Inventory
{
    /// <summary>
    /// 序列化和反序列化选择用那种方式
    /// </summary>
    public enum JsonType
    {
        JsonUtlity,
        LitJson
    }

    public class JsonManager
    {

        /// <summary>
        /// 存储Json数据 序列化
        /// </summary>
        public static void SaveData(object data, string fileName, JsonType type = JsonType.LitJson)
        {
            // 确定存储路径
            string path = Application.persistentDataPath + "/" + fileName + ".json";

            // 序列化
            string jsonStr = "";
            switch (type)
            {
                case JsonType.JsonUtlity:
                    jsonStr = JsonUtility.ToJson(data);
                    break;
                case JsonType.LitJson:
                    jsonStr = JsonMapper.ToJson(data);
                    break;
            }

            // 把序列化的Json字符串存储到指定路径的文件中
            File.WriteAllText(path, jsonStr);
            //Debug.Log(path);
            //Debug.Log("Save");
        }


        /// <summary>
        /// 读取文件中的Json数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T LoadData<T>(string fileName, JsonType type = JsonType.LitJson) where T : new()
        {
            // 确定从哪个路径读取
            // 首先判断默认数据文件夹中是否有想要的数据
            string path = Application.streamingAssetsPath + "/" + fileName + ".json";

            // 如果不存在默认文件就从读写文件夹中去寻找
            if (!File.Exists(path))
                path = Application.persistentDataPath + "/" + fileName + ".json";

            // 都没有就返回一个默认对象
            if (!File.Exists(path))
                return new T();

            // 进行反序列化
            string jsonStr = File.ReadAllText(path);

            // 数据对象
            T data = default(T);
            switch (type)
            {
                case JsonType.JsonUtlity:
                    data = JsonUtility.FromJson<T>(jsonStr);
                    break;
                case JsonType.LitJson:
                    data = JsonMapper.ToObject<T>(jsonStr);
                    break;
            }

            //Debug.Log("Load");
            //Debug.Log(data);
            // 把对象返回出去
            return data;
        }
    }
}

