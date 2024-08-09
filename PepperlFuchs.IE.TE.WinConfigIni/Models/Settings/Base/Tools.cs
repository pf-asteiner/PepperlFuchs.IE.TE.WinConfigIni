using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.IniFile;
using static PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base.Defines;

namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base
{
    internal class Tools
    {

        public static uint GetItem(string sectionName)
        {
            if (string.IsNullOrEmpty(sectionName)) throw new ArgumentNullException(nameof(sectionName));
            if (sectionName.Contains("_"))
            {
                string sectionItem = sectionName.Substring(sectionName.LastIndexOf("_") + 1);
                return Convert.ToUInt32(sectionItem);
            }
            return 0;
        }

        public static string SerialisationToIni(Type section)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[" + nameof(section.Name) + "_" + section.ToString() + "]" + Environment.NewLine);

            foreach (var prop in section.GetProperties())
            {
                sb.Append(prop.Name.ToUpper()); // + " = " + prop.GetValue(section) + Environment.NewLine);
            }
            return sb.ToString();
        }


        internal static void ReadInParameters(object baseObject, Type setting, ObservableCollection<SectionParameter> parameterList)
        {
            foreach (SectionParameter parameter in parameterList)
            {
                if (KeyWordList(setting.GetProperties().ToList()).Contains(parameter.Name))
                {
                    // set Property of class
                    PropertyInfo pro = GetProperyFor(setting, parameter.Name);
                    if (!pro.CanRead) continue;

                    switch (pro.Name)
                    {
                        default:
                            break;
                    }
                }
            }
        }

        internal static List<string> KeyWordList(List<PropertyInfo> properties)
        {
            var list = new List<string>();
            foreach (PropertyInfo property in properties)
            {
                var attributes = property.GetCustomAttributes(true);
                if (attributes[0] is Base.ParameterAttribute attrib)
                {
                    list.Add(attrib.GetKeyWord());
                }
            }
            return list;
        }

        internal static PropertyInfo? GetProperyFor(Type type, string Keyword)
        {
            List<PropertyInfo> properties = type.GetProperties().ToList();
            string keyName = string.Empty;

            if (properties == null)
            {
                throw new Exception("got no properies");
            }

            foreach (PropertyInfo property in properties)
            {
                var attributes = property.GetCustomAttributes(true);

                if (attributes[0] is Base.ParameterAttribute attrib)
                {
                    keyName = attrib.GetKeyWord();
                }

                if (keyName == Keyword)
                {
                    return property;
                }
            }
            return null;

        }

        internal static void ReadInProperties(object baseObject, Type setting, ObservableCollection<SectionParameter> parameterList)
        {
            if (setting is null) { throw new ArgumentNullException(nameof(setting)); }

            List<PropertyInfo> properties = setting.GetProperties().ToList();

            if (properties == null)
            {
                throw new Exception("got no properies");
            }

            //if (checkParameterCount(properties, parameterList) == false)
            //{

            //    throw new Exception(nameof(setting) + " has >" + properties.Count().ToString() + "< and parameter list has >" + parameterList.Count.ToString() + "<");
            //}

            SectionParameter? parameter = null;
            foreach (PropertyInfo prop in properties)
            {
                var attributes = prop.GetCustomAttributes(true);
                string keyName = string.Empty;

                if (attributes[0] is Base.ParameterAttribute attrib)
                {
                    keyName = attrib.GetKeyWord();
                }

                switch (keyName)
                {
                    case "Com port":
                        {
                            Type subPropType = prop.PropertyType;
                            // get the sub property as a object
                            //ComSetting comSetting = new();
                            //properties[1].SetValue(comSetting);
                            var propObject = properties[1].GetValue(baseObject) ?? throw new Exception("Got no subpropery instance");
                            ReadInProperties(propObject, subPropType, parameterList);
                        }
                        continue;
                    case "ITEM":
                        continue;
                    case "IpSetting":
                        {
                            Type subPropType = prop.PropertyType;
                            // get the sub property as a object
                            var propObject = properties[1].GetValue(baseObject) ?? throw new Exception("Got no subpropery instance");
                            ReadInProperties(propObject, subPropType, parameterList);
                        }
                        continue;
                }

                foreach (SectionParameter para in parameterList)
                {

                    if (para.Name == keyName)
                    {
                        //parameter = para;
                        break;
                    }
                }

                if (parameter == null)
                {
                    //throw new Exception("Could find parameter");
                    continue;
                }
                switch (prop.PropertyType.Name)
                {
                    case "Double":
                        {
                            double value;
                            string merker = parameter.Value;
                            try
                            {
                                value = Convert.ToDouble(merker);
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            try
                            {
                                prop.SetValue(baseObject, value, null);
                            }
                            catch
                            {
                                throw;
                            }
                        }
                        break;
                    case "Int":
                    case "Int32":
                        {
                            Int32 value = 0;
                            string merker = parameter.Value;

                            if (merker.StartsWith("0x"))
                            {
                                try
                                {
                                    value = Convert.ToInt32(merker, 16);
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                            else
                            {
                                try
                                {
                                    value = Convert.ToInt32(merker);
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                            try
                            {
                                prop.SetValue(baseObject, value, null);
                            }
                            catch
                            {
                                throw;
                            }
                        }
                        break;
                    case "String":
                        {
                            string value = parameter.Value;
                            try
                            {
                                prop.SetValue(baseObject, value, null);
                            }
                            catch
                            {
                                throw;
                            }
                        }
                        break;
                    case "uint":
                    case "UInt32":
                        {
                            UInt32 value;
                            string merker = parameter.Value;
                            if (merker.StartsWith("0x"))
                            {
                                try
                                {
                                    value = Convert.ToUInt32(merker, 16);
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                            else
                            {
                                try
                                {
                                    value = Convert.ToUInt32(merker);
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                            }
                            try
                            {
                                prop.SetValue(baseObject, value, null);
                            }
                            catch
                            {
                                throw;
                            }

                        }
                        break;
                    case "IPAddress":
                        {
                            IPAddress value;

                            try
                            {
                                value = IPAddress.Parse(parameter.Value);
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                            try
                            {
                                prop.SetValue(baseObject, value, null);
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                        break;
                    case "Parity":
                        {
                            Parity value;

                            switch (parameter.Value)
                            {
                                case "NOPARITY":
                                    value = Defines.Parity.NOPARITY;
                                    break;

                                case "ODDPARITY":
                                    value = Defines.Parity.ODDPARITY;
                                    break;
                                case "EVENPARITY":
                                    value = Defines.Parity.EVENPARITY;
                                    break;
                                case "MARKPARITY":
                                    value = Defines.Parity.MARKPARITY;
                                    break;
                                case "SPACEPARITY":
                                    value = Defines.Parity.SPACEPARITY;
                                    break;
                                default:
                                    throw new ArgumentException("Unknown Patrity value: >" + parameter.Value + "<");

                            }

                            try
                            {
                                prop.SetValue(baseObject, value, null);
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                        break;
                    case "HwHandshake":
                        {
                            HwHandshake value = HwHandshake.HW_HANDSHAKE_OFF;

                            switch (parameter.Value)
                            {
                                case "COM_DEFAULT":
                                    value = HwHandshake.HW_HANDSHAKE_OFF;
                                    break;
                                case "CTS_RST_DTR_HANDSHACKE":
                                    value = HwHandshake.HW_HANDSHAKE_CTS_RTS_DTR;
                                    break;
                                case "CTS_RTS_HANDSHAKE":
                                    value = HwHandshake.HW_HANDSHAKE_CTS_RTS;
                                    break;
                                default:
                                    throw new ArgumentException(parameter.Value + ">" + parameter.Value + "< is unknown");
                            }

                            try
                            {
                                prop.SetValue(baseObject, value, null);
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                        break;
                    case "Stopbit":
                        {
                            Stopbit value = Stopbit.ONESTOPBIT;

                            switch (parameter.Value)
                            {
                                case "ONESTOPBIT":
                                    value = Stopbit.ONESTOPBIT;
                                    break;
                                case "ONE5STOPBITS":
                                    value = Stopbit.ONE5STOPBITS;
                                    break;
                                case "TWOSTOPBITS":
                                    value = Stopbit.TWOSTOPBITS;
                                    break;
                                default:
                                    throw new ArgumentException(parameter.Value + ">" + parameter.Value + "< is unknown");
                            }

                            try
                            {
                                prop.SetValue(baseObject, value, null);
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                        break;
                    default:
                        throw new Exception("No handle for >" + prop.PropertyType.Name);
                }
            }
        }

        private static bool checkParameterCount(List<PropertyInfo> properties, ObservableCollection<SectionParameter> parameterList)
        {
            if (properties == null) return false;
            if (parameterList == null) return false;

            int propertiesCount = properties.Count;
            int parameterCount = parameterList.Count;
            List<string> propertyNames = new();
            properties.ForEach(p => { propertyNames.Add(p.Name); });
            if (propertyNames.Contains("Item"))
            {
                // main property
                foreach (PropertyInfo property in properties)
                {
                    if (!property.CanRead) continue;


                    switch (property.Name)
                    {
                        case "Item":
                            propertiesCount--;                          // substact the ITEM property
                            continue;
                        case "TcpIp":
                            var ip = typeof(TcpipSetting);
                            if (ip != null)
                            {
                                var props = ip.GetProperties();
                                propertiesCount += props.Count() - 1; // substact the TcpIp porperty and add the properties of TcpipSetting
                            }
                            break;
                        case "Com":
                            var com = typeof(ComSetting);
                            if (com != null)
                            {
                                var props = com.GetProperties();
                                propertiesCount += props.Count() - 1; // substact the Com property and add the properties of ComSetting
                            }
                            break;


                    }
                }
                if (propertiesCount == parameterCount) return true;
            }
            else
            {
                // subproperty
                List<string> parameterKeyNames = new();
                List<string> parameterNames = new();

                foreach (var parameterName in parameterList)
                {
                    parameterNames.Add(parameterName.Name);
                }

                foreach (PropertyInfo property in properties)
                {
                    var atrib = property.GetCustomAttribute<ParameterAttribute>(true);
                    if (atrib != null)
                    {
                        parameterKeyNames.Add(atrib.GetKeyWord().ToString());
                    }
                }

                foreach (string popertyName in parameterKeyNames)
                {
                    if (parameterNames.Contains(popertyName) == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
