using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem_1_lab_03_report_generator.Models
{
    public enum LogType
    {
        Info,
        Warning,
        Error
    }
    public enum LogObject
    {
        Unknown,
        User,
        Server,
        Event
    }

    public class DiscordLog
    {
        // Время лога
        public DateTime time;
        // Тип лога
        public LogType logType;
        // Объект лога
        public LogObject logObject;
        // Сообщение лога
        public string message;

        /// <summary>
        /// Создание пустого лога
        /// </summary>
        private DiscordLog()
        {
            time = DateTime.MinValue;
            logType = 0;
            logObject = 0;
            message = string.Empty;
        }
        /// <summary>
        /// Парсит строку лога в класс
        /// </summary>
        /// <param name="logLine">строка лога</param>
        public DiscordLog(string logLine)
        {
            //Нахождение раздела строк
            int indexTime1 = logLine.IndexOf(' ');
            int indexTime2 = logLine.IndexOf(' ', indexTime1 + 1);
            int indexOpenType = logLine.IndexOf('[');
            int indexCloseType = logLine.IndexOf(']');
            int indexOpenObject = logLine.IndexOf('[', indexOpenType + 1);
            int indexCloseObject = logLine.IndexOf(']', indexCloseType + 1);
            int indexMessage = logLine.IndexOf(' ', indexTime2 + 1);
            //Подстроки
            string timeString = logLine.Substring(0, indexTime2);
            string typeString = logLine.Substring(indexOpenType + 1, indexCloseType - indexOpenType - 1);
            string objectString = logLine.Substring(indexOpenObject + 1, indexCloseObject - indexOpenObject - 1);
            string message = logLine.Substring(indexMessage + 1, logLine.Length - indexMessage - 1);
            //Перевод в данные
            LogType type = new LogType();
            switch (typeString)
            {
                case "warning":
                    type = LogType.Warning;
                    break;
                case "error":
                    type = LogType.Error;
                    break;
                default:
                    type = LogType.Info;
                    break;
            }
            LogObject @object = new LogObject();
            switch (objectString)
            {
                case "user":
                    @object = LogObject.User;
                    break;
                case "server":
                    @object = LogObject.Server;
                    break;
                case "event":
                    @object = LogObject.Event;
                    break;
                default:
                    @object = LogObject.Unknown;
                    break;
            }
            DateTime logTime = DateTime.Parse(timeString);
            //Создание экземпляра класса
            this.time = logTime;
            this.logType = type;
            this.logObject = @object;
            this.message = message;
        }


    }
}
