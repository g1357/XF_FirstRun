using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using XF_FirstRun.Helpers;

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
        /// Имя файла доя сохранения данных.
        /// </summary>
        string FileName;

        /// <summary>
        /// Полное имя файла доя сохранения данных.
        /// </summary>
        string FilePath;

        /// <summary>
        /// Имя каталога для хранения данных.
        /// </summary>
        string DirectoryName;

        /// <summary>
        /// Полное путь каталога для хранения данных.
        /// </summary>
        string DirectoryPath;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public FileManager()
        {
            DirectoryName = SystemInformation.DirectoryName;
            var appData = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(appData);
            DirectoryPath = Path.Combine(path, DirectoryName);
            var exists = Directory.Exists(DirectoryPath);
            if (!exists)
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            if (string.IsNullOrEmpty(FileName))
            {
                FileName = DefaultFileName;
            }
            FilePath = Path.Combine(DirectoryPath, FileName);
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
                return File.Exists(Path.Combine(DirectoryPath, fileName));
            });
        }
        /// <summary>
        /// Асинхронная проверка наличия файла.
        /// </summary>
        /// <returns>Существование файла</returns>
        public async Task<bool> FileExistAsync()
        {
            return await this.FileExistAsync(FilePath);
        }
        /// <summary>
        /// Асинхронная запись текста в файл.
        /// </summary>
        /// <param name="filename">Полный путь файла</param>
        /// <param name="text">Сохраняемый текст</param>
        /// <returns>Успешность записи</returns>
        public async Task WriteAllTextAsync(string fileName, string text)
        {
            await Task.Run(() =>
            {
                try
                {
                    if (!Directory.Exists(DirectoryPath))
                    {
                        Directory.CreateDirectory(DirectoryPath);
                    }
                    File.WriteAllText(Path.Combine(DirectoryPath, fileName), text);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Exception: {ex.Message}!");
                }
            });
        }
        /// <summary>
        /// Асинхронная запись текста в файл.
        /// </summary>
        /// <param name="text">Сохраняемый текст</param>
        /// <returns>Успешность записи</returns>
        public async Task WriteAllTextAsync(string text)
        {
            await this.WriteAllTextAsync(FilePath, text);
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
                return File.ReadAllText(Path.Combine(DirectoryPath, fileName));
            });
        }
        /// <summary>
        /// Асинхронное чтение текста из файла.
        /// </summary>
        /// <returns>Считанный текст</returns>
        public async Task<string> ReadAllTextAsync()
        {
            return await ReadAllTextAsync(FilePath);
        }

        public async Task SetDirectoryAsync(string directory)
        {
            await Task.Run(() =>
            {
                var exists = Directory.Exists(DirectoryPath);
                if (exists)
                {
                    Directory.Delete(DirectoryPath, true);
                }
                var appData = Environment.SpecialFolder.LocalApplicationData;
                var path = Environment.GetFolderPath(appData);
                DirectoryPath = Path.Combine(path, directory);
                exists = Directory.Exists(DirectoryPath);
                if (!exists)
                {
                    Directory.CreateDirectory(DirectoryPath);
                }
                FilePath = Path.Combine(DirectoryPath, FileName);
            });
        }

        public async Task DeleteDataAsync()
        {
            await Task.Run(() =>
            {
                var exists = Directory.Exists(DirectoryPath);
                if (exists)
                {
                    Directory.Delete(DirectoryPath, true);
                }
            });
        }

    }
}
