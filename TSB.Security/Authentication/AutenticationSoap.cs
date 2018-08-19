using System;
using TSB.Security.Entities;

namespace TSB.Security.Authentication
{
    /// <summary>
    /// Define a funcionalidade básica de um objeto AutenticationSoap.
    /// Um objeto AutenticationSoap provê autenticação de um usuário em um serviço utilizando SOAP.
    /// </summary>
    public class AutenticationSoap : IAuthentication
    {
        private string _accessToken;

        /// <summary>
        /// Cria uma nova instancia de AutenticationSoap.
        /// </summary>
        public AutenticationSoap()
        { }

        /// <summary>
        /// Obtém o token serializado de conexão atual.
        /// </summary>
        public string Token
        {
            get { return _accessToken; }
        }

        /// <summary>
        /// Realiza a autenticação de um usuário em um WebService de autenticacao.
        /// </summary>
        /// <param name="UserName">Nome de usuário utilizado para a autenticação.</param>
        /// <param name="Pwd">Senha utilizada para a autenticação.</param>
        /// <returns>Retorna Verdadeiro caso usuário seja autenticado, e Falso caso não seja.</returns>
        public bool Login(string UserName, string Pwd)
        {
            try
            {
                //ADICIONE A REFERENCIA AO WEBSERVICE DE AUTENTICACAO
                //E FACA A CHAMADA DO METODO DE VALIDACAO E GERACAO DO TOKEN AQUI
                //Cria um token de acesso passando o usuário e senha.
                //using (var authenticationClient = new AuthenticationService.BasicHttpAuthServiceClient())
                //{
                //    _accessToken = authenticationClient.GrantPasswordAccessToken(UserName, Pwd);
                //}
                _accessToken = "TOKEN DE ACESSO GERADO PELO SERVICO";

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao realizar autenticação no Servico remoto. " + ex.Message);
            }

        }

        /// <summary>
        /// Recupera os dados do usuário autenticado no servico.
        /// </summary>
        /// <param name="UserName">Nome de usuário autenticado.</param>
        /// <returns>objeto IUser com os dados de um usuário.</returns>
        public IUser GetUser(string UserName)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(string Key, int Type)
        {
            throw new NotImplementedException();
        }
    }
}
