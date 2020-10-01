using System;
using System.Configuration;

namespace ePower.Core
{
    /// <summary>
    /// Summary description for Config
    /// </summary>
    public sealed class Key
    {
        private static readonly Key instance = new Key();
        private string _sKey;
        public static string sKey
        { 
            get { 
                return instance._sKey; 
            }
        }
        Key()
        {
            _sKey = "ePower" + DateTime.Now.Month.ToString();
        }
        public static Key Instance
        {
            get { return instance; }
        }
    }
}