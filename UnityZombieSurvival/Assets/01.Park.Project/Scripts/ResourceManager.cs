using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using UnityEngine.UIElements;

// ???
//using UnityEditor;

public class ResourceManager : MonoBehaviour
{
    Color color;
    private static ResourceManager m_instance; // �̱����� �Ҵ�� static ����
    public ZombieData[] zombieData_default;
    public static ResourceManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<ResourceManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }

    private static string zombieDataPath = default;
  



    private void Awake()
    {
        zombieData_default = new ZombieData[5];
        test();
        
        // CSV �����͸� ó���ϴ� ������ �߰��ϰų� ����ϴ� ���� �۾� ����
        //ProcessCSVData(data);

        //LEGACY: Doesn't works
        //dataPath = Application.dataPath;
        //ZOMBIE_DATA_PATH = string.Format("{0}/{1}", Application.dataPath, "01.Park.Project/Scripables");
        //byte[] byteZombieData = File.ReadAllBytes(ZOMBIE_DATA_PATH + "/Zombie Data Default");
        //Debug.LogFormat("Data path: {0}", ZOMBIE_DATA_PATH);


        //zombieDataPath = "Scripables";
        //zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "Zombie Data Default");
        //zombieData_default = Resources.Load<ZombieData>(zombieDataPath);



        //zombieData_default = AssetDatabase.LoadAssetAtPath<ZombieData>(zombieDataPath);
        //ZombieData zombieData_ = Resources.Load<ZombieData>(zombieDataPath);

        //Debug.LogFormat("ZOMBIE_DATA_PATH: {0}", zombieDataPath);
        //Debug.LogFormat("Zombie data: {0}, {1}, {2}", zombieData_.health, zombieData_.damage, zombieData_.speed);

        //Debug.LogFormat("���� Save data�� ���⿡�ٰ� �����ϴ� ���� ����̴�.: {0}", Application.persistentDataPath);
    }


    public void test()
    {
        StreamReader zombieData = new StreamReader(Application.dataPath +
            "/" + "Resources" + "/" + "ZombieDatas" +
            "/" + "ZombieSurvivalDatas.csv");
        bool count = false;

        bool endOfFile = false;

        int number = 0;

        //ZombieData zombie = new ZombieData();

        while (!endOfFile && number < 3)
        {
            string data_String = zombieData.ReadLine();

            if (count == true)
            {
                if (data_String == null)
                {
                    endOfFile = true;

                    break;
                }

                var data_values = data_String.Split(',');

                for (int i = 1; i < data_values.Length; i++)
                {
                    Debug.Log(i + " " + data_values[i].ToString());
                }
                ColorUtility.TryParseHtmlString("#"+data_values[4].ToString(), out color);

                zombieData_default[number] = new ZombieData(float.Parse(data_values[1].ToString()), float.Parse(data_values[2].ToString()), float.Parse(data_values[3].ToString()), color);

                number += 1;
            }

            count = true;
        }
    }
}
