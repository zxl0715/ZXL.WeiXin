using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;

namespace ZXL.Common
{
    public class DataFormatter
    {
        private DataFormatter() { }

        /// <summary>
        /// 序列化数据集的数据为二进制格式Serialize the Data of dataSet to binary format
        /// </summary>
        /// <param name="dsOriginal"></param>
        /// <returns></returns>
        public static byte[] GetBinaryFormatData(DataSet dsOriginal)
        {
            byte[] binaryDataResult = null;
            if (dsOriginal == null)
            {
                return binaryDataResult;
            }
            MemoryStream memStream = new MemoryStream();
            IFormatter brFormatter = new BinaryFormatter();
            dsOriginal.RemotingFormat = SerializationFormat.Binary;

            brFormatter.Serialize(memStream, dsOriginal);
            binaryDataResult = memStream.ToArray();
            memStream.Close();
            memStream.Dispose();
            return binaryDataResult;
        }

        /// <summary>
        /// 从数据检索数据集的二进制格式Retrieve dataSet from data of binary format
        /// </summary>
        /// <param name="binaryData"></param>
        /// <returns></returns>
        public static DataSet RetrieveDataSet(byte[] binaryData)
        {
            DataSet dataSetResult = null;
            MemoryStream memStream = new MemoryStream(binaryData);
            IFormatter brFormatter = new BinaryFormatter();

            object obj = brFormatter.Deserialize(memStream);
            dataSetResult = (DataSet)obj;
            return dataSetResult;
        }


        //public static byte[] GetsetBinary(DataTable dt)
        //{
        //    byte[] bArrayResult = null; //用于存放序列化后的数据
        //    dt.RemotingFormat = SerializationFormat.Binary; //指定DataSet串行化格式是二进制

        //    MemoryStream ms = new MemoryStream();//定义内存流对象，用来存放DataSet序列化后的值
        //    IFormatter IF = new BinaryFormatter();//产生二进制序列化格式
        //    IF.Serialize(ms, dt);//串行化到内存中
        //    bArrayResult = ms.ToArray(); // 将DataSet转化成byte[]
        //    ms.Close();
        //    ms.Dispose();
        //    return bArrayResult;
        //}
        //public static DataTable RetrieveDataSet(byte[] binaryData)
        //{
        //    MemoryStream ms = new MemoryStream(binaryData);//创建内存流
        //    IFormatter bf = new BinaryFormatter();//产生二进制序列化格式
        //    object obj = bf.Deserialize(ms);//反串行化到内存中
        //    //类型检验
        //    ms.Close();
        //    if (obj is DataTable)
        //    {
        //        DataTable dataSetResult = (DataTable)obj;
        //        return dataSetResult;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        ///// <summary>序列化方法
        ///// 不需要分页
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <param name="flag">false</param>
        ///// <returns></returns>
        //public string Serialize(DataTable dt, bool flag)
        //{
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        Dictionary<string, object> result = new Dictionary<string, object>();
        //        foreach (DataColumn dc in dt.Columns)
        //        {
        //            result.Add(dc.ColumnName, dr[dc].ToString());
        //        }
        //        list.Add(result);
        //    }
        //    return serializer.Serialize(list); ;
        //}
        //public DataTable getSendDetailTest()
        //{
        //    DataTable dtb = new DataTable();

        //    //得到序列化结果aaa
        //    string aaa = getSendDetailQuery(Convert.ToDateTime("2012-01-01 00:00:00"), Convert.ToDateTime("2012-05-01 23:59:59"), "wangsub1");

        //    if (aaa.Substring(0, 1) == "0")
        //    {
        //        try
        //        {
        //            JavaScriptSerializer serializer = new JavaScriptSerializer();
        //            // var obj = serializer.DeserializeObject(aaa);//反序列化

        //            aaa = aaa.substring(2, aaa.length - 2);

        //            ArrayList dic = serializer.Deserialize<ArrayList>(aaa);//反序列化ArrayList类型

        //            if (dic.Count > 0)
        //            {
        //                foreach (Dictionary<string, object> drow in dic)
        //                {
        //                    if (dtb.Columns.Count == 0)
        //                    {
        //                        foreach (string key in drow.Keys)
        //                        {
        //                            dtb.Columns.Add(key, drow[key].GetType());//添加dt的列名
        //                        }
        //                    }
        //                    DataRow row = dtb.NewRow();
        //                    foreach (string key in drow.Keys)
        //                    {

        //                        row[key] = drow[key];//添加列值
        //                    }
        //                    dtb.Rows.Add(row);//添加一行
        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            //
        //        }
        //    }
        //    else
        //    {
        //        //
        //    }

        //    return dtb;
        //}
        //public string getSendDetailQuery(DateTime timeS, DateTime timeE, string sccount)
        //{
        //    try
        //    {
        //        SmsOperate so = new SmsOperate();

        //        //得到dt
        //        DataTable dtt = so.getSendDetailQuery(timeS, timeE, sccount);
        //        JavaScriptSerializer serializer = new JavaScriptSerializer();
        //        string aaa = Serialize(dtt, false);//datatable不能直接序列化，此为序列化方法
        //        return "0:" + aaa;

        //    }
        //    catch (Exception e)
        //    {
        //        return "-1" + e.Message;
        //    }
        //}
    }
}
