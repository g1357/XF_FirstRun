using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XF_FirstRun.Helpers
{
    /// <summary>
    /// Этот класс предоставляет информацию о приложении и о системе.
    /// </summary>
    public static class SystemInformation
    {
        /// <summary>
        /// Возвращает значение имени приложения
        /// </summary>
        public static string ApplicationName { get; }

        /// <summary>
        /// Возвращает значение версии приложения
        /// </summary>
        public static Version ApplicationVersion { get; }

        /// <summary>
        /// Возвращает значение версии приложения
        /// </summary>
        public static string ApplicationVersionString { get; }

        /// <summary>
        /// Возвращает значение, которое показывает, что приложение запущено
        /// первый раз или нет.
        /// </summary>
        public static bool IsFirstRun { get; }

        /// <summary>
        /// Возвращает значение, которое показывает запущено приложение
        /// первый раз после его обновления.
        /// Используется, что сообщить о новых возможностях приложения.
        /// </summary>
        public static bool IsAppUpdated { get; }

        /// <summary>
        /// Инициализация статических членов класса <see cref="SystemInformation"/>
        /// </summary>
        static SystemInformation()
        {
            ApplicationName = AppInfo.Name;
            ApplicationVersion = AppInfo.Version;
            ApplicationVersionString = AppInfo.VersionString;
            IsFirstRun = DetectIfFirstRun();
            IsAppUpdated = DetectIfAppUpdated();
        }
        private static bool DetectIfFirstRun()
        {
            if (Application.Current.Properties.TryGetValue("IsFirstRun", out object flag))
            {
                return false;
            }
            else
            {
                Application.Current.Properties["IsFirstRun"] = false;
                Application.Current.Properties["CurrentVersion"] = ApplicationVersionString;
                return true;
            }
        }
        private static bool DetectIfAppUpdated()
        {
            if (Application.Current.Properties.TryGetValue("CurrentVersion", out object lastVersion))
            {
                string lastVersionString = (string)lastVersion;
                if (ApplicationVersionString == (string) lastVersion)
                {
                    return false;
                }
            }

            Application.Current.Properties["CurrentVersion"] = ApplicationVersionString;
            return true;
        }
    }
}
