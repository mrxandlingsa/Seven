using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

namespace Tools
{
    public  class XmlTools : MonoBehaviour
    {
        public static XmlTools XmlToolsInstance;

        private XmlTools()
        {
            // �ڹ��캯���� ��ȡXML�ļ�������
            //ReadXmlConfig();
        }
        
        //////
            /// ��Ҫ
        /////
        
        //ÿ�����͵���Ʒ�ֿ�Щ
        public struct SingleWeapons
        {
            public int sword_type;
            public string name;
            public int attack;
            // range(0,100)
            public int acceptability;
        };
        
        public struct SingleArmour
        {
            public string name;
            public int defence_value;
            
        };

        public struct SingleDrug
        {
            public int drug_type;
            public string name;
            public int addition_count;
        };
        

        
                




        // struct type
        public  Dictionary<string, SingleWeapons> weapon_dictionary = new Dictionary<string, SingleWeapons>();
        public  Dictionary<string, SingleArmour>  armour_dictionary = new Dictionary<string, SingleArmour>();
        public  Dictionary<string, SingleDrug>  drug_dictionary = new Dictionary<string, SingleDrug>();
        

        public static XmlTools GetPlayerBaseInstance()
        {
            if (XmlToolsInstance == null)
            {
                XmlToolsInstance = new XmlTools();
            }

            return XmlToolsInstance;
        }

        //class Program
        //{
        //    static void Main(string[] args)
        //    {
        //        Console.WriteLine("Hello World!");
        //    }
        //}
        /// <summary>
        /// ���е�XML�ļ�ȫ������ͬһ�ļ���Ŀ¼��
        /// </summary>
        // XML create
        public static void createXML(string root_name, string xml_name)
        {
            //�½�XmlDocument����
            XmlDocument doc = new XmlDocument();
            // ֻ�Ǵ���һ��XML�ļ� Ӧ�ò��᲻��Ҫ�ڴ�����ʱ�򣬾����ӽڵ� 
            //���ڵ�
            XmlElement wa = doc.CreateElement(root_name);
            // sava data path(windows) 
            // ���滻ΪApplication.persistentDataPath ������Ϸ��������·����֪�� �ǲ��ǻ��
            string path = Application.dataPath + "/player_Data/" + xml_name + ".xml";
            doc.Save(path);
        }

        /// <summary>
        /// ��ԭXML �ļ�������һ���ڵ�
        /// @param need_insert_node_name , inserted_node_Name,inserted_node_value(int)
        /// </summary>
        /// <param name="need_insert_node_name"></param>
        public static void AddXML(string need_insert_node_name, string inserted_node_Name, int inserted_node_value,
            string xml_name)
        {
            //�½�XmlDocument����
            string path = Application.dataPath + "/player_Data/" + xml_name + ".xml";
            XmlDocument doc = new XmlDocument();
            //�����ļ�
            try
            {
                doc.Load(path);
            }
            catch (System.Xml.XmlException)
            {
                throw new Exception("load fail");
            }

            //����Ҫ�������ݵĽڵ�
            XmlNode newxmlnode = doc.SelectSingleNode(need_insert_node_name);
            //�����µĽڵ�
            XmlElement new_node = doc.CreateElement(inserted_node_Name);
            // int ת��Ϊstring
            new_node.InnerText = inserted_node_value.ToString();
            newxmlnode.AppendChild(new_node);
            doc.Save(path);
        }

        public static void UpdateXML(string parent_node_name, string updated_node_name, int updated_node_value,
            string xml_name)
        {
            string path = Application.dataPath + "/player_Data/" + xml_name + ".xml";
            string updated_node_value_str = updated_node_value.ToString();
            XmlDocument doc = new XmlDocument();
            //�����ļ�
            try
            {
                doc.Load(path);
            }
            catch (System.Xml.XmlException)
            {
                throw new Exception("load fail,do not find file");
            }

            XmlNode inquired_node = doc.SelectSingleNode(parent_node_name);
            if (inquired_node == null)
            {
                throw new Exception("do not find node");
            }

            XmlNodeList charactors = inquired_node.ChildNodes;
            //charactors.SelectNodes(updated_node_name)

            for (int i = 0; i < charactors.Count; i++)
            {
                if (charactors[i].Name.Equals(updated_node_name))
                {
                    charactors[i].InnerText = updated_node_value_str;
                }
            }

            //д���ĵ�
            doc.Save(path);
        }

