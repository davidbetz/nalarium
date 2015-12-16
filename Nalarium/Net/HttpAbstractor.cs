#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;
using System.IO;
using System.Net;
using System.Text;

namespace Nalarium.Net
{
    /// <summary>
    ///     Provides access to HTTP GET/POST functionality
    /// </summary>
    /// <example>
    ///     //+ HTTP GET
    ///     String getResponse = HttpAbstractor.GetWebText(new Uri("http://www.google.com"));
    ///     //+ HTTP POST
    ///     String postResponse = HttpAbstractor.PostHttpRequest(new Uri("http://www.tempuri.org/service/wcf.svc", "{ data:
    ///     'This is my service data.' }"));
    ///     //+ Binary HTTP GET
    ///     Byte[] imageData = HttpAbstractor.GetBinaryWebText(new Uri("http://www.tempuri.org/Image/Logo.jpg"));
    /// </example>
    public static class HttpAbstractor
    {
        //- @GetWebText -//
        /// <summary>
        ///     Does an HTTP GET.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public static string GetWebText(Uri uri)
        {
            return GetWebText(uri, 0);
        }

        /// <summary>
        ///     Does an HTTP GET.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="timeout">The timeout of the post.</param>
        /// <returns></returns>
        public static string GetWebText(Uri uri, int timeout)
        {
            var request = (HttpWebRequest) WebRequest.Create(uri);
            if (timeout > 0)
            {
                request.Timeout = timeout*1000;
            }
            var httpWebResponse = (HttpWebResponse) request.GetResponse();
            var rawResponse = new StringBuilder();
            using (var streamResponse = httpWebResponse.GetResponseStream())
            {
                var streamRead = new StreamReader(streamResponse);
                var readBuffer = new char[256];
                var count = streamRead.Read(readBuffer, 0, 256);
                while (count > 0)
                {
                    var resultData = new string(readBuffer, 0, count);
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
        ///     Does an HTTP POST.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string PostHttpRequest(Uri uri, string text)
        {
            return PostHttpRequest(uri, text, null, string.Empty, 0);
        }

        /// <summary>
        ///     Does an HTTP POST.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="text">The text.</param>
        /// <param name="timeout">The timeout of the post.</param>
        /// <returns></returns>
        public static string PostHttpRequest(Uri uri, string text, int timeout)
        {
            return PostHttpRequest(uri, text, null, string.Empty, timeout);
        }

        /// <summary>
        ///     Does an HTTP POST.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="headerMap">Map of header information to post.</param>
        /// <returns></returns>
        public static string PostHttpRequest(Uri uri, Map headerMap)
        {
            return PostHttpRequest(uri, string.Empty, headerMap, string.Empty, 0);
        }

        /// <summary>
        ///     Does an HTTP POST.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="text">The text.</param>
        /// <param name="contentType">The content-type of the post</param>
        /// <param name="headerMap">Map of header information to post.</param>
        /// <param name="timeout">The timeout of the post.</param>
        /// <returns></returns>
        public static string PostHttpRequest(Uri uri, string text, Map headerMap, string contentType, int timeout)
        {
            var buffer = Encoding.UTF8.GetBytes(text);
            //+
            return PostHttpRequest(uri, buffer, headerMap, contentType, timeout);
        }

        /// <summary>
        ///     Does an HTTP POST.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="buffer">The buffer to post.</param>
        /// <returns></returns>
        public static string PostHttpRequest(Uri uri, byte[] buffer)
        {
            return PostHttpRequest(uri, buffer, null, string.Empty, 0);
        }

        /// <summary>
        ///     Does an HTTP POST.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="buffer">The buffer to post.</param>
        /// <param name="headerMap">Map of header information to post.</param>
        /// <returns></returns>
        public static string PostHttpRequest(Uri uri, byte[] buffer, Map headerMap)
        {
            return PostHttpRequest(uri, buffer, headerMap, string.Empty, 0);
        }

        /// <summary>
        ///     Posts the HTTP request.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="buffer">The buffer to post.</param>
        /// <param name="contentType">The content-type of the post</param>
        /// <param name="headerMap">Map of header information to post.</param>
        /// <param name="timeout">The timeout of the post.</param>
        /// <returns></returns>
        public static string PostHttpRequest(Uri uri, byte[] buffer, Map headerMap, string contentType, int timeout)
        {
            var request = (HttpWebRequest) WebRequest.Create(uri);
            request.Method = "POST";
            if (timeout > 0)
            {
                request.Timeout = timeout*1000;
            }
            if (!string.IsNullOrEmpty(contentType))
            {
                request.ContentType = contentType;
            }
            if (headerMap != null)
            {
                var keyList = headerMap.GetKeyList();
                foreach (var key in keyList)
                {
                    request.Headers.Add(key, headerMap[key]);
                }
            }
            request.ContentLength = buffer.Length;
            using (var s = request.GetRequestStream())
            {
                s.Write(buffer, 0, buffer.Length);
                s.Close();
            }
            var httpWebResponse = (HttpWebResponse) request.GetResponse();
            var rawResponse = new StringBuilder();
            using (var streamResponse = httpWebResponse.GetResponseStream())
            {
                var streamRead = new StreamReader(streamResponse);
                var readBuffer = new char[256];
                var count = streamRead.Read(readBuffer, 0, 256);
                while (count > 0)
                {
                    var resultData = new string(readBuffer, 0, count);
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
        ///     Gets the binary data.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public static byte[] GetBinaryData(Uri uri)
        {
            var request = (HttpWebRequest) WebRequest.Create(uri);
            using (var httpWebResponse = (HttpWebResponse) request.GetResponse())
            {
                var rawResponse = new StringBuilder();
                using (var streamResponse = httpWebResponse.GetResponseStream())
                {
                    var b = 0;
                    var buffer = new byte[0];
                    while ((b = streamResponse.ReadByte()) > -1)
                    {
                        AppendByte(ref buffer, (byte) b);
                    }
                    //+
                    return buffer;
                }
            }
        }

        //- $AppendByte -//
        private static void AppendByte(ref byte[] buffer, byte b)
        {
            var tempBytes = buffer;
            if (tempBytes == null)
            {
                buffer = new[]
                {
                    b
                };
            }
            else
            {
                buffer = new byte[tempBytes.Length + 1];
                Array.Copy(tempBytes, 0, buffer, 0, tempBytes.Length);
                buffer[buffer.Length - 1] = b;
            }
        }
    }
}