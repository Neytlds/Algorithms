// See https://aka.ms/new-console-template for more information

using System;
using System.Text;

Console.WriteLine($"UCT Time: {(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds}");
Console.WriteLine($"UCT Time: {DateTime.UtcNow - new DateTime(1900, 1, 1, 0, 0, 0)}");//DateTime.Now.ToUniversalTime().ToString("r")

byte[] by = Encoding.Default.GetBytes("Public");
Console.WriteLine($"base64: {Convert.ToBase64String(by)}");
Console.WriteLine($"base64 Length: {Convert.ToBase64String(by).Length}");
