#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;

namespace Nalarium.Reporting
{
    /// <summary>
    /// Provides a quick mechanism to send though predefined reporters
    /// </summary>
    /// <example>
    ///  //+ exception report
    ///  try
    ///  {
    ///      throw new ArgumentOutOfRangeException("You didn't check something!");
    ///  }
    ///  catch (ArgumentException ex)
    ///  {
    ///      ReportFacade.Send(ex);
    ///  }
    ///  
    ///  //+ String report
    ///  ReportFacade.Send("Error in module 3");
    ///  
    ///  //+ Object array report
    ///  ReportFacade.Send("ObjectArray", "Error in module 3", new Object[] { 1, 2, "Three", 4, "Cinco" });
    /// </example>
    public static class ReportFacade
    {
        //- @Send -//
        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public static void Send(String message)
        {
            ReportController.Create("String", "Email", "Wiki").SendSingle(message);
        }

        /// <summary>
        /// Sends the specified map.
        /// </summary>
        /// <param name="map">The map to send.</param>
        public static void Send(Map map)
        {
            ReportController.Create("Map", "Email", "Wiki").SendSingle(map);
        }

        /// <summary>
        /// Sends the specified exception.
        /// </summary>
        /// <param name="map">The exception to send.</param>
        public static void Send(Exception ex)
        {
            ReportController.Create("Exception", "Email", "Wiki").SendSingle(ex);
        }

        /// <summary>
        /// Sends the specified object array.
        /// </summary>
        /// <param name="objectArray">The object array to send.</param>
        public static void Send(Object[] objectArray)
        {
            ReportController.Create("ObjectArray", "Email", "Wiki").SendSingle(objectArray);
        }

        /// <summary>
        /// Sends the specified report creator type.
        /// </summary>
        /// <param name="reportCreatorType">Type of the report creator.</param>
        /// <param name="parameterArray">The parameter array.</param>
        public static void Send(String reportCreatorType, Object[] objectArray)
        {
            BuildAndSend(reportCreatorType, objectArray, false);
        }

        //- @SendAsHtml -//
        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public static void SendAsHtml(String message)
        {
            ReportController.Create("String", "Email", "Html").SendSingle(message);
        }

        /// <summary>
        /// Sends the specified map.
        /// </summary>
        /// <param name="map">The map to send.</param>
        public static void SendAsHtml(Map map)
        {
            ReportController.Create("Map", "Email", "Wiki").SendSingle(map);
        }

        /// <summary>
        /// Sends the specified exception
        /// </summary>
        /// <param name="map">The exception to send.</param>
        public static void SendAsHtml(Exception ex)
        {
            ReportController.Create("Exception", "Email", "Html").SendSingle(ex);
        }

        /// <summary>
        /// Sends the specified object array.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="objectArray">The object array to send.</param>
        public static void SendAsHtml(Object[] objectArray)
        {
            ReportController.Create("ObjectArray", "Email", "Html").SendSingle(objectArray);
        }

        /// <summary>
        /// Sends as HTML.
        /// </summary>
        /// <param name="reportCreatorType">Type of the report creator.</param>
        /// <param name="message">The message.</param>
        /// <param name="data">The data.</param>
        public static void SendAsHtml(String reportCreatorType, Object data)
        {
            BuildAndSend(reportCreatorType, data, true);
        }

        //- $BuildAndSend -//
        private static void BuildAndSend(String reportCreatorType, Object data, Boolean useHtml)
        {
            ReportController.Create(reportCreatorType, "Email", useHtml ? "Html" : "Wiki").SendSingle(data);
        }
    }
}