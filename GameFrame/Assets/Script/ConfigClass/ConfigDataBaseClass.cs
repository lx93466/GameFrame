using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Excel;
using System.Data;

namespace GameFrame
{
    public abstract class ConfigDataBaseClass
    {
        protected string m_configFileName = "";

        protected int m_columns = 0;

        protected int m_rows = 0;

        protected DataTable m_table = null;

        /// <summary>
        /// 返回值：是否初始化成功
        /// </summary>
        /// <param name="configFileName"></param>
        /// <returns></returns>
        public void InitConfig()
        {
            Init();

            string file = GameFrame.Tools.GetAppDir() + m_configFileName;
           
            try
            {
                FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                DataSet result = excelReader.AsDataSet();

                m_table = result.Tables[0];

                m_columns = m_table.Columns.Count;

                m_rows = m_table.Rows.Count;

                ReadConfig();
            }
            catch(System.Exception e)
            {
                Tools.AddWarming("Read file[" + file + "] error.");
                Tools.AddWarming(e.Message);
            }                   
        }

        /// <summary>
        /// 形参：
        ///     row：行号，从0开始，不读第一行
        ///     cloum：列号，从0开始，读第一列
        ///     即从xls的2A开始读取，2A对应行列为(0, 0)
        /// 返回：
        ///     读取格字符串，如果没有，返回""；
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public string GetValue(int row, int column)
        {
            string value = "";

            row = row + 1;

            if(row >=0 && row < m_rows && column >= 0 && column < m_columns)
            {
                value = m_table.Rows[row][column].ToString();
            }
            return value;
        }

        public abstract void ReadConfig();

        public abstract void Init();
        
        public virtual void UnInit(){}
    }
}

