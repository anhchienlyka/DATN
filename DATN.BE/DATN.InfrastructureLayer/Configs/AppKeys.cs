using DATN.InfrastructureLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.InfrastructureLayer.Configs
{
    public class AppKeys
    {
        public static string JWTIssuer = AppSettings.GetAppKey("JWTIssuer");
        public static string JWTAudience = AppSettings.GetAppKey("JWTAudience");
        public static string JWTSecretKey = AppSettings.GetAppKey("JWTSecretKey");
        public static int JWTTimeout = AppSettings.GetAppKey<int>("JWTTimeout");

        // configs for ptw
        public static string PTWBaseUrl = AppSettings.GetAppKey("PTWBaseUrl");
        public static string PTWTokenEndPoint = AppSettings.GetAppKey("PTWTokenEndPoint");
        public static string PTWGrantType = AppSettings.GetAppKey("PTWGrantType");
        public static string PTWScope = AppSettings.GetAppKey("PTWScope");
        public static string PTWClientId = AppSettings.GetAppKey("PTWClientId");
        public static string PTWClientSecret = AppSettings.GetAppKey("PTWClientSecret");

        // configs for LDAP
        public static string LDAPServer = AppSettings.GetAppKey("LdapServer");
        public static string LdapUserName = AppSettings.GetAppKey("LdapUserName");
        public static string LdapPassword = AppSettings.GetAppKey("LdapPassword");
        public string Secret { get; set; }
    }
}
