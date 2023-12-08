using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetectionLibrary;
using Newtonsoft.Json.Linq;

namespace DetectionLibrary
{
    internal static class ZeroShot : ICLIP
    {
        /// <summary>
        /// returns a CLIPVector Object from a Bitmap
        /// </summary>
        /// <param name="img">Bitmap Image</param>
        /// <returns></returns>
        public static CLIPVector GetCLIPVector(Bitmap img)
        {
            CLIPVector result;
            //ein ZeroshotPostBodyObjekt mit der Eigenschaft Http Body kreieren.
            ZeroShotPostBody body = new(img);

            //Bypassing Error: "The SSL connection could not be established"
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            
            using (var client = new HttpClient(clientHandler))
            {
                Uri endpoint = new Uri("https://127.0.0.1:5000/vector/image");
                HttpResponseMessage response = client.PostAsync(endpoint, body.HttpBody).Result;
                result = new CLIPVector(HttpToVector(response));
            }
            return result;
        }
        private static double[] HttpToVector(HttpResponseMessage result)
        {
            List<double> vector = new List<double>();
            string resultContent = result.Content.ReadAsStringAsync().Result;
            JObject jsonResult = JObject.Parse(resultContent);
            foreach (var array in jsonResult["imageFeatures"])
            {
                foreach (double number in array)
                {
                    //Console.WriteLine(number);
                    vector.Add(number);
                }
            }
            return vector.ToArray();
        }
    }
}