        /// <summary>
        ///  ��ȡ�ļ���ʱ���ڼ�һ��������
        ///  ��ȡXML�ļ�������
        /// </summary>
        /// <param name="xml_name"></param>
        public static void ReadXML(string xml_name, string root_name)
        {

            XmlDocument doc = new XmlDocument();
            string path = Application.dataPath + "/player_Data/" + xml_name + ".xml";
            doc.Load(path);
            //��ȡ���ڵ�XmlElement��ʾ�ڵ㣨Ԫ�أ�
            XmlNode player = doc.SelectSingleNode(root_name);
            XmlNodeList persons_element_list = player.ChildNodes;
            // ����ֵ������Ϊdictionary 
            Dictionary<string, int> result_dic = new Dictionary<string, int>();
            //foreach (var x in persons_element_list)
            //{
            //    result_dic.Add(x.Attribute, x.InnerText);
            //}
        }

        /// <summary>
        /// ��Ƶ�XML���ݵĽṹ Ϊ
        /// root --
        ///         A
        ///         b
        ///         c
        ///   ɾ��XML�ļ���ROOT�ڵ��µĵ�һ�ڵ�
        /// </summary>
        /// <param name="xml_name"></param>
        /// <param name="deleted_node_name"></param>
        public static void DeleteXMLNode(string xml_name, string deleted_node_name, string root_name)
        {
            XmlDocument doc = new XmlDocument();
            string path = Application.dataPath + "/player_Data/" + xml_name + ".xml";
            doc.Load(path);
            XmlNode inquired_node = doc.SelectSingleNode(root_name);
            XmlNodeList attr_list = inquired_node.ChildNodes;
            for (int i = 0; i < attr_list.Count; i++)
            {
                //if (attr_list[i].Name.Equals(deleted_node_name))
                //{
                //    attr_list.RemoveChild(i);
                //}
            }

            doc.Save(path);
        }

        // �˷���Ϊ��ȡ���õ�XML�ļ�����ͬ��XML�ṹ ��Ҫ��ͬ��
        // ����ʱ����Ʒ��manage���÷���
        //****   ���ǵ��Ժ�PC�˵Ĵ�� ���� Application.streamingAssetsPath                     ****//
        //****    �����andriod ios ������дһ�� ****//
        public void ReadXmlWeaponConfig()
        {

            string xmlfile = Application.streamingAssetsPath+"/Config/WeaponConfig.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlfile);

            XmlNode weapon = doc.SelectSingleNode("weapon");
            XmlNodeList weapon_node_list = weapon.ChildNodes;
            for (int i = 0; i < weapon_node_list.Count; i++)
            {
                SingleWeapons temp;
                string key = weapon_node_list[i].Name;
                temp.sword_type = int.Parse(weapon_node_list[i].SelectSingleNode("sword_type").InnerText);
                temp.name = weapon_node_list[i].SelectSingleNode("name").InnerText;
                temp.attack = int.Parse(weapon_node_list[i].SelectSingleNode("attack").InnerText);
                temp.acceptability = int.Parse(weapon_node_list[i].SelectSingleNode("acceptability").InnerText);
                weapon_dictionary.Add(key, temp);
            }
        }
        
        // ����
        public void ReadXmlArmourConfig()
        {
             string xmlfile = Application.streamingAssetsPath+"/Config/ArmourConfig.xml";
             XmlDocument doc = new XmlDocument();
             doc.Load(xmlfile);
             XmlNode armour = doc.SelectSingleNode("armour");
             XmlNodeList armour_node_list = armour.ChildNodes;
             for (int i = 0; i < armour_node_list.Count; i++)
             {
                SingleArmour temp;
                string key = armour_node_list[i].Name;
                temp.name = armour_node_list[i].SelectSingleNode("name").InnerText;
                temp.defence_value = int.Parse(armour_node_list[i].SelectSingleNode("defence_value").InnerText);
                armour_dictionary.Add(key, temp);
            }
        }

        //ҩƷ
        public void ReadXmlDrugConfig()
        {
             string xmlfile = Application.streamingAssetsPath+"/Config/DrugConfig.xml";
             XmlDocument doc = new XmlDocument();
             doc.Load(xmlfile);
             XmlNode drug = doc.SelectSingleNode("drug");
             XmlNodeList drug_node_list = drug.ChildNodes;
             for (int i = 0; i < drug_node_list.Count; i++)
             {
                SingleDrug temp;
                string key = drug_node_list[i].Name;
                temp.drug_type = int.Parse(drug_node_list[i].SelectSingleNode("type").InnerText);
                temp.name = drug_node_list[i].SelectSingleNode("name").InnerText;
                temp.addition_count = int.Parse(drug_node_list[i].SelectSingleNode("addition").InnerText);
                drug_dictionary.Add(key, temp);
            }
        }


    }
}