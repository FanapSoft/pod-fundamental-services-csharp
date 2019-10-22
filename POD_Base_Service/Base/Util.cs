using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;

namespace POD_Base_Service.Base
{
    public static class Util
    {
        public static List<KeyValuePair<string, string>> ValidateByAttribute(this object builder)
        {
            var hasErrorFields = new List<KeyValuePair<string, string>>();
            var type = builder.GetType();
            var context = new ValidationContext(builder, null, null);
            var fields = type.GetRuntimeFields()
                .Where(_ => _.GetCustomAttributes(typeof(ValidationAttribute), false).Any());
            foreach (var field in fields)
            {
                var results = new List<ValidationResult>();
                var attributes = field
                    .GetCustomAttributes(false)
                    .OfType<ValidationAttribute>()
                    .ToArray();
                Validator.TryValidateValue(field.GetValue(builder), context, results, attributes);
                foreach (var result in results)
                {
                    hasErrorFields.Add(new KeyValuePair<string, string>(field.Name, result.ErrorMessage));
                }
            }

            return hasErrorFields;
        }

        public static List<KeyValuePair<string, string>> ValidateFieldAndPropertyByAttribute(this object builder)
        {
            var hasErrorFields = new List<KeyValuePair<string, string>>();
            var type = builder.GetType();
            var context = new ValidationContext(builder, null, null);
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.CreateInstance |
                               BindingFlags.FlattenHierarchy;
            var members = GetFieldsAndProperties(type, bindingFlags)
                .Where(_ => _.GetCustomAttributes(typeof(ValidationAttribute), false).Any());
            foreach (var member in members)
            {
                var results = new List<ValidationResult>();
                var attributes = member
                    .GetCustomAttributes(false)
                    .OfType<ValidationAttribute>()
                    .ToArray();

                if (member is FieldInfo field)
                {
                    Validator.TryValidateValue(field.GetValue(builder), context, results, attributes);
                }
                else if (member is PropertyInfo property)
                {
                    Validator.TryValidateValue(property.GetValue(builder), context, results, attributes);
                }

                foreach (var result in results)
                {
                    hasErrorFields.Add(new KeyValuePair<string, string>(member.Name, result.ErrorMessage));
                }
            }

            return hasErrorFields;
        }

        public static List<PropertyInfo> GetParentProperty<T>(this T obj)
        {
            return obj.GetType().BaseType?.GetProperties().ToList();
        }
        public static List<MemberInfo> GetFieldsAndProperties<T>(BindingFlags bindingAttr)
        {
            return GetFieldsAndProperties(typeof(T), bindingAttr);
        }

        public static List<MemberInfo> GetFieldsAndProperties(Type type, BindingFlags bindingAttr)
        {
            var targetMembers = new List<MemberInfo>();

            targetMembers.AddRange(type.GetRuntimeFields());
            targetMembers.AddRange(type.GetProperties(bindingAttr));

            return targetMembers;
        }

        public static List<KeyValuePair<string, string>> FilterNotNull<T>(this T obj, Dictionary<string, string> podParameterName)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var properties = obj.GetType().GetProperties(bindingFlags);
            var notNullProperties = new List<KeyValuePair<string, string>>();
            foreach (var pr in properties)
            {
                var val = pr.GetValue(obj);
                if (val == null) continue;
                if (val is IList valueList)
                {
                    if (val is Array)
                    {
                        podParameterName.TryGetValue(pr.Name, out var podName);
                        foreach (var value in valueList)
                        {                          
                            notNullProperties.Add(new KeyValuePair<string, string>(podName, value.ToString(CultureInfo.InvariantCulture)));
                        }
                    }
                    else
                    {
                        var objects = valueList.Cast<object>().ToList();
                        foreach (var ob in objects)
                        {
                           notNullProperties.AddRange(ob.FilterNotNull(podParameterName));
                        }
                    }
                }
                else if (pr.PropertyType.IsClass && pr.PropertyType.Assembly.FullName.StartsWith("POD_"))
                {
                    notNullProperties.AddRange(val.FilterNotNull(podParameterName));
                }
                else
                {
                    podParameterName.TryGetValue(pr.Name, out var podName);
                    notNullProperties.Add(new KeyValuePair<string, string>(podName, val.ToString(CultureInfo.InvariantCulture)));
                }
            }

