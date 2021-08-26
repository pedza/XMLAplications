using System;
using System.IO;
using System.Linq;
using System.Xml;

namespace XMLDuplicateKeysRemovalApp
{
    class Program
    {
        static void Main(string[] args)

            
        {
            string gitHubRepoPath = @"C:\Users\Predrag Janevski\Desktop\Github Halzatranslations Project\halzatranslations\Translations_1005_2020";

            string allLanguagesFolder = @"C:\Users\Predrag Janevski\Desktop\Merged languages\resx\Proper named files";

            string missingTrans1601_2020IT = @"C:\Users\Predrag Janevski\Desktop\Offline copy for cleaning duplicate keys\halzatranslations\Missing_translations_1601_2020_IT";

            string clinicPortalPath = @"C:\Users\Predrag Janevski\Desktop\Offline copy for cleaning duplicate keys\halzatranslations\ClinicPortal Resx";

            string conciergePortalPath = @"C:\Users\Predrag Janevski\Desktop\Offline copy for cleaning duplicate keys\halzatranslations\ConciergePortal Resx";

            string userPortal = @"C:\Users\Predrag Janevski\Desktop\Offline copy for cleaning duplicate keys\halzatranslations\UserPortal resx";

            string halzaMobRebornPath = @"C:\Users\Predrag Janevski\Desktop\Offline copy for cleaning duplicate keys\halzatranslations\HalzaMobReborn Resx";

            string translationRequestEoinus = @"C:\Users\Predrag Janevski\Desktop\Offline copy for cleaning duplicate keys\halzatranslations\Translation_request_EONUS";

            string signinSignUpTransPath = @"C:\Users\Predrag Janevski\Desktop\Offline copy for cleaning duplicate keys\halzatranslations\Signup_Signin_translations";

            string missingTranslations1901_2020 = @"C:\Users\Predrag Janevski\Desktop\Offline copy for cleaning duplicate keys\halzatranslations\Missing_translations_1901_2020_VN";

            string translations1006_2020 = @"C:\Users\Predrag Janevski\Desktop\Offline copy for cleaning duplicate keys\halzatranslations\Translations_1006_2020";

            string[] componentPaths = { /*clinicPortalPath,*/ /*conciergePortalPath,*/ /*userPortal,*/ /*halzaMobRebornPath,*/ /*translationRequestEoinus,*/ /*missingTranslations1901_2020,*/ /*signinSignUpTransPath,*/ /*missingTrans1601_2020IT ,*/ /*translations1006_2020*/ /*allLanguagesFolder,*/ gitHubRepoPath };

            string nodeName = $"data[@name='3PageIntroTrackMonitorTitle']";

            string nodeUpdate = "PageIntroTrackMonitorTitle";
                
            //var componentFolder = Directory.GetFiles(userPortal);
                     
            //var fileName = Path.GetFileName(clinicPortalPath);

            //Console.WriteLine(fileName);

           

            directoryItteretion(componentPaths, "Database", nodeName.ToString(), nodeUpdate);

            //foreach (var file in componentFolder)
            //{
            //    DeleteKey(file, nodeName);
            //}

            


        }

        static void DeleteKey(string filePath, string nodeName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            
            var root = doc.SelectSingleNode("root");

            var tgtnode = root.SelectSingleNode(nodeName);

            if(tgtnode != null)
            {
                root.RemoveChild(tgtnode);
                

                doc.Save(filePath);

                Console.WriteLine($"Deleted {tgtnode.Attributes} in {filePath}");
            }
            else
            {
                Console.WriteLine($"node --ALREADY DELETED-- from {Path.GetFileName(filePath)} in {Directory.GetParent(filePath)}");
            }

            
            
        }

        static void UpdateKey(string filePath, string nodeName, string nodeUpdate)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            var root = doc.SelectSingleNode("root");

            var tgtByAttr = root.SelectSingleNode(nodeName);




            if (tgtByAttr != null)
            {
                var attr = tgtByAttr.Attributes.GetNamedItem("name");

                attr.Value = nodeUpdate;

                doc.Save(filePath);
                
                Console.WriteLine($"Updated {tgtByAttr.Attributes} in {filePath}");
            }
            else
            {
                Console.WriteLine($"node --Does NOT EXIST-- from {Path.GetFileName(filePath)} in {Directory.GetParent(filePath)}");
            }



        }


        static void directoryItteretion(string[] paths, string componentName, string nodeName, string nodeUpdate)
        {
            foreach (var path in paths)
            {
                var fileName = Path.GetFileName(path);
                var directoryName = fileName.Split();
                directoryName = directoryName.Where(x => x != "Resx").ToArray();
                var componentFolder = Directory.GetFiles(path);

                if (!directoryName.Contains(componentName))
                {
                    foreach (var file in componentFolder)
                    {
                        //DeleteKey(file, nodeName);
                        UpdateKey(file, nodeName, nodeUpdate);
                    }

                }
                else
                {
                    Console.WriteLine("---------------------------------------------------------------------------------");
                    Console.WriteLine("---------------------------------------------------------------------------------");
                    Console.WriteLine($"This is {componentName} didnt delete anything");
                    Console.WriteLine("---------------------------------------------------------------------------------");
                    Console.WriteLine("---------------------------------------------------------------------------------");
                }

                //foreach (var item in directoryName)
                //{
                //    if(item != componentName)
                //    {
                        
                        
                //    }
                //}


            }
        }
    }
}
