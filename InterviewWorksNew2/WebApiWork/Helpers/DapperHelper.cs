using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Web;

namespace WebApiWork.Helpers
{
    public class DapperHelper
    {
        /// <summary>
        /// AppSetting - 連線字串
        /// </summary>
        private static readonly string DBConnectionString = ConfigurationManager.AppSettings["DBConnectionString"];

        /// <summary>
        /// 取資料 (含model)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static List<T> Get<T>(string query, object arguments)
        {
            List<T> entities;
            using (SqlConnection conn = new SqlConnection(DBConnectionString))
            {
                conn.Open();
                entities = conn.Query<T>(query, arguments).ToList();
                conn.Close();
            }
            return entities;
        }

        /// <summary>
        /// 取資料 (不含model)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<T> Get<T>(string query)
        {
            List<T> entities;
            using (SqlConnection conn = new SqlConnection(DBConnectionString))
            {
                conn.Open();
                entities = conn.Query<T>(query).ToList();
                conn.Close();
            }
            return entities;
        }

    }
}