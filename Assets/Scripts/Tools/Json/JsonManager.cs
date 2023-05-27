using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace QFramework.Inventory
{
    /// <summary>
    /// ���л��ͷ����л�ѡ�������ַ�ʽ
    /// </summary>
    public enum JsonType
    {
        JsonUtlity,
        LitJson
    }

    public class JsonManager
    {

        /// <summary>
        /// �洢Json���� ���л�
        /// </summary>
        public static void SaveData(object data, string fileName, JsonType type = JsonType.LitJson)
        {
            // ȷ���洢·��
            string path = Application.persistentDataPath + "/" + fileName + ".json";

            // ���л�
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

            // �����л���Json�ַ����洢��ָ��·�����ļ���
            File.WriteAllText(path, jsonStr);
            //Debug.Log(path);
            //Debug.Log("Save");
        }


        /// <summary>
        /// ��ȡ�ļ��е�Json����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T LoadData<T>(string fileName, JsonType type = JsonType.LitJson) where T : new()
        {
            // ȷ�����ĸ�·����ȡ
            // �����ж�Ĭ�������ļ������Ƿ�����Ҫ������
            string path = Application.streamingAssetsPath + "/" + fileName + ".json";

            // ���������Ĭ���ļ��ʹӶ�д�ļ�����ȥѰ��
            if (!File.Exists(path))
                path = Application.persistentDataPath + "/" + fileName + ".json";

            // ��û�оͷ���һ��Ĭ�϶���
            if (!File.Exists(path))
                return new T();

            // ���з����л�
            string jsonStr = File.ReadAllText(path);

            // ���ݶ���
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
            // �Ѷ��󷵻س�ȥ
            return data;
        }
    }
}

