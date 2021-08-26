using System;
using System.Collections.Generic;

namespace FileMerge2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string componentsUrl = "https://api.github.com/repos/carla-villar/halzatranslations/contents";
            List<string> components = new List<string>();
            List<string> languageUrls = new List<string>();
            List<Dictionary<string, Object>> jsonList = new List<Dictionary<string, object>>();


            APIcallService.GetComponents(components, componentsUrl);

            foreach (var itemUrl in components)
            {
                APIcallService.GetComponents(languageUrls, itemUrl);
            }

            foreach (var item in languageUrls)
            {
                APIcallService.GetLanguages(jsonList, item);
            }

            foreach (var item in jsonList)
            {
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2);
                }
            }
            
        }
    }
}
