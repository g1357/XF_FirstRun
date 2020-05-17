using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XF_FirstRun.Services
{
    /// <summary>
    /// Интерфейс работы с файлами
    /// </summary>
    public interface IFileManager
    {
        Task<bool> FileExistAsync(string fileName);
        Task<bool> FileExistAsync();
        Task WriteAllTextAsync(string filename, string text);
        Task WriteAllTextAsync(string text);
        Task<string> ReadAllTextAsync(string fileName);
        Task<string> ReadAllTextAsync();
        Task SetDirectoryAsync(string directory);
        Task DeleteDataAsync();

    }
}
