using System;
using System.IO;

namespace MonoFSWatcherBug {
    class Program {
        static void Main(string[] args) {
            bool normal = args.Length == 1 && args[0] == "-n";

            string watchedDirectoryPath = MakeDirs(64, 63, normal ? 0 : 1);
            using(var watcher = new FileSystemWatcher(watchedDirectoryPath)) {
                SetupWatcher(watcher);
                Console.WriteLine($"Watching for the directory. Press any key to exit...");
                Console.ReadKey();
            }
            Directory.Delete(watchedDirectoryPath, recursive: true);
        }

        static void SetupWatcher(FileSystemWatcher watcher) {
            watcher.NotifyFilter = NotifyFilters.LastAccess;
            watcher.Changed += (s, e) => Console.WriteLine($"{e.ChangeType} {e.FullPath}");
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }

        static string MakeDirs(int level2Dirs, int level1Dirs, int level0Dirs) {
            var workingDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            int actualDirs = 1;
            for(int i = 0; i < level0Dirs; i++) {
                Directory.CreateDirectory(Path.Combine(workingDirectory, Path.GetRandomFileName()));
                actualDirs++;
            }
            for(int level1Index = 0; level1Index < level1Dirs; level1Index++) {
                var level1DirName = Path.GetRandomFileName();
                actualDirs++;
                for(int level2Index = 0; level2Index < level2Dirs; level2Index++) {
                    var level2DirName = Path.GetRandomFileName();
                    Directory.CreateDirectory(Path.Combine(workingDirectory, level1DirName, level2DirName));
                    actualDirs++;
                }
            }
            Console.WriteLine($"Created {actualDirs} directories inside '{workingDirectory}'");
            return workingDirectory;
        }
    }
}
