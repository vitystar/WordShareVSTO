using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WordVSTOShare.util
{
    public static class FileHelper
    {

        private static readonly string savePath = System.Environment.CurrentDirectory;

        /// <summary>
        /// 保存对象
        /// </summary>
        /// <typeparam name="T">保存的对象类型</typeparam>
        /// <param name="Obj">要保存的对象</param>
        /// <param name="fileName">文件名</param>
        public async static Task SaveObject<T>(T Obj, string fileName)
        {
            using (FileStream fs = new FileStream(savePath + @"\" + fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                await Task.Run(() =>
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, Obj);
                });
            }
        }

        /// <summary>
        /// 从文件读取对象
        /// </summary>
        /// <typeparam name="T">要读取的对象类型</typeparam>
        /// <param name="fileName">要读取的文件名</param>
        /// <returns>读取出的对象</returns>
        public async static Task<T> ReadObject<T>(string fileName) where T : class, new()
        {
            using (FileStream fs = new FileStream(savePath + @"\" + fileName, FileMode.Open))
            {
                return await Task.Run(() =>
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(fs) as T;
                }
               );
            }
        }

        public async static Task DeleteFile(string fileName)
        {
            try
            {
                await Task.Run(() => File.Delete(savePath + @"\" + fileName));
            }
            catch
            {

            }
        }

        public async static Task DeleteAbsolute(string filePath)
        {
            await Task.Run(() => File.Delete(filePath));
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>文件是否存在</returns>
        public static bool FileExist(string fileName) => File.Exists(savePath + @"\" + fileName);

    }
}
