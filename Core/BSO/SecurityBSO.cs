using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;
namespace BSO
{
    public class SecurityBSO
    {
        public SecurityBSO() 
        {
            //contrustor
        }

        private string keyValue = "ChIpYeU";
        public string Key
        {
            set { keyValue = value; }
            get { return keyValue; }
        }

        #region EncPwd
     
        public string EncPwd(string password)
        {
            string encryptPassword = password + keyValue;
            byte[] passwordBytes = Encoding.UTF8.GetBytes(encryptPassword);

            HashAlgorithm hash = new MD5CryptoServiceProvider();
            byte[] hashBytes = hash.ComputeHash(passwordBytes);

            encryptPassword = Convert.ToBase64String(passwordBytes);
            return encryptPassword;
        }

        #endregion

        #region DecPwd
        
        public string DecPwd(string password)
        {
            string originalPassword = "";
            byte[] inputByteArray = Convert.FromBase64String(password);

            originalPassword = Encoding.UTF8.GetString(inputByteArray);

            return originalPassword.Substring(0,originalPassword.Length - keyValue.Length);
        }

        #endregion

        //public string enCode(string Pass)
        //{

        //    EDData.clsEDData EDD = new EDData.clsEDData();
        //    string s = null;
        //    object s1 = null;
        //    EDD.SetKey("EVNIT_16LDH", EDData.EDKeyTypeEnum.eEDString, ref s1);
        //    s = EDD.EncryptStr(Pass, EDData.EDDataType.eHex);
        //    return EDD.EncryptStr(Pass, EDData.EDDataType.eHex);
        //}

        //public string DeCode(string Pass)
        //{
        //    clsEDData EDD = new clsEDData();
        ////    EDData.clsEDData EDD = new EDData.clsEDData();
        //    string s = null;
        //    object s1 = null;
        //    EDD.SetKey("EVNIT_16LDH", EDKeyTypeEnum.eEDString, ref s1);
        //    s = EDD.DecryptStr(Pass, EDDataType.eHex);
        //    return EDD.DecryptStr(Pass, EDDataType.eHex);
        //}


   }
}
