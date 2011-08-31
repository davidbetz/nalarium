#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Nalarium.Net
{
    /// <summary>
    /// Provides access to HTTP GET/POST functionality
    /// </summary>
    /// <example>
    /// //+ HTTP GET
    /// String getResponse = HttpAbstractor.GetWebText(new Uri("http://www.google.com"));
    /// //+ HTTP POST
    /// String postResponse = HttpAbstractor.PostHttpRequest(new Uri("http://www.tempuri.org/service/wcf.svc", "{ data: 'This is my service data.' }"));
    /// //+ Binary HTTP GET
    /// Byte[] imageData = HttpAbstractor.GetBinaryWebText(new Uri("http://www.tempuri.org/Image/Logo.jpg"));
    /// </example>
    public static class HttpAbstractor
    {
        //- @GetWebText -//
        /// <summary>
        /// Does an HTTP GET.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public static String GetWebText(Uri uri)
        {
            return GetWebText(uri, 0);
        }

        /// <summary>
        /// Does an HTTP GET.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="timeout">The timeout of the post.</param>
        /// <returns></returns>
        public static String GetWebText(Uri uri, Int32 timeout)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            if (timeout > 0)
            {
                request.Timeout = timeout * 1000;
            }
            var httpWebResponse = (HttpWebResponse)request.GetResponse();
            var rawResponse = new StringBuilder();
            using (Stream streamResponse = httpWebResponse.GetResponseStream())
            {
                var streamRead = new StreamReader(streamResponse);
                var readBuffer = new Char[256];
                Int32 count = streamRead.Read(readBuffer, 0, 256);
                while (count > 0)
                {
                    var resultData = new String(readBuffer, 0, count);
                    rawResponse.Append(resultData);
                    count = streamRead.Read(readBuffer, 0, 256);
                }
                //+
                httpWebResponse.Close();
            }
            //+
            return rawResponse.ToString();
        }

        //- @PostHttpRequest -//
        /// <summary>
        /// Does an HTTP POST.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static String PostHttpRequest(Uri uri, String text)
        {
            return PostHttpRequest(uri, text, null, String.Empty, 0);
        }

        /// <summary>
        /// Does an HTTP POST.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="text">The text.</param>
        /// <param name="timeout">The timeout of the post.</param>
        /// <returns></returns>
        public static String PostHttpRequest(Uri uri, String text, Int32 timeout)
        {
            return PostHttpRequest(uri, text, null, String.Empty, timeout);
        }

        /// <summary>
        /// Does an HTTP POST.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="headerMap">Map of header information to post.</param>
        /// <returns></returns>
        public static String PostHttpRequest(Uri uri, Map headerMap)
        {
            return PostHttpRequest(uri, String.Empty, headerMap, String.Empty, 0);
        }

        /// <summary>
        /// Does an HTTP POST.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="text">The text.</param>
        /// <param name="contentType">The content-type of the post</param>
        /// <param name="headerMap">Map of header information to post.</param>
        /// <param name="timeout">The timeout of the post.</param>
        /// <returns></returns>
        public static String PostHttpRequest(Uri uri, String text, Map headerMap, String contentType, Int32 timeout)
        {
            Byte[] buffer = Encoding.UTF8.GetBytes(text);
            //+
            return PostHttpRequest(uri, buffer, headerMap, contentType, timeout);
        }

        /// <summary>
        /// Does an HTTP POST.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="buffer">The buffer to post.</param>
        /// <returns></returns>
        public static String PostHttpRequest(Uri uri, Byte[] buffer)
        {
            return PostHttpRequest(uri, buffer, null, String.Empty, 0);
        }

        /// <summary>
        /// Does an HTTP POST.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="buffer">The buffer to post.</param>
        /// <param name="headerMap">Map of header information to post.</param>
        /// <returns></returns>
        public static String PostHttpRequest(Uri uri, Byte[] buffer, Map headerMap)
        {
            return PostHttpRequest(uri, buffer, headerMap, String.Empty, 0);
        }

        /// <summary>
        /// Posts the HTTP request.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="buffer">The buffer to post.</param>
        /// <param name="contentType">The content-type of the post</param>
        /// <param name="headerMap">Map of header information to post.</param>
        /// <param name="timeout">The timeout of the post.</param>
        /// <returns></returns>
        public static String PostHttpRequest(Uri uri, Byte[] buffer, Map headerMap, String contentType, Int32 timeout)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            if (timeout > 0)
            {
                request.Timeout = timeout * 1000;
            }
            if (!String.IsNullOrEmpty(contentType))
            {
                request.ContentType = contentType;
            }
            if (headerMap != null)
            {
                List<String> keyList = headerMap.GetKeyList();
                foreach (String key in keyList)
                {
                    request.Headers.Add(key, headerMap[key]);
                }
            }
            request.ContentLength = buffer.Length;
            using (Stream s = request.GetRequestStream())
            {
                s.Write(buffer, 0, buffer.Length);
                s.Close();
            }
            var httpWebResponse = (HttpWebResponse)request.GetResponse();
            var rawResponse = new StringBuilder();
            using (Stream streamResponse = httpWebResponse.GetResponseStream())
            {
                var streamRead = new StreamReader(streamResponse);
                var readBuffer = new Char[256];
                Int32 count = streamRead.Read(readBuffer, 0, 256);
                while (count > 0)
                {
                    var resultData = new String(readBuffer, 0, count);
                    rawResponse.Append(resultData);
                    count = streamRead.Read(readBuffer, 0, 256);
                }
                httpWebResponse.Close();
            }
            //+
            return rawResponse.ToString();
        }

        //- @GetBinaryData -//
        /// <summary>
        /// Gets the binary data.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public static Byte[] GetBinaryData(Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            using (var httpWebResponse = (HttpWebResponse)request.GetResponse())
            {
                var rawResponse = new StringBuilder();
                using (Stream streamResponse = httpWebResponse.GetResponseStream())
                {
                    Int32 b = 0;
                    var buffer = new Byte[0];
                    while ((b = streamResponse.ReadByte()) > -1)
                    {
                        AppendByte(ref buffer, (Byte)b);
                    }
                    //+
                    return buffer;
                }
            }
        }

        //- $AppendByte -//
        private static void AppendByte(ref Byte[] buffer, Byte b)
        {
            Byte[] tempBytes = buffer;
            if (tempBytes == null)
            {
                buffer = new[]
                         {
                             b
                         };
            }
            else
            {
                buffer = new Byte[tempBytes.Length + 1];
                Array.Copy(tempBytes, 0, buffer, 0, tempBytes.Length);
                buffer[buffer.Length - 1] = b;
            }
        }
    }
}