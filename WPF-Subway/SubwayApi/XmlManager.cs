using System;
using System.Xml.Linq;

namespace WPF_Subway.SubwayApi
{
    internal class XmlManager : Singleton<XmlManager>
    {
        //Config.xml 파일을 읽기 위한 클래스
        //Api 정보를 Config.xml에 담아 파싱후 연결에 사용
        private static string _configFile = @"Config.xml";

        public static string configFile
        { get => _configFile; set { _configFile = value; } }

        public static string GetValue(params string[] args)
        {
            string result = string.Empty;
            try
            {
                XDocument xDoc = XDocument.Load(configFile);
                result = GetNodeValue(xDoc.FirstNode as XElement, 0, args);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                result = string.Empty;
            }
            return result;
        }

        public static bool SetValue(params string[] args)
        {
            bool result = false;
            try
            {
                XDocument xDoc = XDocument.Load(configFile);
                result = SetNodeValue(xDoc.FirstNode as XElement, 0, args);
                xDoc.Save(configFile);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        private static string GetNodeValue(XElement node, int index, string[] args)
        {
            string result = string.Empty;
            if (args.Length > index + 1)
            {
                result = GetNodeValue(node.Element(args[index]), ++index, args);
            }
            else
            {
                result = node.Element(args[index]).Value.ToString();
            }
            return result;
        }

        private static bool SetNodeValue(XElement node, int index, string[] args)
        {
            if (args.Length > index + 1)
            {
                SetNodeValue(node.Element(args[index]), ++index, args);
            }
            else
            {
                node.SetValue(args[index]);
            }
            return true;
        }
    }
}