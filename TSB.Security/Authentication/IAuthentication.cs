using System;
using TSB.Security.Entities;

namespace TSB.Security.Authentication
{
    /// <summary>
    /// Define a funcionalidade básica de um objeto IAutentication.
    /// Um objeto autentication provê autenticação de um usuário.
    /// </summary>
    public interface IAuthentication
    {
        /// <summary>
        /// Realiza a autenticação de um usuário
        /// </summary>
        /// <param name="UserName">Nome de usuário utilizado para a autenticação</param>
        /// <param name="Pwd">Senha utilizada para a autenticação</param>
        /// <returns>Retorna Verdadeiro caso usuário seja autenticado, e Falso caso não seja.</returns>
        bool Login(string UserName, string Pwd);

        /// <summary>
        /// Recupera os dados do usuário autenticado
        /// </summary>
        /// <param name="UserName">Nome de usuário autenticado</param>
        /// <returns>objeto IUser com os dados de um usuário</returns>
        IUser GetUser(string UserName);

        /// <summary>
        /// Recupera os dados do usuário autenticado em um servidor LDAP.
        /// </summary>
        /// <param name="Key">Nome de usuário autenticado.</param>
        /// <param name="Type">Tipo da consulta. 1 para UserName, 2 para Matricula</param>
        /// <returns>objeto IUser com os dados de um usuário.</returns>
        IUser GetUser(string Key, int Type);
    }
}
