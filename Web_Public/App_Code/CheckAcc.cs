using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;


/// <summary>
/// Summary description for CheckAcc
/// </summary>
public class CheckAcc
{
	public CheckAcc()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword,
        int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

}