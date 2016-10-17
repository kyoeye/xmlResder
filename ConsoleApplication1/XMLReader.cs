using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace XMLReader
{
    class XMLReader
    {
        static void Main(string[] args)
        {
           
            string xmlFilePath = "school.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            //学校  使用xpath表达式选择文档中所有的schoo的子节点
            XmlNodeList schoolNodeList = doc.SelectNodes("/school");
            if (schoolNodeList != null)
            {
                foreach (XmlNode schoolNode in schoolNodeList)
                {
                    //通过Attributes获得属性名为name的属性
                    string schoolName = schoolNode.Attributes["name"].Value;
                    Console.WriteLine("学校：" + schoolName);
                    ////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////
                    #region 年级
                    //通过SelectSingleNode方法获得当前节点下的grades子节点
                    XmlNode gradesNode = schoolNode.SelectSingleNode("grades");
                    if (gradesNode != null)
                    {
                        //通过ChildNodes属性获得grades的所有一级子节点
                        XmlNodeList gradeNodeList = gradesNode.ChildNodes;
                        if (gradeNodeList != null)
                        {
                            foreach (XmlNode gradeNode in gradeNodeList)
                            {
                                Console.WriteLine("\t");
                                Console.WriteLine("年级：" + gradeNode.Attributes["name"].Value + "   ID:" + gradeNode.Attributes["id"].Value);

                                #region 班级
                                //通过SelectSingleNode方法获得当前节点下的classes子节点
                                XmlNode classesNode = gradeNode.SelectSingleNode("classes");
                                if (classesNode != null)
                                {
                                    //通过ChildNodes属性获得classes的所有一级子节点
                                    XmlNodeList classNodeList = classesNode.ChildNodes;
                                    if (classNodeList != null)
                                    {
                                        foreach (XmlNode classNode in classNodeList)
                                        {
                                            Console.WriteLine("  班级：" + classNode.Attributes["name"].Value + "    ID:" + classNode.Attributes["id"].Value);

                                            #region 老师
                                            XmlNode teachersNode = classNode.SelectSingleNode("teachers");
                                            if (teachersNode != null)
                                            {
                                                XmlNodeList teacherNodeList = teachersNode.ChildNodes;
                                                if (teacherNodeList != null)
                                                {
                                                    foreach (XmlNode teacherNode in teacherNodeList)
                                                    {
                                                        XmlNode teacherNameNode = teacherNode.FirstChild;
                                                        XmlCDataSection cdate = (XmlCDataSection)teacherNameNode.FirstChild;
                                                        if (cdate != null)
                                                        {
                                                            Console.WriteLine("   " + teacherNode.Attributes["teach"].Value + "老师：" + cdate.InnerText.Trim());                                                                                                        

                                                        }
                                                    }
                                                }
                                            }
                                            #endregion  老师

                                            #region 所有学生
                                            XmlNode studentsNode = classNode.SelectSingleNode("students");
                                            if (studentsNode != null)
                                            {
                                                XmlNodeList studentNodeList = studentsNode.ChildNodes;
                                                if (studentNodeList != null)
                                                {
                                                    foreach (XmlNode studentNode in studentNodeList)
                                                    {
                                                        Console.WriteLine("    学生：" + studentNode.Attributes["id"].Value);

                                                        //获取student的属性值name和文本
                                                        XmlNode stu1 = studentNode.FirstChild;
                                                        XmlElement xe1 = (XmlElement)stu1;
                                                        if (xe1 != null)
                                                        {
                                                            Console.WriteLine("        姓名：" + xe1.InnerText.Trim());
                                                        }
                                                        //获取student的属性值sex和文本
                                                        XmlNode stu2 = studentNode.LastChild;
                                                        XmlElement xe2 = (XmlElement)stu2;
                                                        if (xe2 != null)
                                                        {
                                                            Console.WriteLine("        姓别：" + xe2.InnerText.Trim());
                                                        }
                                                    }
                                                }
                                                #endregion 所有学生
                                            }
                                        }
                                    }
                                    #endregion 班级
                                }
                            }
                        }
                        #endregion  年级
                        Console.Write("\r\n按随意键跳出");
                        Console.ReadKey();
                    }

                }
            }
        }
    }
}