            return notNullProperties;
        }

        public static string ToJson(this List<KeyValuePair<string, string>> keyValuePairs)
        {
            var entries = keyValuePairs.Select(d => $"\"{d.Key}\": {string.Join(",", $"\"{d.Value}\"")}");
            return "{" + string.Join(",", entries) + "}";
        }

        public static string ToString(this object value,CultureInfo cultureInfo)
        {
            return string.Format(cultureInfo, "{0}", value);
        }

        public static Dictionary<string, object> ToDictionaryHierachy(this object classObj, Dictionary<string, string> podParameterName)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var properties = classObj.GetType().GetProperties(bindingFlags);
            var propDic = new Dictionary<string, object>();
            foreach (var property in properties)
            {
                var propValue = property.GetValue(classObj);
                if(propValue==null) continue;
                if (property.PropertyType.IsClass && property.PropertyType.Assembly.FullName.StartsWith("POD_"))
                {
                    var valueProperties = propValue.GetType().GetProperties(bindingFlags);
                    var propDic1 = new Dictionary<string, object>();
                    foreach (var valueProperty in valueProperties)
                    {
                        var value = valueProperty.GetValue(propValue);
                        if (value == null) continue;
                        podParameterName.TryGetValue(valueProperty.Name, out var valPodName);
                        propDic1.Add(valPodName, value);
                    }
                    podParameterName.TryGetValue(property.Name, out var podName);
                    propDic.Add(podName, propDic1);
                }
                else
                {
                    podParameterName.TryGetValue(property.Name, out var podName);
                    propDic.Add(podName, propValue);
                }
            }

            return propDic;
        }

        public static Dictionary<string, object> ToDictionary(this object classObj, Dictionary<string, string> podParameterName)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var properties = classObj.GetType().GetProperties(bindingFlags);
            var propDic = new Dictionary<string, object>();
            foreach (var property in properties)
            {
                var propValue = property.GetValue(classObj);
                if (propValue == null) continue;
                if (property.PropertyType.IsClass && property.PropertyType.Assembly.FullName.StartsWith("POD_"))
                {
                    propDic.Concat(propValue.ToDictionary(podParameterName));
                }
                else
                {
                    podParameterName.TryGetValue(property.Name, out var podName);
                    propDic.Add(podName, propValue);
                }
            }

            return propDic;
        }

        public static bool JArrayTryParse(this string value, out JArray jArray)
        {
            try
            {
                jArray = JArray.Parse(value);
                return true;
            }
            catch
            {
                jArray = null;
                return false;
            }
        }

        public static string ToShamsiDate(this DateTime dateTime)
        {
            var pc = new PersianCalendar();
            var shamsiDate = $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime)}/{pc.GetDayOfMonth(dateTime)}";
            return shamsiDate;
        }

        public static string ToShamsiDateTime(this DateTime dateTime)
        {
            var pc = new PersianCalendar();
            var shamsiDate = $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime)}/{pc.GetDayOfMonth(dateTime)} {pc.GetHour(dateTime)}:{pc.GetMinute(dateTime)}:{pc.GetSecond(dateTime)}";
            return shamsiDate;
        }

        public static string GetSignature(this string dataToSign, HashAlgorithmName hashAlgorithmName, string pemFilePath)
        {
            var rsaCsp = LoadRsaFile(pemFilePath);
            var dataBytes = Encoding.UTF8.GetBytes(dataToSign);
            var signatureBytes = rsaCsp.SignData(dataBytes, hashAlgorithmName, RSASignaturePadding.Pkcs1);
            var signatureBase64 = Convert.ToBase64String(signatureBytes);
            return signatureBase64;
        }

        public static string GetSignature(this string dataToSign, string privateKey, HashAlgorithmName hashAlgorithmName)
        {
            var res = GetPem("RSA PRIVATE KEY", Encoding.ASCII.GetBytes(privateKey));
            var rsaCsp = DecodeRsaPrivateKey(res);
            var signatureBytes = rsaCsp.SignData(Encoding.UTF8.GetBytes(dataToSign), hashAlgorithmName,
                RSASignaturePadding.Pkcs1);
            var signatureBase64 = Convert.ToBase64String(signatureBytes);
            return signatureBase64;
        }

        private static byte[] GetPem(string type, byte[] data)
        {
            var pem = Encoding.UTF8.GetString(data);
            var header = $"-----BEGIN {type}-----\\n";
            var footer = $"-----END {type}-----";
            var start = pem.IndexOf(header) + header.Length;
            var end = pem.IndexOf(footer, start);
            var base64 = pem.Substring(start, (end - start));
            return Convert.FromBase64String(base64);
        }

        public static RSACryptoServiceProvider LoadRsaFile(string path)
        {
            using (var fs = File.OpenRead(path))
            {
                var data = new byte[fs.Length];
                byte[] res = null;
                fs.Read(data, 0, data.Length);
                if (data[0] != 0x30)
                {
                    res = GetPem("RSA PRIVATE KEY", data);
                }

                try
                {
                    var rsa = DecodeRsaPrivateKey(res);
                    return rsa;
                }
                catch (System.Exception)
                {
                    // ignored
                }

                return null;
            }
        }
        public static string ToXml(this RSA rsa, bool includePrivateParameters)
        {
            var parameters = rsa.ExportParameters(includePrivateParameters);

            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
                parameters.Modulus != null ? Convert.ToBase64String(parameters.Modulus) : null,
                parameters.Exponent != null ? Convert.ToBase64String(parameters.Exponent) : null,
                parameters.P != null ? Convert.ToBase64String(parameters.P) : null,
                parameters.Q != null ? Convert.ToBase64String(parameters.Q) : null,
                parameters.DP != null ? Convert.ToBase64String(parameters.DP) : null,
                parameters.DQ != null ? Convert.ToBase64String(parameters.DQ) : null,
                parameters.InverseQ != null ? Convert.ToBase64String(parameters.InverseQ) : null,
                parameters.D != null ? Convert.ToBase64String(parameters.D) : null);
        }
        private static RSACryptoServiceProvider DecodeRsaPrivateKey(byte[] privatekey)
        {
            // --------- Set up stream to decode the asn.1 encoded RSA private key ------
            var mem = new MemoryStream(privatekey);
            var binr = new BinaryReader(mem); //wrap Memory Stream with BinaryReader for easy reading
            try
            {
                var twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //dataToSign read as little endian order (actual dataToSign order for Sequence is 30 81)
                    binr.ReadByte(); //advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16(); //advance 2 bytes
                else
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102) //version number
                    return null;
                int bt = binr.ReadByte();
                if (bt != 0x00)
                    return null;


                //------ all private key components are Integer sequences ----
                var elems = GetIntegerSize(binr);
                var modulus = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var e = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var d = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var p = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var q = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var dp = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var dq = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var iq = binr.ReadBytes(elems);

                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                var cspParameters = new CspParameters {Flags = CspProviderFlags.UseMachineKeyStore};
                var rsa = new RSACryptoServiceProvider(1024, cspParameters);
                var rsaParams = new RSAParameters
                {
                    Modulus = modulus,
                    Exponent = e,
                    D = d,
                    P = p,
                    Q = q,
                    DP = dp,
                    DQ = dq,
                    InverseQ = iq
                };
                rsa.ImportParameters(rsaParams);
                return rsa;
            }
            catch
            {
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

        private static int GetIntegerSize(BinaryReader binaryReader)
        {
            var bt = binaryReader.ReadByte();
            if (bt != 0x02) //expect integer
                return 0;
            bt = binaryReader.ReadByte();
            int count;
            if (bt == 0x81)
                count = binaryReader.ReadByte(); // dataToSign size in next byte
            else if (bt == 0x82)
            {
                var highByte = binaryReader.ReadByte();
                var lowByte = binaryReader.ReadByte();
                byte[] modint = {lowByte, highByte, 0x00, 0x00};
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt; // we already have the dataToSign size
            }

            while (binaryReader.ReadByte() == 0x00)
            {
                count -= 1; //remove high order zeros in dataToSign
            }

            binaryReader.BaseStream.Seek(-1, SeekOrigin.Current); //last ReadByte wasn't a removed zero, so back up a byte
            return count;
        }
    }
}