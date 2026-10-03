using sem_1_lab_03_report_generator.Models;

namespace sem_1_lab_03_report_generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<DiscordLog> logList = new List<DiscordLog>();
            if (File.Exists("event_server.log"))
            {
                string[] logLines = File.ReadAllLines("event_server.log");
                foreach (string line in logLines)
                {
                    logList.Add(new DiscordLog(line));
                }
                Console.WriteLine("Логи успешно обработаны");


            }
            else {
                Console.WriteLine("Файл с логами не обнаружен. выводим базовый лог");
                DiscordLog log = new DiscordLog("2026-09-09 11:11:23.113 [info][user] Cheese was died(");
                Console.WriteLine(log.time);
                Console.WriteLine(log.logType);
                Console.WriteLine(log.logObject);
                Console.WriteLine(log.message);
            }

        }
    }
}
