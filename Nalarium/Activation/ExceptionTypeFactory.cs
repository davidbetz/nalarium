#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
using System.Security;
using System.Security.AccessControl;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using Microsoft.SqlServer.Server;

namespace Nalarium.Activation
{
    /// <summary>
    ///     Factory used to create exception type instances.
    /// </summary>
    public class ExceptionTypeFactory : TypeFactory
    {
        //- @CreateObject -//
        /// <summary>
        ///     Creates an exception type based on type alias.
        /// </summary>
        /// <param name="text">Alias of the type.</param>
        /// <returns>Type of the exception.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode")]
        public override Type CreateType(string text)
        {
            Type ex = null;
            switch (text)
            {
                case "system":
                    return TypeCache.InlineRegister(typeof (SystemException));
                case "outofmemory":
                    return TypeCache.InlineRegister(typeof (OutOfMemoryException));
                case "stackoverflow":
                    return TypeCache.InlineRegister(typeof (StackOverflowException));
                case "datamisaligned":
                    return TypeCache.InlineRegister(typeof (DataMisalignedException));
                //case "executionengine":
                //    return TypeCache.InlineRegister(typeof (ExecutionEngineException));
                case "memberaccess":
                    return TypeCache.InlineRegister(typeof (MemberAccessException));
                case "accessviolation":
                    return TypeCache.InlineRegister(typeof (AccessViolationException));
                case "application":
                    return TypeCache.InlineRegister(typeof (ApplicationException));
                case "appdomainunloaded":
                    return TypeCache.InlineRegister(typeof (AppDomainUnloadedException));
                case "argument":
                    return TypeCache.InlineRegister(typeof (ArgumentException));
                case "argumentnull":
                    return TypeCache.InlineRegister(typeof (ArgumentNullException));
                case "argumentoutofrange":
                    return TypeCache.InlineRegister(typeof (ArgumentOutOfRangeException));
                case "arithmetic":
                    return TypeCache.InlineRegister(typeof (ArithmeticException));
                case "arraytypemismatch":
                    return TypeCache.InlineRegister(typeof (ArrayTypeMismatchException));
                case "badimageformat":
                    return TypeCache.InlineRegister(typeof (BadImageFormatException));
                case "cannotunloadappdomain":
                    return TypeCache.InlineRegister(typeof (CannotUnloadAppDomainException));
                case "typeunloaded":
                    return TypeCache.InlineRegister(typeof (TypeUnloadedException));
                case "dividebyzero":
                    return TypeCache.InlineRegister(typeof (DivideByZeroException));
                case "duplicatewaitobject":
                    return TypeCache.InlineRegister(typeof (DuplicateWaitObjectException));
                case "typeload":
                    return TypeCache.InlineRegister(typeof (TypeLoadException));
                case "entrypointnotfound":
                    return TypeCache.InlineRegister(typeof (EntryPointNotFoundException));
                case "dllnotfound":
                    return TypeCache.InlineRegister(typeof (DllNotFoundException));
                case "fieldaccess":
                    return TypeCache.InlineRegister(typeof (FieldAccessException));
                case "format":
                    return TypeCache.InlineRegister(typeof (FormatException));
                case "indexoutofrange":
                    return TypeCache.InlineRegister(typeof (IndexOutOfRangeException));
                case "insufficientmemory":
                    return TypeCache.InlineRegister(typeof (InsufficientMemoryException));
                case "invalidcast":
                    return TypeCache.InlineRegister(typeof (InvalidCastException));
                case "invalidoperation":
                    return TypeCache.InlineRegister(typeof (InvalidOperationException));
                case "invalidprogram":
                    return TypeCache.InlineRegister(typeof (InvalidProgramException));
                case "methodaccess":
                    return TypeCache.InlineRegister(typeof (MethodAccessException));
                case "missingmember":
                    return TypeCache.InlineRegister(typeof (MissingMemberException));
                case "missingfield":
                    return TypeCache.InlineRegister(typeof (MissingFieldException));
                case "missingmethod":
                    return TypeCache.InlineRegister(typeof (MissingMethodException));
                case "multicastnotsupported":
                    return TypeCache.InlineRegister(typeof (MulticastNotSupportedException));
                case "notfinitenumber":
                    return TypeCache.InlineRegister(typeof (NotFiniteNumberException));
                case "notimplemented":
                    return TypeCache.InlineRegister(typeof (NotImplementedException));
                case "notsupported":
                    return TypeCache.InlineRegister(typeof (NotSupportedException));
                case "nullreference":
                    return TypeCache.InlineRegister(typeof (NullReferenceException));
                case "objectdisposed":
                    return TypeCache.InlineRegister(typeof (ObjectDisposedException));
                case "operationcanceled":
                    return TypeCache.InlineRegister(typeof (OperationCanceledException));
                case "overflow":
                    return TypeCache.InlineRegister(typeof (OverflowException));
                case "platformnotsupported":
                    return TypeCache.InlineRegister(typeof (PlatformNotSupportedException));
                case "rank":
                    return TypeCache.InlineRegister(typeof (RankException));
                case "timeout":
                    return TypeCache.InlineRegister(typeof (TimeoutException));
                case "typeinitialization":
                    return TypeCache.InlineRegister(typeof (TypeInitializationException));
                case "unauthorizedaccess":
                    return TypeCache.InlineRegister(typeof (UnauthorizedAccessException));
                case "abandonedmutex":
                    return TypeCache.InlineRegister(typeof (AbandonedMutexException));
                case "synchronizationlock":
                    return TypeCache.InlineRegister(typeof (SynchronizationLockException));
                case "threadabort":
                    return TypeCache.InlineRegister(typeof (ThreadAbortException));
                case "threadinterrupted":
                    return TypeCache.InlineRegister(typeof (ThreadInterruptedException));
                case "threadstate":
                    return TypeCache.InlineRegister(typeof (ThreadStateException));
                case "threadstart":
                    return TypeCache.InlineRegister(typeof (ThreadStartException));
                case "waithandlecannotbeopened":
                    return TypeCache.InlineRegister(typeof (WaitHandleCannotBeOpenedException));
                case "keynotfound":
                    return TypeCache.InlineRegister(typeof (KeyNotFoundException));
                case "ambiguousmatch":
                    return TypeCache.InlineRegister(typeof (AmbiguousMatchException));
                case "customattributeformat":
                    return TypeCache.InlineRegister(typeof (CustomAttributeFormatException));
                case "invalidfiltercriteria":
                    return TypeCache.InlineRegister(typeof (InvalidFilterCriteriaException));
                case "reflectiontypeload":
                    return TypeCache.InlineRegister(typeof (ReflectionTypeLoadException));
                case "target":
                    return TypeCache.InlineRegister(typeof (TargetException));
                case "targetinvocation":
                    return TypeCache.InlineRegister(typeof (TargetInvocationException));
                case "targetparametercount":
                    return TypeCache.InlineRegister(typeof (TargetParameterCountException));
                case "serialization":
                    return TypeCache.InlineRegister(typeof (SerializationException));
                case "decoderfallback":
                    return TypeCache.InlineRegister(typeof (DecoderFallbackException));
                case "encoderfallback":
                    return TypeCache.InlineRegister(typeof (EncoderFallbackException));
                case "missingmanifestresource":
                    return TypeCache.InlineRegister(typeof (MissingManifestResourceException));
                case "missingsatelliteassembly":
                    return TypeCache.InlineRegister(typeof (MissingSatelliteAssemblyException));
                case "policy":
                    return TypeCache.InlineRegister(typeof (PolicyException));
                case "external":
                    return TypeCache.InlineRegister(typeof (ExternalException));
                case "com":
                    return TypeCache.InlineRegister(typeof (COMException));
                case "invalidolevarianttype":
                    return TypeCache.InlineRegister(typeof (InvalidOleVariantTypeException));
                case "marshaldirective":
                    return TypeCache.InlineRegister(typeof (MarshalDirectiveException));
                case "seh":
                    return TypeCache.InlineRegister(typeof (SEHException));
                case "invalidcomobject":
                    return TypeCache.InlineRegister(typeof (InvalidComObjectException));
                case "safearrayrankmismatch":
                    return TypeCache.InlineRegister(typeof (SafeArrayRankMismatchException));
                case "safearraytypemismatch":
                    return TypeCache.InlineRegister(typeof (SafeArrayTypeMismatchException));
                case "io":
                    return TypeCache.InlineRegister(typeof (IOException));
                case "directorynotfound":
                    return TypeCache.InlineRegister(typeof (DirectoryNotFoundException));
                case "drivenotfound":
                    return TypeCache.InlineRegister(typeof (DriveNotFoundException));
                case "endofstream":
                    return TypeCache.InlineRegister(typeof (EndOfStreamException));
                case "fileload":
                    return TypeCache.InlineRegister(typeof (FileLoadException));
                case "filenotfound":
                    return TypeCache.InlineRegister(typeof (FileNotFoundException));
                case "pathtoolong":
                    return TypeCache.InlineRegister(typeof (PathTooLongException));
                case "runtimewrapped":
                    return TypeCache.InlineRegister(typeof (RuntimeWrappedException));
                case "xmlsyntax":
                    return TypeCache.InlineRegister(typeof (XmlSyntaxException));
                case "security":
                    return TypeCache.InlineRegister(typeof (SecurityException));
                case "hostprotection":
                    return TypeCache.InlineRegister(typeof (HostProtectionException));
                case "verification":
                    return TypeCache.InlineRegister(typeof (VerificationException));
                case "remoting":
                    return TypeCache.InlineRegister(typeof (RemotingException));
                case "server":
                    return TypeCache.InlineRegister(typeof (ServerException));
                case "remotingtimeout":
                    return TypeCache.InlineRegister(typeof (RemotingTimeoutException));
                case "isolatedstorage":
                    return TypeCache.InlineRegister(typeof (IsolatedStorageException));
                case "cryptographic":
                    return TypeCache.InlineRegister(typeof (CryptographicException));
                case "cryptographicunexpectedoperation":
                    return TypeCache.InlineRegister(typeof (CryptographicUnexpectedOperationException));
                case "privilegenotheld":
                    return TypeCache.InlineRegister(typeof (PrivilegeNotHeldException));
                case "identitynotmapped":
                    return TypeCache.InlineRegister(typeof (IdentityNotMappedException));
                case "invalidasynchronousstate":
                    return TypeCache.InlineRegister(typeof (InvalidAsynchronousStateException));
                case "invalidenumargument":
                    return TypeCache.InlineRegister(typeof (InvalidEnumArgumentException));
                case "license":
                    return TypeCache.InlineRegister(typeof (LicenseException));
                case "warning":
                    return TypeCache.InlineRegister(typeof (WarningException));
                case "win32":
                    return TypeCache.InlineRegister(typeof (Win32Exception));
                case "checkout":
                    return TypeCache.InlineRegister(typeof (CheckoutException));
                case "invaliddata":
                    return TypeCache.InlineRegister(typeof (InvalidDataException));
                case "semaphorefull":
                    return TypeCache.InlineRegister(typeof (SemaphoreFullException));
                case "uriformat":
                    return TypeCache.InlineRegister(typeof (UriFormatException));
                case "cookie":
                    return TypeCache.InlineRegister(typeof (CookieException));
                case "httplistener":
                    return TypeCache.InlineRegister(typeof (HttpListenerException));
                case "protocolviolation":
                    return TypeCache.InlineRegister(typeof (ProtocolViolationException));
                case "socket":
                    return TypeCache.InlineRegister(typeof (SocketException));
                case "web":
                    return TypeCache.InlineRegister(typeof (WebException));
                case "authentication":
                    return TypeCache.InlineRegister(typeof (AuthenticationException));
                case "invalidcredential":
                    return TypeCache.InlineRegister(typeof (InvalidCredentialException));
                case "networkinformation":
                    return TypeCache.InlineRegister(typeof (NetworkInformationException));
                case "ping":
                    return TypeCache.InlineRegister(typeof (PingException));
                case "smtp":
                    return TypeCache.InlineRegister(typeof (SmtpException));
                case "smtpfailedrecipient":
                    return TypeCache.InlineRegister(typeof (SmtpFailedRecipientException));
                case "smtpfailedrecipients":
                    return TypeCache.InlineRegister(typeof (SmtpFailedRecipientsException));
                case "configuration":
                    return TypeCache.InlineRegister(typeof (ConfigurationException));
                case "settingspropertyisreadonly":
                    return TypeCache.InlineRegister(typeof (SettingsPropertyIsReadOnlyException));
                case "settingspropertynotfound":
                    return TypeCache.InlineRegister(typeof (SettingsPropertyNotFoundException));
                case "settingspropertywrongtype":
                    return TypeCache.InlineRegister(typeof (SettingsPropertyWrongTypeException));
                case "internalbufferoverflow":
                    return TypeCache.InlineRegister(typeof (InternalBufferOverflowException));
                case "configurationerrors":
                    return TypeCache.InlineRegister(typeof (ConfigurationErrorsException));
                case "provider":
                    return TypeCache.InlineRegister(typeof (ProviderException));
                case "data":
                    return TypeCache.InlineRegister(typeof (DataException));
                case "constraint":
                    return TypeCache.InlineRegister(typeof (ConstraintException));
                case "deletedrowinaccessible":
                    return TypeCache.InlineRegister(typeof (DeletedRowInaccessibleException));
                case "duplicatename":
                    return TypeCache.InlineRegister(typeof (DuplicateNameException));
                case "inrowchangingevent":
                    return TypeCache.InlineRegister(typeof (InRowChangingEventException));
                case "invalidconstraint":
                    return TypeCache.InlineRegister(typeof (InvalidConstraintException));
                case "missingprimarykey":
                    return TypeCache.InlineRegister(typeof (MissingPrimaryKeyException));
                case "nonullallowed":
                    return TypeCache.InlineRegister(typeof (NoNullAllowedException));
                case "readonly":
                    return TypeCache.InlineRegister(typeof (ReadOnlyException));
                case "rownotintable":
                    return TypeCache.InlineRegister(typeof (RowNotInTableException));
                case "versionnotfound":
                    return TypeCache.InlineRegister(typeof (VersionNotFoundException));
                case "dbconcurrency":
                    return TypeCache.InlineRegister(typeof (DBConcurrencyException));
                case "operationaborted":
                    return TypeCache.InlineRegister(typeof (OperationAbortedException));
                case "strongtyping":
                    return TypeCache.InlineRegister(typeof (StrongTypingException));
                case "typeddatasetgenerator":
                    return TypeCache.InlineRegister(typeof (TypedDataSetGeneratorException));
                case "db":
                    return TypeCache.InlineRegister(typeof (DbException));
                case "invalidexpression":
                    return TypeCache.InlineRegister(typeof (InvalidExpressionException));
                case "evaluate":
                    return TypeCache.InlineRegister(typeof (EvaluateException));
                case "syntaxerror":
                    return TypeCache.InlineRegister(typeof (SyntaxErrorException));
                case "odbc":
                    return TypeCache.InlineRegister(typeof (OdbcException));
                case "oledb":
                    return TypeCache.InlineRegister(typeof (OleDbException));
                case "invalidudt":
                    return TypeCache.InlineRegister(typeof (InvalidUdtException));
                case "sql":
                    return TypeCache.InlineRegister(typeof (SqlException));
                case "sqltype":
                    return TypeCache.InlineRegister(typeof (SqlTypeException));
                case "sqlnullvalue":
                    return TypeCache.InlineRegister(typeof (SqlNullValueException));
                case "sqltruncate":
                    return TypeCache.InlineRegister(typeof (SqlTruncateException));
                case "sqlnotfilled":
                    return TypeCache.InlineRegister(typeof (SqlNotFilledException));
                case "sqlalreadyfilled":
                    return TypeCache.InlineRegister(typeof (SqlAlreadyFilledException));
                case "xml":
                    return TypeCache.InlineRegister(typeof (XmlException));
                case "xpath":
                    return TypeCache.InlineRegister(typeof (XPathException));
                case "xslt":
                    return TypeCache.InlineRegister(typeof (XsltException));
                case "xsltcompile":
                    return TypeCache.InlineRegister(typeof (XsltCompileException));
                case "xmlschema":
                    return TypeCache.InlineRegister(typeof (XmlSchemaException));
                case "xmlschemavalidation":
                    return TypeCache.InlineRegister(typeof (XmlSchemaValidationException));
                case "xmlschemainference":
                    return TypeCache.InlineRegister(typeof (XmlSchemaInferenceException));
            }
            //+
            return ex;
        }
    }
}