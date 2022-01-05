using System;
using System.Diagnostics;
using System.IO;

namespace AbyssMothGames.LawnMowerWorld.Helpers
{
    public sealed class Diagnostics
    {
        public const string defaultPath = @"E:\Rimuru\Work\Unity\FromGit\Low-poly-lawn\Low poly lawn\Log\Method Diagnostics.txt";

        public static void MethodRuntimeDiagnosticse(Action method, string message)
        {
            UnityEngine.Debug.Log(message);

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            {
                method();
            }
            stopwatch.Stop();

            UnityEngine.Debug.Log($"{DateTime.Now} - {message}\n Result->Class:{(method.Method.DeclaringType)}->Method{method.Method.Name} = [{stopwatch.Elapsed} || {stopwatch.ElapsedMilliseconds}]\n\n");
        }

        public static async void MethodRuntimeDiagnosticse(Action method, string message, bool isWriteToFile = false, string defaultPath = defaultPath)
        {
            if (isWriteToFile == true)
            {
                var stopwatch = new Stopwatch();

                stopwatch.Start();
                {
                    method();
                }
                stopwatch.Stop();

                using (StreamWriter sw = new StreamWriter(defaultPath, true, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync($"{DateTime.Now} - {message}\n Result->Class:{(method.Method.DeclaringType)}->Method{method.Method.Name} = [{stopwatch.Elapsed} || {stopwatch.ElapsedMilliseconds}]\n\n");
                }
            }

            if (isWriteToFile == false)
                MethodRuntimeDiagnosticse(method, message);
        }
    }
}