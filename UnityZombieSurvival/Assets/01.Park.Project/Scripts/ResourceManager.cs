using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEditor;
// ???
//using UnityEditor;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager m_instance; // �̱����� �Ҵ�� static ����

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
    public ZombieData zombieData_default = default;


    private void Awake()
    {
        //LEGACY: Doesn't works
        //dataPath = Application.dataPath;
        //ZOMBIE_DATA_PATH = string.Format("{0}/{1}", Application.dataPath, "01.Park.Project/Scripables");
        //byte[] byteZombieData = File.ReadAllBytes(ZOMBIE_DATA_PATH + "/Zombie Data Default");
        //Debug.LogFormat("Data path: {0}", ZOMBIE_DATA_PATH);


        zombieDataPath = "Scripables";
        zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "Zombie Data Default");
        zombieData_default = Resources.Load<ZombieData>(zombieDataPath);
        //zombieData_default = AssetDatabase.LoadAssetAtPath<ZombieData>(zombieDataPath);
        //ZombieData zombieData_ = Resources.Load<ZombieData>(zombieDataPath);

        //Debug.LogFormat("ZOMBIE_DATA_PATH: {0}", zombieDataPath);
        //Debug.LogFormat("Zombie data: {0}, {1}, {2}", zombieData_.health, zombieData_.damage, zombieData_.speed);

        Debug.LogFormat("���� Save data�� ���⿡�ٰ� �����ϴ� ���� ����̴�.: {0}",Application.persistentDataPath);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
