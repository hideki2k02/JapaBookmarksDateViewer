using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace JapaBookmarksDateViewer
{
    class Program
    {
        static string name = "Japa's Bookmark Date Viewer";
        static string current_version = "1.1";
        static string window_title = $"{Program.name} v{current_version} by japa4551";

        static string executable_directory = System.AppContext.BaseDirectory;

        static void Main(string[] input_file_array)
        {
            Console.Title = $"{window_title} - Awaiting User...";
            // file_array can either be from Terminal/Console or Drag-and-Drop operation

            //Console.WriteLine(Program.executable_directory);

            string[] exec_folder_html_file_array = Directory.GetFiles(Program.executable_directory, "*.html", SearchOption.TopDirectoryOnly);

            List<string> html_file_list = new List<string>();

            foreach(string input_html_file_path in input_file_array)
            {
                //Console.WriteLine(html_file);

                html_file_list.Add(input_html_file_path);
            }

            foreach(string exec_folder_html_file_path in exec_folder_html_file_array)
            {
                //Console.WriteLine(html_file);

                html_file_list.Add(exec_folder_html_file_path);
            }

            if(html_file_list.Count == 1)
            {
                Console.Write($"The program received 1 Input File from the ");
                if(input_file_array.Length == 1) Console.WriteLine("User");
                if(exec_folder_html_file_array.Length == 1) Console.WriteLine("Executable Folder");
            }

            else if(html_file_list.Count > 1)
            {
                Console.WriteLine($"The program found a total of {input_file_array.Length + exec_folder_html_file_array.Length} " +
                "HTML files: \n");

                if(input_file_array.Length >= 1) Console.WriteLine($"- {input_file_array.Length} file is from Direct Input");
                else if(input_file_array.Length > 1) Console.WriteLine($"- {input_file_array.Length} files are from Direct Input");

                if(exec_folder_html_file_array.Length >= 1) Console.WriteLine($"- {exec_folder_html_file_array.Length} file is from the executable folder");
                else if(exec_folder_html_file_array.Length > 1) Console.WriteLine($"- {exec_folder_html_file_array.Length} files are from the executable folder");
            }

            else
            {
                Console.WriteLine("Input File is empty!");

                Halt_Program();
            }

            Console.WriteLine("\nPress ENTER to generate the output file");
            Console.ReadLine();
            Console.Clear();

            Console.Title = $"{window_title} - Reading HTML files...";

            foreach(string html_file_path in html_file_list)
            {
                //Console.WriteLine(html_file_path);

                Read_HTML(html_file_path);
            }

            Halt_Program();
        }

        static DateTime Convert_UNIX_To_UTC(int input)
        {
            DateTime date_time = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
            date_time = date_time.AddSeconds(input).ToLocalTime();

            return date_time;
        }

        static void Halt_Program()
        {
            Console.Title = $"{window_title} - End.";

            Console.WriteLine("\nPress Enter to close the program.");
            Console.ReadLine();
            Environment.Exit(0);
        }

        static void Read_HTML(string input_file_path)
        {
            string input_file_name = Path.GetFileName(input_file_path);
           
            var document = new HtmlDocument();

            try
            {
                document.Load(input_file_path);

                var bookmark_nodes = document.DocumentNode.SelectNodes("//a");
                var bookmark_folders_node = document.DocumentNode.SelectNodes("//h3");

                List<string> lines = new List<string>();

                foreach(var node in bookmark_nodes)
                {
                    lines.Add($"Name: {WebUtility.HtmlDecode(node.InnerHtml)}");
                    lines.Add($"Link: {node.GetAttributeValue<string>("href", null)}");
                    lines.Add($"Date Added: {Convert_UNIX_To_UTC(node.GetAttributeValue<int>("ADD_DATE", 0))}\n");
                }
                
                File.WriteAllLines($"{Program.executable_directory}\\{input_file_name}_output.txt", lines);

                Console.WriteLine($"Success! Saved output as {input_file_name}_output.txt");
            }

            catch
            {
                Console.WriteLine($"{input_file_name} IS AN INVALID HTML FILE! (Maybe its corrupt?)");
            }
        }
    }
}
