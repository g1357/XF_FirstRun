using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace XF_FirstRun.Services
{
    /// <summary>
    /// Сервис управления локальными файлами
    /// </summary>
    public class FileManager : IFileManager
    {
        /// <summary>
        /// Имя файла по умолчанию.
        /// </summary>
        const string DefaultFileName = @"ShoppingList.json";

        /// <summary>
        /// Полное имя файла доя сохранения данных.
        /// </summary>
        string FileName;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public FileManager()
        {
            var appData = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(appData);
            FileName = Path.Combine(path,DefaultFileName);
        }

        /// <summary>
        /// Асинхронная проверка наличия файлы.
        /// </summary>
        /// <param name="fileName">Полный путь файла</param>
        /// <returns>Существование файла</returns>
        public async Task<bool> FileExistAsync(string fileName)
        {
            return await Task.Run<bool>(() =>
            {
                return File.Exists(fileName);
            });

        }
        /// <summary>
        /// Асинхронная проверка наличия файла.
        /// </summary>
        /// <returns>Существование файла</returns>
        public async Task<bool> FileExistAsync()
        {
            return await this.FileExistAsync(FileName);
        }
        /// <summary>
        /// Асинхронная запись текста в файл.
        /// </summary>
        /// <param name="filename">Полный путь файла</param>
        /// <param name="text">Сохраняемый текст</param>
        /// <returns>Успешность записи</returns>
        public async Task WriteAllTextAsync(string filename, string text)
        {
            await Task.Run(() =>
            {
                File.WriteAllText(filename, text);
            });
        }
        /// <summary>
        /// Асинхронная запись текста в файл.
        /// </summary>
        /// <param name="text">Сохраняемый текст</param>
        /// <returns>Успешность записи</returns>
        public async Task WriteAllTextAsync(string text)
        {
            await this.WriteAllTextAsync(FileName, text);
        }
        /// <summary>
        /// Асинхронное чтение текста из файла
        /// </summary>
        /// <param name="fileName">Полный путь файла</param>
        /// <returns>Считанный текст</returns>
        public async Task<string> ReadAllTextAsync(string fileName)
        {
            return await Task.Run<string>(() =>
            {
                return File.ReadAllText(fileName);
            });
        }
        /// <summary>
        /// Асинхронное чтение текста из файла.
        /// </summary>
        /// <returns>Считанный текст</returns>
        public async Task<string> ReadAllTextAsync()
        {
            return await Task.Run<string>(() =>
            {
                return File.ReadAllText(FileName);
            });
        }
    }
}
