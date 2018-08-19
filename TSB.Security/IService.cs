using System;
using TSB.Security.Authentication;
using TSB.Security.Entities;

namespace TSB.Security
{
    public interface IService
    {
        bool Login(string UserName, string Pwd);
        IUser GetUser(string UserName);
        IUser GetUser(string Key, int Type);
        string GetUserToXml(string UserName);
        string GetUserToXml(string Key, int Type);
    }

    public class SoapService : IService
    {
        public IAuthentication SoapAutentication;

        public SoapService(string PoolName)
        {
            SoapAutentication = new AutenticationSoap();
        }

        public bool Login(string UserName, string Pwd)
        {
            return SoapAutentication.Login(UserName, Pwd);
        }

        public IUser GetUser(string UserName)
        {
            return SoapAutentication.GetUser(UserName);
        }

        public string GetUserToXml(string UserName)
        {
            return SoapAutentication.GetUser(UserName).ToXml();
        }

        public IUser GetUser(string Key, int Type)
        {
            throw new NotImplementedException();
        }

        public string GetUserToXml(string Key, int Type)
        {
            throw new NotImplementedException();
        }
    }

    public class LdapService : IService
    {
        public IAuthentication LdapAutentication;

        public LdapService()
        {
            LdapAutentication = new AutenticationLdap();
        }

        public bool Login(string UserName, string Pwd)
        {
            return LdapAutentication.Login(UserName, Pwd);
        }

        public IUser GetUser(string UserName)
        {
            return LdapAutentication.GetUser(UserName);
        }

        public string GetUserToXml(string UserName)
        {
            return LdapAutentication.GetUser(UserName).ToXml();
        }

        public IUser GetUser(string Key, int Type)
        {
            return LdapAutentication.GetUser(Key, Type);
        }

        public string GetUserToXml(string Key, int Type)
        {
            return LdapAutentication.GetUser(Key, Type).ToXml();
        }
    }
}
