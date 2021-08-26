
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace JSONCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "DefaultLocalizedResources_ad4halza.onmicrosoft.com_B2C_1_signup_mobile_v3_api.localaccountsignup2.1_en.json";
            var jsonPath = @"C:\Users\Predrag Janevski\Desktop\ADBC\UPDATETEST\Updated\" + fileName;
            var jsonPath2 = @"C:\Users\Predrag Janevski\Desktop\ADBC\DefaultLocalizedResources_ad4halza.onmicrosoft.com_B2C_1_signup_v3_api.localaccountsignup2.1_en.json";
            var jsonWritePath = @"C:\Users\Predrag Janevski\Desktop\ADBC\UPDATETEST\Updated\" + fileName;
            var jsonEnglishPath = @"C:\Users\Predrag Janevski\Desktop\Merged languages\English base file\json\en.json";
            var jsonJSpath = @"C:\Users\Predrag Janevski\Desktop\ADBC\UPDATETEST\adb2clang.json";
            var chineseTraditional = @"C:\Users\Predrag Janevski\Desktop\Merged languages\json\zh_Hant.json";
            var chineseTraditionalGEN = @"C:\Users\Predrag Janevski\Desktop\Merged languages\json\chinese_TRADITIONAL.json";

            JSONModel.Rootobject result = new JSONModel.Rootobject();
            JSONModel.Rootobject result2 = new JSONModel.Rootobject();
            List<string> values = new List<string>();
            List<string> valuesDup = new List<string>();
            List<string> values2 = new List<string>();
            List<string> enValues = new List<string>();
            Dictionary<string, object> sampleDic = new Dictionary<string, object>();
            List<string> jsValues = new List<string>();
            Dictionary<string, string> enValuesDic = new Dictionary<string, string>();
            Dictionary<string, string> ChineseTradDic = new Dictionary<string, string>();
            Dictionary<string, string> DuplicateKeys = new Dictionary<string, string>();


            //////Filling the JavaScript JSON

            //using (StreamReader g = new StreamReader(jsonJSpath))
            //{
            //    var jsonJS = g.ReadToEnd();

            //    var dataJS = JObject.Parse(jsonJS);

            //    foreach (var item in dataJS.Properties())
            //    {
            //        //Console.WriteLine(item.Value);
            //        jsValues.Add(item.Value.ToString().ToLower());
            //    }

            //}

            //////FOR JSON FILES FOR LOCALIZE COLLECTIONS

            //using (StreamReader r = new StreamReader(jsonPath))
            //{
            //    var json = r.ReadToEnd();

            //    result = JsonSerializer.Deserialize<JSONModel.Rootobject>(json);



            //    foreach (var item in result.LocalizedCollections)
            //    {

            //        foreach (var item2 in item.Items)
            //        {

            //            if (item2.Value != null)
            //                values.Add(item2.Value.ToLower());

            //        }
            //        //dictValues.Add(item.StringId, item.Value);
            //        //if (!values.Exists(x => x == item.Value))
            //        //{
            //        //    values.Add(item.Value);
            //        //}

            //        //else
            //        //{
            //        //    valuesDup.Add(item.Value);
            //        //}
            //        //Console.WriteLine(item.Value);


            //    }
            //}

            using (StreamReader r = new StreamReader(jsonPath))
            {
                var json = r.ReadToEnd();

                result = JsonSerializer.Deserialize<JSONModel.Rootobject>(json);



                foreach (var item in result.LocalizedStrings)
                {
                    //dictValues.Add(item.StringId, item.Value);
                    //if (!values.Exists(x => x == item.Value))
                    //{
                    //    if (item.Value != null)
                    //        values.Add(item.Value);
                    //}

                    //else
                    //{
                    //    valuesDup.Add(item.Value);
                    //}
                    //Console.WriteLine(item.Value);
                    if (item.Value != null)
                        values.Add(item.Value.ToLower());

                }
            }

            using (StreamReader v = new StreamReader(jsonPath2))
            {
                var json = v.ReadToEnd();

                result2 = JsonSerializer.Deserialize<JSONModel.Rootobject>(json);



                foreach (var item in result2.LocalizedStrings)
                {
                    //dictValues.Add(item.StringId, item.Value);
                    if (item.Value != null)
                        values2.Add(item.Value.ToLower());
                    //Console.WriteLine(item.Value);

                }
            }


            //ENGLISH dictionary fill

            using (StreamReader s = new StreamReader(jsonEnglishPath))
            {
                var jsonEn = s.ReadToEnd();

                var data = JObject.Parse(jsonEn);

                //Console.WriteLine(data.Properties().ToString());

                foreach (var item in data.Properties())
                {
                    enValuesDic.Add(item.Name.ToString(), item.Value.ToString());
                    //Console.WriteLine(item.Value);
                    enValues.Add(item.Value.ToString());
                }

                //foreach (var item in enValuesDic)
                //{
                //    Console.WriteLine(item.Key);
                //}

            }

            //Cinese Traditional

            using (StreamReader s = new StreamReader(chineseTraditional))
            {
                var jsonCn = s.ReadToEnd();

                var data = JObject.Parse(jsonCn);

                //Console.WriteLine(data.Properties().ToString());

                foreach (var item in data.Properties())
                {
                    ChineseTradDic.Add(item.Name.ToString(), item.Value.ToString());
                    //Console.WriteLine(item.Value);

                }

                //foreach (var item in ChineseTradDic)
                //{
                //    Console.WriteLine(item.Key);
                //}

            }

            //Cinese Traditional GENERATED

            using (StreamReader s = new StreamReader(chineseTraditionalGEN))
            {
                var jsonCn = s.ReadToEnd();

                var data = JObject.Parse(jsonCn);

                //Console.WriteLine(data.Properties().ToString());

                foreach (var item in data.Properties())
                {
                    try
                    {
                        if(!ChineseTradDic.ContainsKey(item.Name.ToString()))
                        ChineseTradDic.Add(item.Name.ToString(), item.Value.ToString());
                        //Console.WriteLine(item.Value);
                    }
                    catch
                    {
                        
                        DuplicateKeys.Add(item.Name.ToString(), item.Value.ToString());
                    }


                }
                //Console.WriteLine("--------Chinese TRADITIONAL GENERATED-------------");
                //Console.WriteLine("--------Chinese TRADITIONAL GENERATED-------------");
                //Console.WriteLine("--------Chinese TRADITIONAL GENERATED-------------");
                //Console.WriteLine("--------Chinese TRADITIONAL GENERATED-------------");
                //foreach (var item in ChineseTradDic)
                //{
                //    Console.WriteLine(item.Key);
                //}
                //Console.WriteLine("--------DUPLICATE KEYS-------------");
                //foreach (var item in DuplicateKeys)
                //{
                //    Console.WriteLine(item.Key);
                //}

            }

            //List<string> keysThatExists = new List<string>();

            // FINDING THE KEYS WITH VALUES IN ENGLISH

            var keysThatExists = enValuesDic.Where(kvp => values.Any(y => y.ToLower().Replace(" ", "") == kvp.Value.ToLower().Replace(" ", "")))
                                            .Select(kvp => new
                                            {
                                                kvp.Key
                                            }).ToList();




            //enValuesDic.Where(x => values.Contains(x.Value));

            //CHECK IF THE KEYS EXIST IN CHINESE FOLDER AND TAKE THEM

            var chineseValue = ChineseTradDic.Where(kvp => keysThatExists.Any(z => z.Key.ToLower().Replace(" ", "") == kvp.Key.ToLower().Replace(" ", "")))
                                              .Select(kvp => new
                                              {
                                                  kvp.Key,
                                                  kvp.Value
                                              }).ToList();


            // TAKING THE VALUES FROM EXISTING CHINESE KEYS

            var englishValues = enValuesDic.Where(kvp => chineseValue.Any(x => x.Key.ToLower().Replace(" ", "") == kvp.Key.ToLower().Replace(" ", "")))
                                            .Select(kvp => new
                                            {
                                                kvp.Key,
                                                kvp.Value
                                            });



            //foreach (var item in valuesDup)
            //{
            //    Console.WriteLine(item);
            //}



            var filterValues = values.Where(x => values2.Contains(x));

            //var filterValues2 = values2.Where(v => values.Any(x => x != v)).Select(v => v);

            foreach (var filter in filterValues)
            {
                Console.WriteLine(filter);
            }


            ////JSON DELETE ITEMS

            //using (StreamReader v = new StreamReader(jsonPath))
            //{
            //    var jsonForFilter = v.ReadToEnd();


            //    //var filteredValues = values.Where(x => values2.Contains(x));

            //    var valuesObj = JsonSerializer.Deserialize<JsonObj>(jsonForFilter);




            //        //Console.WriteLine(valuesObj2["LocalizedStrings"][i]["Value"]);



            //    foreach (var item in new string[] { "ElementType", "ElementId", "StringId", "Override", "Value" })
            //    {
            //        foreach (var pair in valuesObj.LocalizedStrings)
            //        {


            //            var valuesDic = pair.Values;



            //            foreach (var KeyValuePair in valuesDic)
            //            {
            //                string conv = Convert.ToString(KeyValuePair).ToLower().Replace(" ", "");


            //                foreach (var filter in values2)
            //                {



            //                    if (filter == conv)
            //                    {


            //                        pair.Remove(item);
            //                    }
            //                }
            //            }

            //            //foreach (var item2 in pair)
            //            //{
            //            //    Console.WriteLine(item2);
            //            //}

            //        };
            //    }



            //    //CREATING JSON FILE

            //    var encoderSettings = new TextEncoderSettings();
            //    //encoderSettings.AllowCharacters('\u0026', '\u002B', '\u0027', '\u0060', '\u0022');
            //    encoderSettings.AllowRange(UnicodeRanges.BasicLatin);
            //    var options = new JsonSerializerOptions
            //    {

            //        IgnoreNullValues = false,
            //        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //        WriteIndented = true
            //    };





            //    var jsonSer = JsonSerializer.Serialize(valuesObj, options);

            //    Console.WriteLine(jsonSer);



            //    //File.WriteAllText(jsonWritePath, jsonUtf8Bytes);

            //    //File.WriteAllText(jsonWritePath, jsonSer);

            //}


            //// UPDATING JSON

            string jsonForFilter2 = File.ReadAllText(jsonPath);
            string jsonForFilter = File.ReadAllText(jsonWritePath);


            var valuesObj = JsonSerializer.Deserialize<JsonObj>(jsonForFilter2);

            /// Use this for localize collections

            //var valuesObj3 = JsonSerializer.Deserialize<JSONModel.Rootobject>(jsonForFilter2);
            ////var jsJson = JObject.Parse(jsonForFilter2);
            //List<string> valuesObj3Val = new List<string>();
            //int localCollCount = valuesObj3.LocalizedCollections.Count();
            //foreach (var items in valuesObj3.LocalizedCollections)
            //{
            //    var valuesObj3Items = items.Items;

            //    foreach (var item in valuesObj3Items)
            //    {
            //        valuesObj3Val.Add(item.Value.ToString());
            //    }


            //}



            dynamic valuesObj2 = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonForFilter);



            /// FOR JS JSON

            //foreach (var item in jsJson.Properties())
            //{
            //    foreach (var item2 in englishValues)
            //    {
            //        if(item.Value.ToString().ToLower().Replace(" ", "") == item2.Value.ToLower().Replace(" ", ""))
            //        {

            //            var chineseValForUpdate = chineseValue.Where(kvp => item2.Key.ToLower().Replace(" ", "") == kvp.Key.ToLower().Replace(" ", "")).Select(kvp => new { kvp.Value }.ToString());
            //                       var removeChars = chineseValForUpdate.First().Remove(0, 10).ToString();
            //                        var finalValue = removeChars.Remove(removeChars.Length - 2);

            //            valuesObj2[item.Name] = finalValue;
            //            string output = Newtonsoft.Json.JsonConvert.SerializeObject(valuesObj2, Newtonsoft.Json.Formatting.Indented);

            //            Console.WriteLine(output);

            //            File.WriteAllText(jsonWritePath, output);
            //        }
            //    }
            //}

            ////FOR LOCALIZED STRINGS

            //for (int i = 0; i < valuesObj.LocalizedStrings.Count; i++)
            //{

            //    string objValue = valuesObj2["LocalizedStrings"][i]["Value"];
            //    foreach (var value in englishValues)
            //    {
            //        if (value.Value.ToLower().Replace(" ", "") == objValue.ToLower().Replace(" ", ""))
            //        {
            //            var chineseValForUpdate = chineseValue.Where(kvp => value.Key.ToLower().Replace(" ", "") == kvp.Key.ToLower().Replace(" ", "")).Select(kvp => new { kvp.Value }.ToString());
            //            var removeChars = chineseValForUpdate.First().Remove(0, 10).ToString();
            //            var finalValue = removeChars.Remove(removeChars.Length - 2);

            //            valuesObj2["LocalizedStrings"][i]["Value"] = finalValue;

            //            string output = Newtonsoft.Json.JsonConvert.SerializeObject(valuesObj2, Newtonsoft.Json.Formatting.Indented);

            //            Console.WriteLine(output);

            //            File.WriteAllText(jsonWritePath, output);

            //            //Console.WriteLine("-----english VALUES------");
            //            //Console.WriteLine(value.Value);
            //            //Console.WriteLine("-----CHINESE VALUES------");
            //            //Console.WriteLine(objValue);
            //        }

            //    }

            //    //Console.WriteLine(valuesObj2["LocalizedStrings"][i]["Value"]);
            //}

            //FOR LOCALIZEDCOLLECTIONS

            //string output = "";

            //for (int j = 0; j <= valuesObj3.LocalizedCollections.Count(); j++)
            //{

            //    for (int i = 0; i <= valuesObj3Val.Count(); i++)
            //    {

            //        var objValue = valuesObj2["LocalizedCollections"][j]["Items"][i]["Value"];

            //        string objValue2 = objValue.ToString();
            //        //Console.WriteLine(objValue);
            //        foreach (var value in englishValues)
            //        {
            //            if (value.Value.ToLower().Replace(" ", "") == objValue2.ToLower().Replace(" ", ""))
            //            {
            //                var chineseValForUpdate = chineseValue.Where(kvp => value.Key.ToLower().Replace(" ", "") == kvp.Key.ToLower().Replace(" ", "")).Select(kvp => new { kvp.Value }.ToString());
            //                var removeChars = chineseValForUpdate.First().Remove(0, 10).ToString();
            //                var finalValue = removeChars.Remove(removeChars.Length - 2);

            //                valuesObj2["LocalizedCollections"][j]["Items"][i]["Value"] = finalValue;

            //                output = Newtonsoft.Json.JsonConvert.SerializeObject(valuesObj2, Newtonsoft.Json.Formatting.Indented);

            //                Console.WriteLine(output);


            //                File.WriteAllText(jsonWritePath, output);
            //                //Console.WriteLine("-----english VALUES------");
            //                //Console.WriteLine(value.Value);
            //                //Console.WriteLine("-----CHINESE VALUES------");
            //                //Console.WriteLine(objValue);
            //            }

            //        }

            //        //Console.WriteLine(valuesObj2["LocalizedStrings"][i]["Value"]);
            //    }

            //}








            //void duplicatesRemoval(Dictionary<string, object> pair, IEnumerable<string> filter, string stringItem)
            //{
            //    foreach (var item in filter)
            //    {
            //        if(item == pair.Values.ToString())
            //        {
            //            pair.Remove(stringItem);
            //        }
            //    }
            //}




            //foreach (var item in sampleList)
            //{
            //    Console.WriteLine(item);
            //}



        }
    }
}
