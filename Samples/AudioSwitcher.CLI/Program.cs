﻿using System;
using System.IO;
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Sandbox;
using AudioSwitcher.Scripting;
using AudioSwitcher.Scripting.JavaScript;
using Jurassic;
using Jurassic.Library;

namespace AudioSwitcher.CLI
{
    internal static class Program
    {
        private static bool IsDebug;

        private static int Main(string[] args)
        {
            if (args.Length > 2 || args.Length < 1)
                return PrintUsage();

            //Process CLI Arguments
            for (var i = 0; i < args.Length - 1; i++)
            {
                switch (args[i])
                {
                    case "--debug":
                        IsDebug = true;
                        break;
                }
            }

            //Process file name
            string fName = args[args.Length - 1];
            if (!fName.EndsWith(".js"))
            {
                Console.WriteLine("Invalid input file");
                Console.WriteLine();
                return PrintUsage();
            }

            AudioController controller;

            if (IsDebug)
                controller = new SandboxAudioController(new CoreAudioDeviceEnumerator());
            else
                controller = new CoreAudioController();

            using (var engine = new JSEngine(controller))
            {


                //Enable to log to CLI
                //engine.SetGlobalValue("console", new ConsoleOutput(engine));
                //engine.InternalEngine.SetGlobalValue("console", new FirebugConsole(engine.InternalEngine));
                engine.SetOutput(new ConsoleScriptOutput());

                try
                {
                    Console.WriteLine("Executing {0}...", fName);
                    engine.Execute(new AudioSwitcher.Scripting.FileScriptSource(fName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return 0;
        }

        private static int PrintUsage()
        {
            Console.WriteLine("-----  USAGE -----");
            Console.WriteLine();
            Console.WriteLine("ascli.exe [options] inputFile");
            Console.WriteLine();
            Console.WriteLine("InputFile:");
            Console.WriteLine("Must be a valid JavaScript file, and end with .js");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("--debug (optional) - Forces Debug Audio Context. Scripts will not affect actual System Devices.");
            Console.WriteLine();
            Console.WriteLine("-----  USAGE END -----");

            return -1;
        }
    }
}