using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using TSB.Security.Entities;

namespace TSB.Security.Authentication
{
    /// <summary>
    /// Define a funcionalidade básica de um objeto AutenticationLdap.
    /// Um objeto AutenticationLdap provê autenticação de um usuário em um servidor de diretório utilizando o protocolo LDAP.
    /// </summary>
    public class AutenticationLdap : IAuthentication
    {
        private PrincipalContext _domainContext;

        /// <summary>
        /// Cria uma nova instancia da classe AutenticationLdap.
        /// </summary>
        public AutenticationLdap()
        {
            _domainContext = new PrincipalContext(ContextType.Domain, "DOMAIN", null, ContextOptions.Negotiate);
        }

        /// <summary>
        /// Realiza a autenticação de um usuário em um servidor de diretório LDAP.
        /// </summary>
        /// <param name="UserName">Nome de usuário utilizado para a autenticação.</param>
        /// <param name="Pwd">Senha utilizada para a autenticação.</param>
        /// <returns>Retorna Verdadeiro caso usuário seja autenticado, e Falso caso não seja.</returns>
        public bool Login(string UserName, string Pwd)
        {
            try
            {
                //Valida os dados de usuário e senha
                var result = _domainContext.ValidateCredentials(UserName, Pwd, ContextOptions.Negotiate);

                if ((bool)result == false)
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao realizar autenticação LDAP. " + ex.Message);
            }

            return true;
        }

        /// <summary>
        /// Recupera os dados do usuário autenticado em um servidor LDAP.
        /// </summary>
        /// <param name="Key">Nome de usuário autenticado.</param>
        /// <param name="Type">Tipo da consulta. 1 para UserName, 2 para Matricula</param>
        /// <returns>objeto IUser com os dados de um usuário.</returns>
        public Entities.IUser GetUser(string Key, int Type)
        {
            try
            {
                //Cria um nova instancia de User para retornar após preencher com os dados do AD
                User _userLdap = new User();
                string _key = "";
                UserPrincipal _user;

                //Instanticia uma UserPrincipal para fazer a busca no AD
                if (Type == 1)
                {
                    _key = Key;
                    _user = UserPrincipal.FindByIdentity(_domainContext, _key);
                }
                else
                {
                    _key = "M" + Key.ToString().PadLeft(7, '0') + "@DOMAIN.COM";
                    _user = UserPrincipal.FindByIdentity(_domainContext, IdentityType.UserPrincipalName, _key);
                }

                DirectoryEntry _de = (DirectoryEntry)_user.GetUnderlyingObject();
                _userLdap.Id = _user.UserPrincipalName.Substring(1, _user.UserPrincipalName.IndexOf("@") - 1);
                _userLdap.UserName = _user.SamAccountName.ToString();
                _userLdap.FullName = _user.DisplayName.ToString();
                _userLdap.GivenName = _user.GivenName.ToString();
                _userLdap.SurName = _user.Surname.ToString();
                _userLdap.Matricula = _de.Properties["extensionAttribute1"].Value == null ? "Nulo" : _de.Properties["extensionAttribute1"].Value.ToString().Replace(".", "").Replace("-", "");
                _userLdap.CPF = _de.Properties["extensionAttribute12"].Value == null ? "Nulo" : _de.Properties["extensionAttribute12"].Value.ToString().Substring(4);
                _userLdap.Email = _user.EmailAddress == null ? "Nulo" : _user.EmailAddress.ToString();
                _userLdap.PrivateEmail = _de.Properties.Contains("msExchExtensionCustomAttribute1") == false ? "Nulo" : _de.Properties["msExchExtensionCustomAttribute1"].Value.ToString();
                _userLdap.Location = _de.Properties.Contains("physicalDeliveryOfficeName") == false ? "Nulo" : _de.Properties["physicalDeliveryOfficeName"].Value.ToString();
                _userLdap.Outsourced = _de.Properties.Contains("extensionAttribute10") == false ? "Nulo" : _de.Properties["extensionAttribute10"].Value.ToString();

                _user.Dispose();

                return _userLdap;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter dados do usuário no LDAP. " + ex.Message);
            }
        }

        /// <summary>
        /// Recupera os dados do usuário autenticado em um servidor LDAP.
        /// </summary>
        /// <param name="UserName">Nome de usuário autenticado.</param>
        /// <returns>objeto IUser com os dados de um usuário.</returns>
        public IUser GetUser(string UserName)
        {
            return GetUser(UserName, 1);
        }
    }
}
