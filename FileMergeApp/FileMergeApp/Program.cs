using System;
using System.Text;
using System.Drawing;
using System.Resources;
using System.Collections.Generic;
using ICSharpCode.Decompiler.Util;
using ResXResourceWriter = System.Resources.ResXResourceWriter;
using System.Collections;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace FileMergeApp
{
    class Program
    {
       

        static void Main(string[] args)
        {
            //string allLanguagesPath2 = @"C:\Users\Predrag Janevski\Desktop\All Languages";
            //string[] pathnames = Directory.GetDirectories(allLanguagesPath2).Select(Path.GetFileName).ToArray();

            //foreach (var folderNames in pathnames)
            //{
            //    string folderName = folderNames;
            //    string languageCode = FolderConvert(folderNames);
            //    string templatePath = @"C:\Users\Predrag Janevski\Desktop\FileMergeApp\FileMergeApp\Templates\" + languageCode + ".resx";
            //    string newFilePath = @"C:\Users\Predrag Janevski\Desktop\Merged languages\resx\" + languageCode + ".resx";
            //    string jsonPath = @"C:\Users\Predrag Janevski\Desktop\Merged languages\json\" + languageCode + ".json";
            //    string allLanguagesPath = @$"C:\Users\Predrag Janevski\Desktop\All Languages\{folderName}\AllComponents";

            //    string[] files =
            //    Directory.GetFiles(allLanguagesPath);

            //    XDocument xd;

            //    using (FileStream fs = new FileStream(templatePath, FileMode.Open, FileAccess.ReadWrite))
            //    {


            //        var distinctWordDictionary = new Dictionary<string, string>();
            //        var jsonDictionary = new Dictionary<string, string>();
            //        xd = XDocument.Load(fs);
            //        XElement elm;


            //        foreach (string item in files)
            //        {
            //            using (ResXResourceReader resxReader = new ResXResourceReader(item))
            //            {

            //                foreach (DictionaryEntry entry in resxReader)

            //                {

            //                    if (!distinctWordDictionary.ContainsKey(entry.Key.ToString().Replace(" ", "")))
            //                        distinctWordDictionary.Add(entry.Key.ToString().Replace(" ", ""), entry.Value.ToString());
            //                }

            //            }

            //        }

            //        var distinctlist = distinctWordDictionary.Keys.Distinct(StringComparer.OrdinalIgnoreCase).ToList();



            //        distinctWordDictionary.Where(x => distinctlist.Contains(x.Key.Replace(" ", ""))).ToList().ForEach(word =>
            //        {

            //            elm = new XElement("data"
            //           , new XAttribute("name", word.Key.Replace(" ", ""))
            //           , new XAttribute(XNamespace.Xml + "space", "preserve")
            //           , new XElement("value", word.Value));

            //            xd.Root.Add(elm);

            //            if (!jsonDictionary.ContainsKey(word.Key.Replace(" ", "")))
            //                jsonDictionary.Add(word.Key.Replace(" ", ""), word.Value);

            //        });

            //        StringWriter sw = new StringWriter();
            //        XmlTextWriter xw = new XmlTextWriter(sw);

            //        using FileStream fsx = File.Create(newFilePath);


            //        xd.Save(fsx);
            //        var jsonString = JsonConvert.SerializeObject(jsonDictionary);
            //        File.WriteAllText(jsonPath, jsonString);

            //        UTF8Encoding encoding = new UTF8Encoding();

            //        byte[] docAsBytes = encoding.GetBytes(xd.ToString());



            //    }

            //}



            //static async void GetFunc()
            //{
            //    string token = "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";
            //    using (HttpClient client = new HttpClient())
            //    {
            //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //        client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");//Set the User Agent to "request"

            //        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);

            //        using (HttpResponseMessage response = client.GetAsync("https://raw.githubusercontent.com/carla-villar/halzatranslations/master/BodyFatPercentage/BodyFatPercentage.ar.resx?token=AUBCBKOY2O6PK5XX5MGXUGDAZC26Y").Result)
            //        {
            //            response.EnsureSuccessStatusCode();
            //            var responseBody = await response.Content.ReadAsByteArrayAsync();
            //            string str = Encoding.Default.GetString(responseBody);
            //            var jSon = JsonConvert.DeserializeObject<List<Dictionary<string, Object>>>(str);
            //            Console.WriteLine(response.StatusCode);
            //            foreach (var item in jSon)
            //            {
            //                foreach (var item2 in item)
            //                {
            //                    Console.WriteLine(item2);
            //                };
            //            }

            //        }
            //    }

            //}

            //static async void GetFunc()
            //{
            //    string login = "pedza";
            //    string pass = "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";
            //    var productInformation = new Octokit.ProductHeaderValue(GitHubIdentity);
            //    var credetntials = new Octokit.Credentials(login, pass, Octokit.AuthenticationType.Basic);
            //    var client = new Octokit.GitHubClient(productInformation) { Credentials = credetntials };
            //    //var client = new Octokit.GitHubClient(productInformation);

            //    Console.WriteLine(client.User.Get(login).Result);

            //    Octokit.Repository repository = await client.Repository.Get("pedza", "TestDevProject");

            //    Octokit.SearchCodeResult result = await client.Search.SearchCode(
            //        new Octokit.SearchCodeRequest("English")
            //        {
            //            In = new Octokit.CodeInQualifier[] {Octokit.CodeInQualifier.Path},
            //            Repos = new Octokit.RepositoryCollection { "pedza/TestDevProject" }
            //        });

            //    Console.WriteLine(repository.FullName);

            //    Console.WriteLine(result.Items);

            //}



            //GetFunc();

            string folderName = "English for Traditional";
            string languageCode = "en";
            string templatePath = @"C:\Users\Predrag Janevski\Desktop\FileMergeApp\FileMergeApp\Templates\" + languageCode + ".resx";
            string newFilePath = @"C:\Users\Predrag Janevski\Desktop\Chinese Simplified Adjust\English for Traditional\New en\" + languageCode + ".resx";
            string jsonPath = @"C:\Users\Predrag Janevski\Desktop\Merged languages\json\" + languageCode + ".json";
            string allLanguagesPath = @$"C:\Users\Predrag Janevski\Desktop\Chinese Simplified Adjust\{folderName}";

            string[] files =
            Directory.GetFiles(allLanguagesPath);

            XDocument xd;

            using (FileStream fs = new FileStream(templatePath, FileMode.Open, FileAccess.ReadWrite))
            {


                var distinctWordDictionary = new Dictionary<string, string>();
                var jsonDictionary = new Dictionary<string, string>();
                xd = XDocument.Load(fs);
                XElement elm;


                foreach (string item in files)
                {
                    using (ResXResourceReader resxReader = new ResXResourceReader(item))
                    {

                        foreach (DictionaryEntry entry in resxReader)

                        {

                            if (!distinctWordDictionary.ContainsKey(entry.Key.ToString().Replace(" ", "")))
                                distinctWordDictionary.Add(entry.Key.ToString().Replace(" ", ""), entry.Value.ToString());
                        }

                    }

                }

                var distinctlist = distinctWordDictionary.Keys.Distinct(StringComparer.OrdinalIgnoreCase).ToList();



                distinctWordDictionary.Where(x => distinctlist.Contains(x.Key.Replace(" ", ""))).ToList().ForEach(word =>
                {

                    elm = new XElement("data"
                   , new XAttribute("name", word.Key.Replace(" ", ""))
                   , new XAttribute(XNamespace.Xml + "space", "preserve")
                   , new XElement("value", word.Value));

                    xd.Root.Add(elm);

                    if (!jsonDictionary.ContainsKey(word.Key.Replace(" ", "")))
                        jsonDictionary.Add(word.Key.Replace(" ", ""), word.Value);

                });

                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);

                using FileStream fsx = File.Create(newFilePath);


                xd.Save(fsx);
                var jsonString = JsonConvert.SerializeObject(jsonDictionary);
                File.WriteAllText(jsonPath, jsonString);

                UTF8Encoding encoding = new UTF8Encoding();

                byte[] docAsBytes = encoding.GetBytes(xd.ToString());



            }


            ////to see the difference in keys between two resx files

            //string testPath = @"C:\Users\Predrag Janevski\Desktop\IVF misisng translations\IVF_Translations_Missing.resx";

            //string originalPath = @"C:\Users\Predrag Janevski\Desktop\Merged languages\resx\Proper named files\Translations.resx";

            //string resultPath = @"C:\Users\Predrag Janevski\Desktop\IVF misisng translations\result.txt";

            //ResXResourceReader rsxr1 = new ResXResourceReader(testPath);
            //ResXResourceReader rsxr2 = new ResXResourceReader(originalPath);

            //List<string> testList = new List<string>();
            //List<string> originalList = new List<string>();
            //List<string> forRepeatingKey = new List<string>();

            //int numberOfDuplicateKeys = 0;

            //// Iterate through the resources and write the contents
            //foreach (DictionaryEntry d1 in rsxr1)
            //{
            //    string key1 = d1.Key.ToString().ToLower().Replace(" ", "");

            //    if (!testList.Contains(key1))
            //        testList.Add(key1);
            //    else forRepeatingKey.Add(key1);


            //}

            //foreach (var item in forRepeatingKey)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (DictionaryEntry d2 in rsxr2)
            //{
            //    string key2 = d2.Key.ToString().ToLower().Replace(" ", "");
            //    originalList.Add(key2);
            //}

            //IEnumerable<string> differenceKeys = testList.Except(originalList);

            //IEnumerable<string> duplicateKeys = testList.Where(x => originalList.Contains(x.ToLower().Replace(" ", "")));

            //foreach (var item in duplicateKeys)
            //{
            //    Console.WriteLine(item);
            //    numberOfDuplicateKeys++;
            //}

            //Console.WriteLine("-----------------------------------------------------------------------------");

            //Console.WriteLine($"Number of duplicate keys {numberOfDuplicateKeys}");

            //foreach (string s in duplicateKeys)
            //{


            //    //Byte[] info = new UTF8Encoding(true).GetBytes(s);
            //    //var resultFile = File.Create(resultPath);
            //    //resultFile.Write(info);
            //    //resultFile.Flush();
            //    //resultFile.Close();

            //    TextWriter tsw = new StreamWriter(resultPath, true);

            //    tsw.Write(s + " | ");
            //    tsw.Flush();
            //    tsw.Close();

            //    //using (FileStream fs = new FileStream(resultPath, FileMode.Create, FileAccess.ReadWrite))
            //    //{
            //    //    File.WriteAllText(resultPath, key2);

            //    //}



            //    //    //}

            //    //}


            //}

            string FolderConvert(string name)
            {
                switch (name)
                {
                    case "Arabic":
                        return "ar";

                    case "Bengali":
                        return "bn";
                    case "Burmese":
                        return "my";

                    case "Central Khimer":
                        return "km";
                    case "Chinese Simplified":
                        return "zh_Hans";
                    case "Chinese Simplified Gen":
                        return "chinese_SIMPLIFIED";
                    case "Chinese Traditional":
                        return "zh_Hant";
                    case "Chinese Traditional Gen":
                        return "chinese_TRADITIONAL";
                    case "Dutch":
                        return "nl";
                    case "English":
                        return "en";
                    case "English-UK":
                        return "en_GB";
                    case "Filipino":
                        return "fil";
                    case "Flemish":
                        return "nl_BE";
                    case "French":
                        return "fr";
                    case "German":
                        return "de";
                    case "Hebrew":
                        return "he";
                    case "Hindi":
                        return "hi";
                    case "Indonesian":
                        return "id";
                    case "Italian":
                        return "it";
                    case "Japanese":
                        return "ja";
                    case "Korean":
                        return "ko";
                    case "Macedonian":
                        return "mk";
                    case "Malay":
                        return "ms";
                    case "Portuguese":
                        return "pt";
                    case "Russian":
                        return "ru";
                    case "Spanish":
                        return "es";
                    case "Swedish":
                        return "sv";
                    case "Thai":
                        return "th";
                    case "Turkish":
                        return "tr";
                    case "Urdu":
                        return "ur";
                    case "Vietnamese":
                        return "vi";

                }
                return "";
            }
        }
    }
}
