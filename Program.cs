using System;
class MainClass
{
    public static void Main(string[] args)
    {
        string DirName = @"C:\Users";
        Console.WriteLine($"Размер папки {DirName} - {ShowFolderSize(DirName)} байт.");
    }
    static long ShowFolderSize(string dirName)
    {
        long folderSize = 0;
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            if (dirInfo.Exists)
            {
                FileInfo[] files = dirInfo.GetFiles();
                foreach (var item in files)
                {
                    folderSize += item.Length;
                }
                DirectoryInfo[] subfolders = dirInfo.GetDirectories();
                foreach (var item in subfolders)
                {
                    folderSize += ShowFolderSize(item.FullName);
                }
            }
            else 
            {
                Console.WriteLine("Указан неверный путь к директории");
            }           
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return folderSize;
    }
}
