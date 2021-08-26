using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryIteration
{
    class Program
    {

        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
        static void Main(string[] args)
        {
            string languageCode = "ur";
            string mainFolder = "Urdu";
            DirectoryInfo path = new DirectoryInfo(@$"C:\Users\Predrag Janevski\Desktop\All Languages\{mainFolder}");
            

            int counter = 0;

             static string[] WalkDirectoryTree(System.IO.DirectoryInfo root, int count, string folder, string languageC)
             {
                string[] allFiles = new string[] { };
                /*string[] allFiles = new string[] { }*/
                string languageFolder = folder;
                string folderToCopy = "AllComponents";
                
                
                System.IO.FileInfo[] files = null;
                System.IO.DirectoryInfo[] subDirs = null;
                

                // First, process all the files directly under this folder
                try
                {
                    files = root.GetFiles("*.*");

                    
                }
                // This is thrown if even one of the files requires permissions greater
                // than the application provides.
                catch (UnauthorizedAccessException e)
                {
                    // This code just writes out the message and continues to recurse.
                    // You may decide to do something different here. For example, you
                    // can try to elevate your privileges and access the file again.
                   log.Add(e.Message);
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }

                if (files != null)
                {
                    
                    List<string> parts = new List<string>();
                    IEnumerable<string> names;
                    
                    foreach (System.IO.FileInfo fi in files)
                    {
                        // In this example, we only access the existing FileInfo object. If we
                        // want to open, delete or modify the file, then
                        // a try-catch block is required here to handle the case
                        // where the file has been deleted since the call to TraverseTree().

                        //var parts = fi.Name.Split(".");

                        //if parts.

                        

                        parts.Add(fi.FullName);



                        //var names = parts.Where(x => x.Split(".").Contains("ar"));

                        


                    }


                    //names = parts.Where(x => x.Split(".").Contains("ar"));

                    //var names2 = parts.Select(y => new
                    // {
                    //    ar = y.Split(".").Contains("ar"),
                    //    Arabic = y.Split(".").Contains("Arabic")
                    // });


                    //foreach (var item in names)
                    //{
                    //    //allFiles = new string[] { item.ar.ToString(),  };
                    //    Console.WriteLine(item);


                    //}
                    
                    parts.ForEach(x =>
                    {
                        if (x.Split(".").Contains(languageC) || x.Split(".").Contains(folder))
                        {

                            
                           string fileName = String.Join(@"\", x.Split('\\').Skip(9).Reverse());
                            

                            //allFiles = new string[] { x };
                            Console.WriteLine(fileName);
                            if(fileName != String.Empty)
                            {
                                string rootPathToCopy = @$"C:\Users\Predrag Janevski\Desktop\All Languages\{languageFolder}\{folderToCopy}\{fileName}";
                                if (!File.Exists(rootPathToCopy))
                                {
                                    //File.Create(rootPathToCopy);
                                    File.Copy(x, rootPathToCopy);
                                }
                                else
                                {
                                    
                                    string rootPathToCopy2 = @$"C:\Users\Predrag Janevski\Desktop\All Languages\{languageFolder}\{folderToCopy}\{count+fileName}";
                                    File.Copy(x, rootPathToCopy2);
                                   
                                }


                            }



                        }

                    });

                    


                    // Now find all the subdirectories under this directory.
                    subDirs = root.GetDirectories();

                    foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                    {
                        // Resursive call for each subdirectory.
                        count++;
                        WalkDirectoryTree(dirInfo, count, folder, languageC);
                    }

                    //foreach (var item in allFiles)
                    //{
                    //    Console.WriteLine(item);
                    //}

                   //allFiles = filesFill(parts);

                    
                };

                //foreach (var item in allFiles)
                //{
                //    Console.WriteLine(item);
                //}
                
                return  allFiles;
             } 
            
            //static string[] filesFill (List<string> fileList)
            //{
            //    string[] fillFiles = new string[] { };
            //    fileList.ForEach(x =>
            //    {
            //        if (x.Split(".").Contains("en_GB") || x.Split(".").Contains("English-UK"))
            //        {
            //            fillFiles = new string[] { x };

                        
            //        }
                    
            //    });
                
            //    return fillFiles;
            //}




            WalkDirectoryTree(path, counter, mainFolder, languageCode);
            

        }


    }
}
